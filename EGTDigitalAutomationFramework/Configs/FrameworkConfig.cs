using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Configs
{
    public class FrameworkConfig
    {
        public bool Headless { get; set; }
        public required string BaseUrl { get; set; }
        public required string ApiUrl { get; set; }
    }
}
