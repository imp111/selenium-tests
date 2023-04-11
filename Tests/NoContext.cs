using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace Tests
{
    public class NoContext : IDisposable
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly IWebDriver chromeDriver;
        string url = "https://todomvc.com/";

        // Setup
        public NoContext(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper; // setup output helper
            var driver = new DriverManager().SetUpDriver(new ChromeConfig()); // setup driver config
            chromeDriver = new ChromeDriver(driver); // setup chrome driver
        }

        public void Dispose() // setup dispose method
        {
            chromeDriver.Quit();
        }

        [Fact]
        public void NavigateToWebsite()
        {
            chromeDriver.Navigate().GoToUrl(url);
            testOutputHelper.WriteLine("Navigating to URL sucessfull");
        }
    }
}