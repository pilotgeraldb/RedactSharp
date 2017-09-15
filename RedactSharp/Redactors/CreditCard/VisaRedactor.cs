using System;
using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class VisaRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public VisaRedactor()
        {
            UseValidator<LuhnValidator>();
            UseMatchProcessor<CreditCardMatchProcessor>();
            UseSanitizer<CreditCardSanitizer>();
            UseExpressionMatcher<RegularExpressionMatcher>(@"(?:4[0-9]{12}(?:[0-9]{3})?)");
            UseFriendlyName("Visa");
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