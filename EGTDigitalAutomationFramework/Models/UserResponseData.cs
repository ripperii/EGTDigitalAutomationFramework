using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Models
{
    public class UserResponseData
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}
