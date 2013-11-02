using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbrella.BL.Services;
using Umbrella.BL.Test.TestUtils;

namespace Umbrella.BL.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void AuthenticateTest()
        {
            var userService = new UserService(
                new TestAuthenticationManager(),
                new TestSessionFactory());

            var result = userService.Authenticate("pvasiliev", "blah");

            Assert.AreEqual(result.Login, "pvasiliev");
            Assert.AreEqual(result.LastName, "vasiliev");
            Assert.AreNotEqual(result.Id, 0);
        }
    }
}
