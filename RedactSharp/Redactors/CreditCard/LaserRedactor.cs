using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class LaserRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public LaserRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>();
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"(6304|6706|6709|6771(?!89))\d{8}(\d{4}|\d{6,7})?");
            this.UseFriendlyName("Laser");
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