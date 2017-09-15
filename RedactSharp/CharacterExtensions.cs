using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedactSharp
{
    internal static class CharacterExtensions
    {
        public static string InsertCharacters(this string input, IEnumerable<CharacterSnapshot> snapshots)
        {
            if (snapshots == null || !snapshots.Any())
            {
                return input;
            }

            StringBuilder sb = new StringBuilder();

            List<CharacterSnapshot> sList = snapshots.OrderBy(x => x.Index).ToList();

            for (int i = 0; i < sList.Count(); i++)
            {
                CharacterSnapshot s = sList[i];

                input = input.Insert((int)s.Index, s.Character.ToString());
            }

            return input;
        }

        public static string RemoveCharacters(this string input, IEnumerable<CharacterSnapshot> snapshots)
        {
            if (snapshots == null || !snapshots.Any())
            {
                return input;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (!snapshots.Where(x => x.Character == c && x.Index == i).Any())
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public static IEnumerable<CharacterSnapshot> RemoveCharacters(this string input, IEnumerable<char> charactersToRemove)
        {
            if (input == null)
            {
                return Enumerable.Empty<CharacterSnapshot>();
            }

            List<CharacterSnapshot> result = new List<CharacterSnapshot>();

            List<char> removeChars = charactersToRemove.ToList();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (removeChars.Contains(c))
                {
                    result.Add(new CharacterSnapshot(i, c));
                }
            }

            return result;
        }
    }
}