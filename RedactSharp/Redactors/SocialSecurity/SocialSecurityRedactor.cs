using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedactSharp.Sanitizers;

namespace RedactSharp.Redactors.SocialSecurity
{
    public class SocialSecurityRedactor : AbstractRedactor
    {
        public SocialSecurityRedactor()
        {
            this.UseValidator<SocialSecurityNumberValidator>();
            //UseExpressionMatcher<RegularExpressionMatcher>(@"(\s{1,})(\d{3}-?\d{2}-?\d{4})(\s{1,})");
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"(\d{3}-?\d{2}-?\d{4})");
            this.UseSanitizer<SocialSecuritySanitizer>(new SanitizerOptions()
            {
                InvalidCharacters = new char[] { '-', ' ' }
            });
            this.UseFriendlyName("SocialSecurity");
        }
    }
}
