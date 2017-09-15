using System;

namespace RedactSharp.Redactors.CreditCard
{
    public class CreditCardMatchProcessor : IMatchProcessor, IRedactConfigurable<IMatchProcessor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; private set; }

        public CreditCardMatchProcessor()
        {
            Options = new CreditCardRedactorOptions();
        }

        public string Process(string input, IRedactorMatch m)
        {
            int startIndex = Options.ExposeFirst;
            int length = m.Length - Options.ExposeLast;

            for (int p = startIndex; p < length; p++)
            {
                input = input.Remove(m.Index + p, 1);
                input = input.Insert(m.Index + p, Options.RedactCharacter.ToString());
            }

            return input;
        }

        public IMatchProcessor Configure(IRedactorOptions options)
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
