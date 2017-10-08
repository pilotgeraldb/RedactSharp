using System;
using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class DinersClubRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public DinersClubRedactor()
        {
            this.UseValidator<LuhnValidator>();
            this.UseMatchProcessor<CreditCardMatchProcessor>();
            this.UseSanitizer<CreditCardSanitizer>();
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"3(0[0-5]|[68]\d)\d{11}");
            this.UseFriendlyName("DinersClub");
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