using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors.CreditCard
{
    public static class CreditCardRedactors
    {
        public static IEnumerable<IRedactor> All()
        {
            IList<IRedactor> Redactors = new List<IRedactor>();
            Redactors.Add(new VisaRedactor());
            Redactors.Add(new MasterCardRedactor());
            Redactors.Add(new DiscoverRedactor());
            Redactors.Add(new AmericanExpressRedactor());
            Redactors.Add(new DinersClubRedactor());
            Redactors.Add(new JCBRedactor());
            Redactors.Add(new SwitchRedactor());
            Redactors.Add(new SoloRedactor());
            Redactors.Add(new DankortRedactor());
            Redactors.Add(new MaestroRedactor());
            Redactors.Add(new ForbrugsforeningenRedactor());
            Redactors.Add(new LaserRedactor());

            return Redactors;
        }
    }
}
