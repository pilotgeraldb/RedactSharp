using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors.Telephone
{
    public class TelephoneRedactor : AbstractRedactor
    {
        public TelephoneRedactor()
        {
            this.UseExpressionMatcher<RegularExpressionMatcher>(@"(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?");
            this.UseSanitizer<TelephoneSanitizer>();
            this.UseFriendlyName("Telephone");
        }
    }
}
