using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedactSharp.Validators;

namespace RedactSharp.Redactors
{
    public interface IRedactor
    {
        string FriendlyName { get; set; }
        IRedactorResult Redact(string input);
    }
}
