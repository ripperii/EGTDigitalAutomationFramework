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
        [Theory]
        [InlineData("Test User", "Automation Tester", "reqres-free-v1", HttpStatusCode.Created)]
        [InlineData(null, "Automation Tester", "reqres-free-v1", HttpStatusCode.Created)]
        [InlineData(null, null, "reqres-free-v1", HttpStatusCode.Created)]
        [InlineData("Ivan", "Operator na metla", "", HttpStatusCode.Unauthorized)]
        [InlineData("Gosho", "QA", "ewqdsa", HttpStatusCode.Forbidden)]
        public async Task CreateUser(string? name, string? job, string apiKey, HttpStatusCode expected)
        {
            RestResponse res = await ApiClient.Instance.CreateUserAsync(new UserData()
            {
                Name = name,
                Job = job
            }, apiKey);
            CreateUserAssert.AssertCreateUser(name, job, expected, res);
        }
    }
}
