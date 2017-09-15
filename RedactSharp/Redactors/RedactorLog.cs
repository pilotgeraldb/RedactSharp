using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public static class RedactorLog
    {
        public static List<RedactorLogItem> Logs { get; set; } = new List<RedactorLogItem>();
    }
}