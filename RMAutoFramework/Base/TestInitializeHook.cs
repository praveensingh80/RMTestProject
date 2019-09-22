using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using RMAutoFramework.Config;
using RMAutoFramework.Helpers;
using System;
using TechTalk.SpecFlow;

namespace RMAutoFramework.Base
{
    public class TestInitializeHook : Steps
    {
        private readonly ParallelConfig _parallelConfig;
        private Uri seleniumGrid = new Uri("http://localhost:8090/wd/hub");

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void InitializeSettings(string testSetting)
        {
            //Set all the framework settings
            ConfigReader.SetFrameworkSettings(testSetting);

            //Set log
            LogHelpers.CreateLogFile();

            //Open browser
            OpenBrowser(Settings.BrowserType);

            LogHelpers.Write("Initialized settings!!!");
        }

        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            DriverOptions opt = new ChromeOptions();
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    opt = new InternetExplorerOptions();
                    opt.AddAdditionalCapability(CapabilityType.BrowserName, "internetexplorer");
                    break;
                case BrowserType.Chrome:
                    opt = new ChromeOptions();
                    opt.AddAdditionalCapability(CapabilityType.BrowserName, "chrome");
                    break;
                case BrowserType.Firefox:
                    opt = new FirefoxOptions();
                    //opt.AddAdditionalCapability(, "firefox");
                    break;
            }

            _parallelConfig.Driver = new RemoteWebDriver(seleniumGrid, opt.ToCapabilities());
        }

    }   
}
