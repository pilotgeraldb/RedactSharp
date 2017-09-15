using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public interface IRedactorCollection
    {
        List<IRedactor> Redactors { get; }
        string Redact(string input);
    }
}
