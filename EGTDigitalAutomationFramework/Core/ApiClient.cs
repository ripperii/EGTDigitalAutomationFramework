using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Core
{
    public sealed class ApiClient
    {
        private readonly RestClient _client;

        private ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        private static Lazy<ApiClient> _instance = null!;

        public static ApiClient Instance
        {
            get
            {
                _instance ??= new Lazy<ApiClient>(() => new ApiClient(FrameworkConfigProvider.Config.ApiUrl));
                return _instance.Value;
            }
        }

        public async Task<RestResponse> CreateUserAsync(UserData userData, string apiKey)
        {
            RestRequest req = new RestRequest("/api/users", Method.Post)
                .AddHeader("x-api-key", apiKey)
                .AddJsonBody(userData);

            return await _client.ExecuteAsync(req);
        }
    }
}
