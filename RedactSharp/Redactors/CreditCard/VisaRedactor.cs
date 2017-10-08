using System;
using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class VisaRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public VisaRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>();
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"(?:4[0-9]{12}(?:[0-9]{3})?)");
            this.UseFriendlyName("Visa");
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