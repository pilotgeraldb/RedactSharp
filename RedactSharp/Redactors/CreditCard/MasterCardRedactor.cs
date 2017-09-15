using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class MasterCardRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public MasterCardRedactor()
        {
            UseValidator<LuhnValidator>();
            UseMatchProcessor<CreditCardMatchProcessor>();
            UseSanitizer<CreditCardSanitizer>();
            UseExpressionMatcher<RegularExpressionMatcher>(@"((5[1-5]\d{4}|677189)\d{10})");
            UseFriendlyName("MasterCard");
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