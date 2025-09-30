using Allure.Net.Commons;
using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Core;
using EGTDigitalAutomationFramework.Tests.UI.Base;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            _testName = GetType().Name;
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            Log = LogManager.GetLogger(typeof(UIBaseTest));
            _testName = GetType().Name;
            Log.Info($"=== START TEST {_testName} ===");
        }
        public void Dispose()
        {
            Log.Info($"=== END TEST {_testName} ===");
        }
    }
}
