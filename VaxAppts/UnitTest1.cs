using System;
using Xunit;

namespace VaxAppts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string eMail = "Christoph.Fleig@hs-furtwangen.de";
            bool result = VaxAppts.User.validateEmail(eMail);
            Assert.True(result, eMail + " is a valid E-Mail");
        }
        [Fact]
        public void Test2()
        {
            string eMail = "ChristophFleigathsfuwa.de";
            bool result = VaxAppts.User.validateEmail(eMail);
            Assert.False(result, eMail + " not a valid E-Mail");
        }
    }
}
