using System.Collections.Generic;

namespace RedactSharp.Redactors
{
    public class RedactorLogItem
    {
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
        public string RedactorFriendlyName { get; set; }
        public int Length { get { return RangeEnd - RangeStart; } }
        public IEnumerable<CharacterSnapshot> SanitizedCharacters { get; set; }
    }
}