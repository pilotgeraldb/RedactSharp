using System;
using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class AmericanExpressRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public AmericanExpressRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>(new Sanitizers.SanitizerOptions());
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"3[47]\d{13}");
            this.UseFriendlyName("AmericanExpress");
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