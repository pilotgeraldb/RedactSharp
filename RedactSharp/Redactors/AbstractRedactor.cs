using System;
using System.Collections.Generic;
using System.Linq;
using RedactSharp.Sanitizers;
using RedactSharp.Validators;

namespace RedactSharp.Redactors
{
    public abstract class AbstractRedactor : IRedactor
    {
        public string FriendlyName { get; set; }
        public IValidator Validator { get; set; }
        public IMatchProcessor MatchProcessor { get; set; }
        public IMatcher Matcher { get; set; }

        private Type ValidatorType { get; set; }
        private Type MatcherType { get; set; }
        private Type MatchProcessorType { get; set; }
        private Type SanitizerType { get; set; } 
        private ISanitizerOptions SanitizerOptions { get; set; }

        private Func<string, string> BeforeProcessFunc { get; set; }
        private Func<string, string> AfterProcessFunc { get; set; }
        private Func<string, IRedactorMatch, IRedactorMatch> BeforeProcessMatchFunc { get; set; }
        private Func<string, IRedactorMatch, string> AfterProcessMatchFunc { get; set; }

        public AbstractRedactor()
        {
            MatchProcessor = new MatchProcessor();
            Matcher = new RegularExpressionMatcher();
        }

        public virtual IRedactorResult Redact(string input)
        {
            IRedactorResult redactorResult = new RedactorResult();

            if (string.IsNullOrWhiteSpace(input))
            {
                redactorResult.Result = input;
                return redactorResult;
            }

            input = BeforeProcessFunc?.Invoke(input) ?? input;

            ISanitizer sanitizer = CreateSanitizer(input);

            input = sanitizer?.Update(input)?.Sanitize() ?? input;

            IEnumerable<IRedactorMatch> mc = Matcher.Match(input);

            if (mc.Count() > 0)
            {
                foreach (IRedactorMatch m in mc)
                {
                    IRedactorMatch match = BeforeProcessMatchFunc?.Invoke(input, m) ?? m;

                    if (Validator?.Validate(match.Value) ?? true)
                    {
                        input = MatchProcessor.Process(input, match);

                        redactorResult.Logs.Add(new RedactorLogItem()
                        {
                            RangeStart = match.Index,
                            RangeEnd = match.Index + match.Length,
                            RedactorFriendlyName = FriendlyName,
                            SanitizedCharacters = sanitizer?.SanitizedCharacters() ?? Enumerable.Empty<CharacterSnapshot>()
                        });
                    }

                    input = AfterProcessMatchFunc?.Invoke(input, match) ?? input;
                }
            }

            input = sanitizer?.Update(input)?.Desanitize() ?? input;

            input = AfterProcessFunc?.Invoke(input) ?? input;

            redactorResult.Result = input;

            return redactorResult;
        }

        protected virtual ISanitizer CreateSanitizer(string input)
        {
            ISanitizer sanitizer = null;

            if (SanitizerType != null)
            {
                sanitizer = SanitizerFactory.GetSanitizer(SanitizerType);

                if (sanitizer is IRedactConfigurable<ISanitizer, ISanitizerOptions>)
                {
                    IRedactConfigurable<ISanitizer, ISanitizerOptions> c = (sanitizer as IRedactConfigurable<ISanitizer, ISanitizerOptions>);

                    if (c.GetConfiguration() == null)
                    {
                        sanitizer = c.Configure(SanitizerOptions);
                    }
                }
            }

            return sanitizer;
        }

        public IRedactor BeforeProcess(Func<string, string> function)
        {
            BeforeProcessFunc = function;

            return this;
        }

        public IRedactor AfterProcess(Func<string, string> function)
        {
            AfterProcessFunc = function;

            return this;
        }

        public IRedactor BeforeProcessMatch(Func<string, IRedactorMatch, IRedactorMatch> function)
        {
            BeforeProcessMatchFunc = function;

            return this;
        }

        public IRedactor UseValidator<T>() where T : IValidator
        {
            Validator = ValidatorFactory.GetValidator<T>();
            ValidatorType = typeof(T);

            return this;
        }

        public IRedactor UseMatchProcessor<T>() where T : IMatchProcessor
        {
            MatchProcessorType = typeof(T);
            MatchProcessor = MatchProcessorFactory.GetMatchProcessor<T>();

            return this;
        }

        public IRedactor UseMatchProcessor<T>(IRedactorOptions options) where T : IMatchProcessor
        {
            MatchProcessorType = typeof(T);
            MatchProcessor = MatchProcessorFactory.GetMatchProcessor<T>();
            MatchProcessor.Configure(options);

            return this;
        }

        public IRedactor UseMatcher<T>() where T : IMatcher
        {
            Matcher = MatcherFactory.GetMatcher<T>();
            MatcherType = typeof(T);

            return this;
        }

        public IRedactor UseMatcher<T>(IRedactorOptions options) where T : IMatcher
        {
            Matcher = MatcherFactory.GetMatcher<T>();
            Matcher.Configure(options);
            MatcherType = typeof(T);

            return this;
        }

        public IRedactor UseExpressionMatcher<T>(string expression) where T : IExpressionMatcher
        {
            Matcher = MatcherFactory.GetMatcher<T>();
            MatcherType = typeof(T);
            (Matcher as IExpressionMatcher).Expression = expression;

            return this;
        }

        public IRedactor UseExpressionMatcher<T>(string expression, IRedactorOptions options) where T : IExpressionMatcher
        {
            Matcher = MatcherFactory.GetMatcher<T>();
            MatcherType = typeof(T);
            (Matcher as IExpressionMatcher).Expression = expression;
            Matcher.Configure(options);

            return this;
        }

        public IRedactor UseSanitizer<T>() where T : ISanitizer
        {
            SanitizerType = typeof(T);

            return this;
        }

        public IRedactor UseSanitizer<T>(ISanitizerOptions options) where T : ISanitizer
        {
            SanitizerType = typeof(T);
            SanitizerOptions = options;

            return this;
        }

        public IRedactor UseFriendlyName(string friendlyName)
        {
            FriendlyName = friendlyName;

            return this;
        }        
    }
}