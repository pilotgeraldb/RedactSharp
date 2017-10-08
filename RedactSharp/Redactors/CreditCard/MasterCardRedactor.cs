using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class MasterCardRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public MasterCardRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>();
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"((5[1-5]\d{4}|677189)\d{10})");
            this.UseFriendlyName("MasterCard");
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