using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ToDoTests.Fixture_version2
{
    public class DriverFixture : IDisposable
    {
        public WebDriverWait Wait { get; private set; }
        public Actions Action { get; private set; }
        public IWebDriver Driver { get; private set; }
        public ITestOutputHelper TestOutputHelper { get; private set; }

        public const int WAIT_TIME = 5;

        public DriverFixture()
        {
            Driver = new ChromeDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_TIME));
            Action = new Actions(Driver);
            TestOutputHelper = new TestOutputHelper();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
