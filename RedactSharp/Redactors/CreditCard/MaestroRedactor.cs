using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class MaestroRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public MaestroRedactor()
        {
            UseValidator<LuhnValidator>();
            UseMatchProcessor<CreditCardMatchProcessor>();
            UseSanitizer<CreditCardSanitizer>();
            UseExpressionMatcher<RegularExpressionMatcher>(@"(5[06-8]|6\d)\d{10,17}");
            UseFriendlyName("Maestro");
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