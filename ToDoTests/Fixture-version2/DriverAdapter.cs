using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Xunit.Abstractions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Xunit.Sdk;
using SeleniumExtras.WaitHelpers;

namespace ToDoTests.Fixture_version2
{
    public class DriverAdapter : IDisposable
    {
        private WebDriverWait? _wait;
        private Actions? _action;
        private IWebDriver? _driver;
        private ITestOutputHelper? _testOutputHelper;
        public const int WAIT_TIME = 5;

        public void Start(BrowserType browser)
        {
            var config = "";

            switch (browser)
            {
                case BrowserType.Chrome:
                    config = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                    _driver = new ChromeDriver(config);
                    break;
                case BrowserType.Firefox:
                    config = new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.Latest);
                    _driver = new FirefoxDriver(config);
                    break;
                case BrowserType.Edge:
                    config = new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.Latest);
                    _driver = new EdgeDriver(config);
                    break;
                case BrowserType.Safari:
                    _driver = new SafariDriver();
                    break;
                default:
                    break;
            }

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME));
            _action = new Actions(_driver);
            _testOutputHelper = new TestOutputHelper();

            _driver?.Manage().Window.Maximize(); // make browser to fullscreen
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void ValidateTextInElement(IWebElement element, string expectedValue)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(element, expectedValue));
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
