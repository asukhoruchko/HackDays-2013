using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbrella.BL.Services;
using Umbrella.BL.Test.TestUtils;
using Umbrella.Core;

namespace Umbrella.BL.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void AuthenticateTest()
        {
            var userService = new UserService(
                new AuthenticationManager(),
                new TestSessionFactory());

            var result = userService.Authenticate("asoukhoruchko", "6j%HG$f3");

            Assert.AreEqual(result.Login, "asoukhoruchko");
            Assert.AreEqual(result.LastName, "soukhoruchko");
            Assert.AreNotEqual(result.Id, 0);
        }
    }
}
