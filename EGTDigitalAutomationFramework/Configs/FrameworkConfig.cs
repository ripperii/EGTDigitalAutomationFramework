using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Configs
{
    public class FrameworkConfig
    {
        public required string Browser {  get; set; }
        public bool Headless { get; set; }
        public float SlowMo {  get; set; }
        public required string BaseUrl { get; set; }
        public required string ApiUrl { get; set; }
        public required string ApiKey { get; set; }
        public required int ViewportWidth { get; set; }
        public required int ViewportHeight { get; set; }
    }
}
