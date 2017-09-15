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
        IValidator Validator { get; set; }
        IMatchProcessor MatchProcessor { get; set; }
        IMatcher Matcher { get; set; }
        IRedactorResult Redact(string input);
    }
}
