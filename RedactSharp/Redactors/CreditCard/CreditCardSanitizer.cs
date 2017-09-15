using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedactSharp.Sanitizers;

namespace RedactSharp.Redactors.CreditCard
{
    public class CreditCardSanitizer : ISanitizer, IRedactConfigurable<ISanitizer, ISanitizerOptions>
    {
        private SanitizerOptions Options { get; set; }
        private IEnumerable<CharacterSnapshot> CharacterSnapshots { get; set; }
        private string Input { get; set; }

        public CreditCardSanitizer()
        {
            Options = new SanitizerOptions();
            Options.InvalidCharacters = new char[] { '-', ' ' };
        }

        public ISanitizer Configure(ISanitizerOptions options)
        {
            Options = (SanitizerOptions)options;

            return this;
        }

        public string Sanitize()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                return Input;
            }

            if (Options == null || Options.InvalidCharacters == null || !Options.InvalidCharacters.Any())
            {
                return Input;
            }

            CharacterSnapshots = Enumerable.Empty<CharacterSnapshot>();

            CharacterSnapshots = Input.RemoveCharacters(Options.InvalidCharacters);

            Input = Input.RemoveCharacters(CharacterSnapshots);

            return Input;
        }

        public ISanitizer Update(string input)
        {
            Input = input;

            return this;
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
