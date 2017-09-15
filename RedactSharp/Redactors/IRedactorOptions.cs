using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public interface IRedactorOptions
    {
        char RedactCharacter { get; set; }
    }
}