using EGTDigitalAutomationFramework.Tests.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.API
{

    public class CreateUserTest : APITestBase
    {
        [Theory]
        [InlineData("Test User", "Automation Tester", true)]
        public void CreateUser(String name, String job, bool expected)
        {
           
        }
    }
}
