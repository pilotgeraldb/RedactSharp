using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RedactSharp.Sanitizers;
using RedactSharp.Validators;

namespace RedactSharp.Redactors.SocialSecurity
{
    public class SocialSecurityRedactor : AbstractRedactor
    {
        public SocialSecurityRedactor()
        {
            UseValidator<SocialSecurityNumberValidator>();
            //UseExpressionMatcher<RegularExpressionMatcher>(@"(\s{1,})(\d{3}-?\d{2}-?\d{4})(\s{1,})");
            UseExpressionMatcher<RegularExpressionMatcher>(@"(\d{3}-?\d{2}-?\d{4})");
            UseSanitizer<SocialSecuritySanitizer>(new SanitizerOptions()
            {
                InvalidCharacters = new char[] { '-', ' ' }
            });
            UseFriendlyName("SocialSecurity");
            //BeforeProcessMatch((x,y) => 
            //{
            //    return new RedactorMatch()
            //    {
            //        Index = y.Index,
            //        Length = y.Length,
            //        Value = y.Value.Trim()
            //    }; 
            //});
        }
    }

    public class SocialSecurityNumberValidator : IValidator
    {
        public bool Validate(string input)
        {
            Regex ssnRegex = new Regex(@"^((?!219-09-9999|078-05-1120)(?!666|000|9\d{2})\d{3}-(?!00)\d{2}-(?!0{4})\d{4})|((?!219 09 9999|078 05 1120)(?!666|000|9\d{2})\d{3} (?!00)\d{2} (?!0{4})\d{4})|((?!219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4})$");

            if (ssnRegex.Matches(input).Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
