using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class ForbrugsforeningenRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public ForbrugsforeningenRedactor()
        {
            UseValidator<LuhnValidator>();
            UseMatchProcessor<CreditCardMatchProcessor>();
            UseSanitizer<CreditCardSanitizer>();
            UseExpressionMatcher<RegularExpressionMatcher>(@"600722\d{10}$");
            UseFriendlyName("ForbrugsForeningen");
        }

        public AbstractRedactor Configure(IRedactorOptions options)
        {
            Options = (CreditCardRedactorOptions)options;

            return this;
        }

        public IRedactorOptions GetConfiguration()
        {
            return Options;
        }
    }
}