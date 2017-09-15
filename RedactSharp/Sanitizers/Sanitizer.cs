using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactSharp.Sanitizers
{
    public class Sanitizer : ISanitizer, IRedactConfigurable<ISanitizer, ISanitizerOptions>
    {
        private SanitizerOptions Options { get; set; }
        private IEnumerable<CharacterSnapshot> CharacterSnapshots { get; set; }
        private string Input { get; set; }

        public Sanitizer()
        {
            Options = new SanitizerOptions();
        }

        public ISanitizer Configure(ISanitizerOptions options)
        {
            Options = (SanitizerOptions)options;

            return this;
        }

        public ISanitizer Update(string input)
        {
            Input = input;

            return this;
        }

        public string Sanitize()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                return Input;
            }

            if (Options.InvalidCharacters == null || !Options.InvalidCharacters.Any())
            {
                return Input;
            }

            CharacterSnapshots = Enumerable.Empty<CharacterSnapshot>();

            CharacterSnapshots = Input.RemoveCharacters(Options.InvalidCharacters);

            Input = Input.RemoveCharacters(CharacterSnapshots);

            return Input;
        }

        public string Desanitize()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                return Input;
            }

            if (CharacterSnapshots == null || !CharacterSnapshots.Any())
            {
                return Input;
            }

            Input = Input.InsertCharacters(CharacterSnapshots);

            return Input;
        }

        public IEnumerable<CharacterSnapshot> SanitizedCharacters()
        {
            return CharacterSnapshots;
        }

        public ISanitizerOptions GetConfiguration()
        {
            return Options;
        }
    }
}
