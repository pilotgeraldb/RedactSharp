using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class SoloRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public SoloRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>();
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"6767\d{12}(\d{2,3})?");
            this.UseFriendlyName("Solo");
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