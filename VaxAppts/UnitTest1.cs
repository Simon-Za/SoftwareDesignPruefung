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
            Assert.True(result);
        }
        [Fact]
        public void Test2()
        {
            string eMail = "ChristophFleigathsfuwa.de";
            bool result = VaxAppts.User.validateEmail(eMail);
            Assert.False(result);
        }
    }
}
