using System;
using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class DankortRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public DankortRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>();
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"5019\d{12}");
            this.UseFriendlyName("Dankort");
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