using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Models
{
    public class UserData
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }
    }
}
