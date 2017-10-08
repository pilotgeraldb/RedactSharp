using System;
using System.Collections.Generic;
using System.Linq;
using RedactSharp.Sanitizers;
using RedactSharp.Validators;

namespace RedactSharp.Redactors
{
    internal interface RedactorProcess : IRedactor
    {
        IValidator Validator { get; set; }
        Type ValidatorType { get; set; }

        IMatchProcessor MatchProcessor { get; set; }
        Type MatchProcessorType { get; set; }

        IMatcher Matcher { get; set; }
        Type MatcherType { get; set; }

        Type SanitizerType { get; set; }
        ISanitizerOptions SanitizerOptions { get; set; }
    }

    internal interface RedactorProcessEvents : IRedactor
    {
        Func<string, string> BeforeProcess { get; set; }
        Func<string, string> AfterProcess { get; set; }
        Func<string, IRedactorMatch, IRedactorMatch> BeforeProcessMatch { get; set; }
        Func<string, IRedactorMatch, string> AfterProcessMatch { get; set; }
    }

    public abstract class AbstractRedactor : IRedactor, RedactorProcess, RedactorProcessEvents
    {
        public string FriendlyName { get; set; }

        public IValidator Validator { get; set; }
        public IMatchProcessor MatchProcessor { get; set; }
        public IMatcher Matcher { get; set; }

        public Type ValidatorType { get; set; }
        public Type MatcherType { get; set; }
        public Type MatchProcessorType { get; set; }

        public Type SanitizerType { get; set; } 
        public ISanitizerOptions SanitizerOptions { get; set; }

        public Func<string, string> BeforeProcess { get; set; }
        public Func<string, string> AfterProcess { get; set; }
        public Func<string, IRedactorMatch, IRedactorMatch> BeforeProcessMatch { get; set; }
        public Func<string, IRedactorMatch, string> AfterProcessMatch { get; set; }

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

            input = BeforeProcess?.Invoke(input) ?? input;

            ISanitizer sanitizer = CreateSanitizer(input);

            input = sanitizer?.Update(input)?.Sanitize() ?? input;

            IEnumerable<IRedactorMatch> mc = Matcher.Match(input);

            if (mc.Count() > 0)
            {
                foreach (IRedactorMatch m in mc)
                {
                    IRedactorMatch match = BeforeProcessMatch?.Invoke(input, m) ?? m;

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

                    input = AfterProcessMatch?.Invoke(input, match) ?? input;
                }
            }

            input = sanitizer?.Update(input)?.Desanitize() ?? input;

            input = AfterProcess?.Invoke(input) ?? input;

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
    }
}