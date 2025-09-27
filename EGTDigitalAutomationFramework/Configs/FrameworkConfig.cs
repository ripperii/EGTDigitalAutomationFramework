using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Configs
{
    public class FrameworkConfig
    {
        public required string[] Browsers {  get; set; }
        public bool Headless { get; set; }
        public required string BaseUrl { get; set; }
        public required string ApiUrl { get; set; }
        public required string ApiKey { get; set; }
    }
}
