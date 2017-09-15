using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public interface IRedactorResult
    {
        IList<CharacterSnapshot> RemovedCharacters { get; set; }
        IList<RedactorLogItem> Logs { get; set; }
        string Result { get; set; }
    }
}