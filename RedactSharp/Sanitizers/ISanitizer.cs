using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Sanitizers
{
    public interface ISanitizer
    {
        IEnumerable<CharacterSnapshot> SanitizedCharacters();
        string Sanitize();
        string Desanitize();
        ISanitizer Update(string input);
    }
}
