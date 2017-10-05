using RedactSharp.Redactors.SocialSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RedactSharpTests
{
    public class SocialSecurityRedactorTests
    {
        [Theory]
        [InlineData("111-11-1111", "***-**-****")]
        public void ShouldRedactSocialSecurityNumbers(string input, string expectedResult)
        {
            string result = new SocialSecurityRedactor()
                .Redact(input)
                .Result;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
    }
}
