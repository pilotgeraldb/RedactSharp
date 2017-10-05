using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RedactSharp.Redactors;

namespace RedactSharpTests
{
    public class RegularExpressionMatcherTests
    {
        [Fact]
        public void MustMatchInput()
        {
            string input = "the brown dog jumped over the fence";

            IEnumerable<IRedactorMatch> matches = new RegularExpressionMatcher(@"brown dog")
                .Match(input);

            Assert.NotNull(matches);
            Assert.NotEmpty(matches);
            Assert.Equal(4, matches.ToList()[0].Index);
            Assert.Equal(9, matches.ToList()[0].Length);
            Assert.Equal("brown dog", matches.ToList()[0].Value);
        }

        [Fact]
        public void MustSetConfiguration()
        {
            RegularExpressionMatcher rem = new RegularExpressionMatcher();

            rem.Configure(new RedactorOptions() { RedactCharacter = '&' });

            Assert.NotNull(rem.Options);
            Assert.NotNull(rem.Options.RedactCharacter);
            Assert.Equal('&', rem.Options.RedactCharacter);
        }

        [Fact]
        public void MustGetConfiguration()
        {
            RegularExpressionMatcher rem = new RegularExpressionMatcher();
            rem.Configure(new RedactorOptions() { RedactCharacter = '&' });

            IRedactorOptions options = rem.GetConfiguration();

            Assert.NotNull(options);
            Assert.NotNull(options.RedactCharacter);
            Assert.Equal('&', options.RedactCharacter);
        }
    }
}
