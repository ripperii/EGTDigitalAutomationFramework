using Allure.Net.Commons;
using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Core;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.UI.Base
{
    public abstract class UIBaseTest : IAsyncLifetime
    {
        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }

        protected readonly ILog Log;
        protected IBrowserContext BrowserContext { get; private set; }
        protected IPage Page { get; private set; }
        protected PageFactory PageFactory { get; private set; }
        private string _tracePath;

        private readonly string _testName;

        protected UIBaseTest()
        {
            _testName = GetType().Name;
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            Log = LogManager.GetLogger(typeof(UIBaseTest));
        }

        public async Task InitializeAsync()
        {

            Log.Info("=== Test Run Setup Started ===");

            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Log.Info("Playwright created.");

            BrowserTypeLaunchOptions browserOptions = new()
            {
                Headless = FrameworkConfigProvider.Config.Headless,
                SlowMo = FrameworkConfigProvider.Config.SlowMo
            };

            if (FrameworkConfigProvider.Config.Browser == "Chrome")
            {
                Browser = await Playwright.Chromium.LaunchAsync(browserOptions);
                Log.Info("Chromium browser launched.");
            }
            else if (FrameworkConfigProvider.Config.Browser == "Firefox")
            {
                Browser = await Playwright.Firefox.LaunchAsync(browserOptions);
                Log.Info("Firefox browser launched.");
            }
            else
            {
                Browser = await Playwright.Webkit.LaunchAsync(browserOptions);
                Log.Info("Webkit browser launched.");
            }

            Log.Info("=== Test Run Setup Completed ===");

            BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = FrameworkConfigProvider.Config.ViewportWidth, Height = FrameworkConfigProvider.Config.ViewportHeight }
            });

            Page = await BrowserContext.NewPageAsync();

            PageFactory = new PageFactory(Page);

            Log.Info($"=== START TRACING {_testName} ===");

            await BrowserContext.Tracing.StartAsync(new TracingStartOptions
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            Log.Info($"=== START TEST {_testName} ===");
        }

        public async Task DisposeAsync()
        {
            
            _tracePath = Path.Combine(Directory.GetCurrentDirectory(), $"trace-test-{_testName}-{Guid.NewGuid()}.zip");
            await BrowserContext.Tracing.StopAsync(new TracingStopOptions { Path = _tracePath });

            AllureApi.AddAttachment("Playwright Trace", "application/zip", _tracePath);

            await BrowserContext.CloseAsync();

            if (Browser != null)
            {
                await Browser.CloseAsync();
                Log.Info("Browser closed.");
            }

            Playwright.Dispose();
            Log.Info("Playwright disposed.");

            Log.Info($"=== END TEST {_testName} ===");
        }
    }
}
