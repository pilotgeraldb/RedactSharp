using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Validators
{
    public interface IValidator
    {
        bool Validate(string input);
    }
}
