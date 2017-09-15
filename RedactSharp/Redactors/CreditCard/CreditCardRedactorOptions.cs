using System.Collections.Generic;

namespace RedactSharp.Redactors.CreditCard
{
    public class CreditCardRedactorOptions : IRedactorOptions
    {
        public CreditCardRedactorOptions()
        {
            RedactCharacter = '#';//'▇';
            ExposeFirst = 6;
            ExposeLast = 4;
        }

        public char RedactCharacter { get; set; }
        public int ExposeFirst { get; set; }
        public int ExposeLast { get; set; }
    }
}
