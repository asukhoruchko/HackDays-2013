using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbrella.BL.Services;
using Umbrella.BL.Test.TestUtils;

namespace Umbrella.BL.Test
{
    [TestClass]
    public class OperationServiceTest
    {
        [TestMethod]
        public void TestGetTaken()
        {
            var operationService = new OperationService(new TestSessionFactory());

            var result = operationService.GetTaken();
        }

        [TestMethod]
        public void TestAddOperation()
        {
            var userService = new UserService(new TestAuthenticationManager(), new TestSessionFactory());
            var user = userService.Authenticate("pvasiliev", "");

            var operationService = new OperationService(new TestSessionFactory());
            operationService.DoTake(user);
        }
    }
}
