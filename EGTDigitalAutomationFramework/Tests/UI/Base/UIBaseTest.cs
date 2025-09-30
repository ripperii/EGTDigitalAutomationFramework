using log4net;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.UI.Base
{
    public abstract class UIBaseTest : IDisposable
    {

        protected readonly ILog Log;

        private readonly string _testName;

        protected UIBaseTest()
        {
            Log = LogManager.GetLogger(GetType());

            _testName = GetType().Name;

            Log.Info("=== STAR TRACE ===");

await 
            Log.Info($"=== START TEST {_testName} ===");
        }

        public void Dispose()
        {
            Log.Info($"=== END TEST {_testName} ===");
        }
    }
}
