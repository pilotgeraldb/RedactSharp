using RedactSharp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RedactSharpTests
{
    public class LuhnValidatorTests
    {
        [Theory]
        [InlineData("5105105105105100")]
        [InlineData("378282246310005")]
        [InlineData("371449635398431")]
        [InlineData("378734493671000")]
        [InlineData("5610591081018250")]
        [InlineData("30569309025904")]
        [InlineData("38520000023237")]
        [InlineData("6011111111111117")]
        [InlineData("6011000990139424")]
        [InlineData("3530111333300000")]
        [InlineData("3566002020360505")]
        [InlineData("5555555555554444")]
        [InlineData("4111111111111111")]
        [InlineData("4222222222222")]
        [InlineData("5019717010103742")]
        [InlineData("6331101999990016")]
        public void ShouldValidateCreditCardNumber(object value)
        {
            bool result = new LuhnValidator().Validate(value.ToString());

            Assert.Equal(true, result);
        }
    }
}
