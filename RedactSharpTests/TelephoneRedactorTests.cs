using RedactSharp.Redactors.Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RedactSharpTests
{
    public class TelephoneRedactorTests
    {
        [Theory]
        [InlineData("1-555-555-5555", "*-***-***-****")]
        [InlineData("1-(555)-555-5555", "*-(***)-***-****")]
        public void ShouldRedactTelephoneNumbers(string input, string expectedResult)
        {
            string result = new TelephoneRedactor()
                .Redact(input)
                .Result;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
    }
}
