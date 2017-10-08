using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RedactSharp.Redactors;
using RedactSharp.Redactors.CreditCard;
using RedactSharp.Redactors.SocialSecurity;
using RedactSharp.Redactors.Telephone;

namespace RedactSharpTests
{
    public class AbstractRedactorTests
    {
        [Fact]
        public void ShouldRedactText()
        {
            StringBuilder input = new StringBuilder();
            
            input.Append(@"this is a credit card number 38520000023237.\n");
            input.Append(@"this is a credit card number 5105105105105100.\n");
            input.Append(@"this is a credit card number 378282246310005.\n");
            input.Append(@"this is a credit card number 371449635398431.\n");
            input.Append(@"this is a credit card number 378734493671000.\n");
            input.Append(@"this is a credit card number 5610591081018250.\n");
            input.Append(@"this is a credit card number 30569309025904.\n");
            input.Append(@"this is a credit card number 38520000023237.\n");
            input.Append(@"this is a credit card number 6011111111111117.\n");
            input.Append(@"this is a credit card number 6011000990139424.\n");
            input.Append(@"this is a credit card number 3530111333300000.\n");
            input.Append(@"this is a credit card number 3566002020360505.\n");
            input.Append(@"this is a credit card number 5555555555554444.\n");
            input.Append(@"this is a credit card number 4111111111111111.\n");
            input.Append(@"this is a credit card number 4222222222222.\n");
            input.Append(@"this is a credit card number 5019717010103742.\n");
            input.Append(@"this is a credit card number 6331101999990016.\n");
            input.Append(@"this is a social 111-11-1111.");
            input.Append(@"this is a phone number 1-(555)-555-1111");

            StringBuilder expectedOutput = new StringBuilder();

            expectedOutput.Append(@"this is a credit card number 385200####3237.\n");
            expectedOutput.Append(@"this is a credit card number 510510######5100.\n");
            expectedOutput.Append(@"this is a credit card number 378282#####0005.\n");
            expectedOutput.Append(@"this is a credit card number 371449#####8431.\n");
            expectedOutput.Append(@"this is a credit card number 378734#####1000.\n");
            expectedOutput.Append(@"this is a credit card number 561059######8250.\n");
            expectedOutput.Append(@"this is a credit card number 305693####5904.\n");
            expectedOutput.Append(@"this is a credit card number 385200####3237.\n");
            expectedOutput.Append(@"this is a credit card number 601111######1117.\n");
            expectedOutput.Append(@"this is a credit card number 601100######9424.\n");
            expectedOutput.Append(@"this is a credit card number 353011######0000.\n");
            expectedOutput.Append(@"this is a credit card number 356600######0505.\n");
            expectedOutput.Append(@"this is a credit card number 555555######4444.\n");
            expectedOutput.Append(@"this is a credit card number 411111######1111.\n");
            expectedOutput.Append(@"this is a credit card number 422222###2222.\n");
            expectedOutput.Append(@"this is a credit card number 501971######3742.\n");
            expectedOutput.Append(@"this is a credit card number 633110######0016.\n");
            expectedOutput.Append(@"this is a social ***-**-****.");
            expectedOutput.Append(@"this is a phone number *-(***)-***-****");

            RedactorCollection c = new RedactorCollection();

            c.Redactors.AddRange(CreditCardRedactors.All());
            c.Redactors.Add(new SocialSecurityRedactor());
            c.Redactors.Add(new TelephoneRedactor());

            string ouput = c.Redact(input.ToString());

            Assert.Equal(expectedOutput.ToString(), ouput);
        }
    }
}
