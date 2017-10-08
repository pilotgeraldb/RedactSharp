using RedactSharp.Sanitizers;
using RedactSharp.Validators;
using System;

namespace RedactSharp.Redactors
{
    internal static class IRedactorExtensions
    {
        public static IRedactor BeforeProcess(this RedactorProcessEvents obj, Func<string, string> function)
        {
            obj.BeforeProcess = function;

            return obj;
        }

        public static IRedactor AfterProcess(this RedactorProcessEvents obj, Func<string, string> function)
        {
            obj.AfterProcess = function;

            return obj;
        }

        public static IRedactor BeforeProcessMatch(this RedactorProcessEvents obj, Func<string, IRedactorMatch, IRedactorMatch> function)
        {
            obj.BeforeProcessMatch = function;

            return obj;
        }

        public static IRedactor UseValidator<T>(this RedactorProcess obj) where T : IValidator
        {
            obj.Validator = Activator.CreateInstance<T>();
            obj.ValidatorType = typeof(T);

            return obj;
        }

        public static IRedactor UseMatchProcessor<T>(this RedactorProcess obj) where T : IMatchProcessor
        {
            obj.MatchProcessorType = typeof(T);
            obj.MatchProcessor = Activator.CreateInstance<T>();

            return obj;
        }

        public static IRedactor UseMatchProcessor<T>(this RedactorProcess obj, IRedactorOptions options) where T : IMatchProcessor
        {
            obj.MatchProcessorType = typeof(T);
            obj.MatchProcessor = Activator.CreateInstance<T>();
            obj.MatchProcessor.Configure(options);

            return obj;
        }

        public static IRedactor UseMatcher<T>(this RedactorProcess obj) where T : IMatcher
        {
            obj.Matcher = Activator.CreateInstance<T>();
            obj.MatcherType = typeof(T);

            return obj;
        }

        public static IRedactor UseMatcher<T>(this RedactorProcess obj, IRedactorOptions options) where T : IMatcher
        {
            obj.Matcher = Activator.CreateInstance<T>();
            obj.Matcher.Configure(options);
            obj.MatcherType = typeof(T);

            return obj;
        }

        public static IRedactor UseExpressionMatcher<T>(this RedactorProcess obj, string expression) where T : IExpressionMatcher
        {
            obj.Matcher = Activator.CreateInstance<T>();
            obj.MatcherType = typeof(T);
            (obj.Matcher as IExpressionMatcher).Expression = expression;

            return obj;
        }

        public static IRedactor UseExpressionMatcher<T>(this RedactorProcess obj, string expression, IRedactorOptions options) where T : IExpressionMatcher
        {
            obj.Matcher = Activator.CreateInstance<T>();
            obj.MatcherType = typeof(T);
            (obj.Matcher as IExpressionMatcher).Expression = expression;
            obj.Matcher.Configure(options);

            return obj;
        }

        public static IRedactor UseSanitizer<T>(this RedactorProcess obj) where T : ISanitizer
        {
            obj.SanitizerType = typeof(T);

            return obj;
        }

        public static IRedactor UseSanitizer<T>(this RedactorProcess obj, ISanitizerOptions options) where T : ISanitizer
        {
            obj.SanitizerType = typeof(T);
            obj.SanitizerOptions = options;

            return obj;
        }

        public static IRedactor UseFriendlyName(this IRedactor obj, string friendlyName)
        {
            obj.FriendlyName = friendlyName;

            return obj;
        }
    }
}
