using EGTDigitalAutomationFramework.Configs;
using EGTDigitalAutomationFramework.Core;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EGTDigitalAutomationFramework.Tests.UI.Base
{
    public class PlaywrightFixture : IAsyncLifetime
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PlaywrightFixture));

        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }
        public IBrowserContext BrowserContext { get; private set; }
        public IPage Page { get; private set; }
        public PageFactory PageFactory { get; private set; }
        public string TracesPath { get; private set; }

        static PlaywrightFixture()
        {
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
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

            BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = FrameworkConfigProvider.Config.ViewportWidth, Height = FrameworkConfigProvider.Config.ViewportHeight }
            });
            
            Page = await BrowserContext.NewPageAsync();

            PageFactory = new PageFactory(Page);

            TracesPath = "";

            Log.Info("PageFactory initialized.");
            Log.Info("=== Test Run Setup Completed ===");
        }

        public async Task DisposeAsync()
        {
            Log.Info("=== Test Run Teardown Started ===");

            if (Browser != null)
            {
                await Browser.CloseAsync();
                Log.Info("Browser closed.");
            }

            Playwright?.Dispose();
            Log.Info("Playwright disposed.");

            Log.Info("=== Test Run Teardown Completed ===");
        }
    }
}
