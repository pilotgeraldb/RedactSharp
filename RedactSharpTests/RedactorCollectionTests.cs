using RedactSharp.Redactors;
using RedactSharp.Redactors.SocialSecurity;
using RedactSharp.Redactors.Telephone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RedactSharpTests
{
    public class RedactorCollectionTests
    {
        public RedactorCollectionTests()
        {

        }

        [Fact]
        public void ShouldHandleNullInput()
        {
            var rc = new RedactorCollection();

            rc.Redactors.Add(new TelephoneRedactor());
            rc.Redactors.Add(new SocialSecurityRedactor());

            string output = rc.Redact(null);

            Assert.Null(output);
        }

        [Fact]
        public void ShouldHandleEmptyInput()
        {
            var rc = new RedactorCollection();

            rc.Redactors.Add(new TelephoneRedactor());
            rc.Redactors.Add(new SocialSecurityRedactor());

            string output = rc.Redact("");

            Assert.Equal("", output);
        }

        [Fact]
        public void ShouldHandleWhitespaceInput()
        {
            var rc = new RedactorCollection();

            rc.Redactors.Add(new TelephoneRedactor());
            rc.Redactors.Add(new SocialSecurityRedactor());

            string output = rc.Redact("       ");

            Assert.Equal("       ", output);
        }

        [Fact]
        public void ShouldAddMultipleRedactors()
        {
            var rc = new RedactorCollection();

            rc.Redactors.Add(new TelephoneRedactor());
            rc.Redactors.Add(new SocialSecurityRedactor());

            Assert.Equal(2, rc.Redactors.Count);
        }


        [Fact]
        public void ShouldExecuteMultipleRedactors()
        {
            var rc = new RedactorCollection();
            
            rc.Redactors.Add(new TelephoneRedactor());
            rc.Redactors.Add(new SocialSecurityRedactor());

            string output = rc.Redact("my telephone number is 1-555-555-5555 and my social is 111-11-1111");

            Assert.NotNull(output);
            Assert.Equal("my telephone number is *-***-***-**** and my social is ***-**-****", output);
        }
    }
}
