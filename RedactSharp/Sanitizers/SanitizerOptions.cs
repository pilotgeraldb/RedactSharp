using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Sanitizers
{
    public class SanitizerOptions : ISanitizerOptions
    {
        public IEnumerable<char> InvalidCharacters { get; set; }
    }
}
