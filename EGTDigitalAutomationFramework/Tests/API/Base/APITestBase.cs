using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.API.Base
{
    public abstract class APITestBase : IDisposable
    {
        protected readonly ILog Log;

        private readonly string _testName;
        protected APITestBase() 
        {
            Log = LogManager.GetLogger(GetType());

            _testName = GetType().Name;
            Log.Info($"=== START TEST {_testName} ===");
        }
        public void Dispose()
        {
            Log.Info($"=== END TEST {_testName} ===");
        }
    }
}
