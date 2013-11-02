using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Core;

namespace Umbrella.BL.Test.TestUtils
{
    class TestAuthenticationManager : IAuthenticationManager 
    {
        public bool IsVIAcodeUser(string userName, string password)
        {
            return true;
        }
    }
}
