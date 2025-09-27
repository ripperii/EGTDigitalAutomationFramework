using Allure.Net.Commons;
using Allure.Xunit.Attributes;
using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Core;
using EGTDigitalAutomationFramework.Models;
using EGTDigitalAutomationFramework.Tests.API.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.API
{
    
    public class CreateUserTest : APITestBase
    {
        
        [Theory(DisplayName = "Verify Creation of user")]
        [InlineData("Test User", "Automation Tester", "reqres-free-v1", HttpStatusCode.Created)]
        [InlineData(null, "Automation Tester", "reqres-free-v1", HttpStatusCode.Created)]
        [InlineData(null, null, "reqres-free-v1", HttpStatusCode.Created)]
        [InlineData("Ivan", "Operator na metla", "", HttpStatusCode.Unauthorized)]
        [InlineData("Gosho", "QA", "ewqdsa", HttpStatusCode.Forbidden)]
        [AllureDescription("This test verifies that a valid/invalid request for user creation has a successfull expected result.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke", "Login")]
        [AllureOwner("QA-Team")]

        public async Task CreateUser(string? name, string? job, string apiKey, HttpStatusCode expected)
        {
            Console.WriteLine("Create User Test");

            RestResponse res = await ApiClient.Instance.CreateUserAsync(new UserData()
            {
                Name = name,
                Job = job
            }, apiKey);
            CreateUserAssert.AssertCreateUser(name, job, expected, res);
        }
    }
}
