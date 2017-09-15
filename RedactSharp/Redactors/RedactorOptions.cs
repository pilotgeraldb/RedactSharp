using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public class RedactorOptions : IRedactorOptions
    {
        public RedactorOptions()
        {
            RedactCharacter = '*';
        }

        public char RedactCharacter { get; set; }
    }
}