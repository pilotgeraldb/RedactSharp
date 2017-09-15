using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public sealed class RedactorResult : IRedactorResult
    {
        public RedactorResult()
        {
            Logs = new List<RedactorLogItem>();
            RemovedCharacters = new List<CharacterSnapshot>();
        }

        public IList<CharacterSnapshot> RemovedCharacters { get; set; }
        public IList<RedactorLogItem> Logs { get; set; } 
        public string Result { get; set; }
    }
}
