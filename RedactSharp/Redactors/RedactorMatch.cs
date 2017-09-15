using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors
{
    public class RedactorMatch : IRedactorMatch
    {
        public int Index { get; set; }
        public int Length { get; set; }
        public string Value { get; set; }
    }
}
