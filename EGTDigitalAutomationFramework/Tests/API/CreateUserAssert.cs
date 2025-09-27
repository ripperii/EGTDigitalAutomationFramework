using EGTDigitalAutomationFramework.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.API
{
    internal static class CreateUserAssert
    {
        public static void AssertCreateUser(string? name, string? job, HttpStatusCode expected, RestResponse res)
        {
            Assert.Equal(expected, res.StatusCode);
            Assert.NotNull(res.Content);
            UserResponseData data = JsonConvert.DeserializeObject<UserResponseData>(res.Content)
                            ?? throw new InvalidOperationException("Deserialization failed");
            switch (expected)
            {
                case HttpStatusCode.Created:
                    {
                        Assert.Equal(name, data.Name);
                        Assert.Equal(job, data.Job);

                        Assert.False(string.IsNullOrWhiteSpace(data.Id));
                        Assert.False(string.IsNullOrWhiteSpace(data.CreatedAt));
                        break;
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        Assert.Equal("Missing API key", data.Error);
                        break;
                    }
                case HttpStatusCode.Forbidden:
                    {
                        Assert.Equal("Invalid or inactive API key", data.Error);
                        break;
                    }
                case HttpStatusCode.BadRequest:
                    {
                        Assert.Equal("Invalid Json", data.Error);
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid expected result!");
                    }
            }
        }
    }
}
