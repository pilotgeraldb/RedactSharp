using System;
using System.Text.RegularExpressions;

namespace RedactSharp.Redactors
{
    public class MatchProcessor : IMatchProcessor, IRedactConfigurable<IMatchProcessor, IRedactorOptions>
    {
        public IRedactorOptions Options { get; private set; }

        public MatchProcessor()
        {
            Options = new RedactorOptions();
        }

        public string Process(string input, IRedactorMatch m)
        {
            for (int p = 0; p < m.Length; p++)
            {
                input = input.Remove(m.Index + p, 1);
                input = input.Insert(m.Index + p, Options.RedactCharacter.ToString());
            }

            return input;
        }

        public IMatchProcessor Configure(IRedactorOptions options)
        {
            Options = options;

            return this;
        }
        public IRedactorOptions GetConfiguration()
        {
            return Options;
        }
    }
}