namespace RedactSharp
{
    public class CharacterSnapshot
    {
        public CharacterSnapshot(long index, char character)
        {
            Index = index;
            Character = character;
        }

        public long Index { get; private set; }
        public char Character { get; private set; }
    }
}