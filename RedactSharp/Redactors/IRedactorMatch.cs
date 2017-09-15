using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Redactors
{
    public interface IRedactorMatch
    {
        int Index { get; set; }
        int Length { get; set; }
        string Value { get; set; }
    }
}
