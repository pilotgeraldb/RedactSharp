using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedactSharp.Redactors;
using Xunit;

namespace RedactSharpTests
{
    public class MatchProcessorTests
    {
        [Fact]
        public void ShouldProcessMatch()
        {
            string result = new MatchProcessor()
                .Process("12345678901234567890", new RedactorMatch()
                {
                    Index = 0,
                    Length = 10,
                    Value = "1234567890"
                });

            Assert.Equal("**********1234567890", result);
        }

        [Fact]
        public void MustSetConfiguration()
        {
            MatchProcessor m = new MatchProcessor();

            m.Configure(new RedactorOptions() { RedactCharacter = '&' });

            Assert.NotNull(m.Options);
            Assert.NotNull(m.Options.RedactCharacter);
            Assert.Equal('&', m.Options.RedactCharacter);
        }

        [Fact]
        public void MustGetConfiguration()
        {
            MatchProcessor m = new MatchProcessor();
            m.Configure(new RedactorOptions() { RedactCharacter = '&' });

            IRedactorOptions options = m.GetConfiguration();

            Assert.NotNull(options);
            Assert.NotNull(options.RedactCharacter);
            Assert.Equal('&', options.RedactCharacter);
        }
    }
}
