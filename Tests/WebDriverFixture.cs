using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Tests
{
    public class WebDriverFixture : IDisposable
    {
        public ChromeDriver ChromeDriver { get; private set; }
        public string URL = "https://todomvc.com/examples/angularjs/#/";

        public WebDriverFixture()
        {
            var driver = new DriverManager().SetUpDriver(new ChromeConfig()); // setup driver config
            ChromeDriver = new ChromeDriver(driver); // setup chrome driver
        }

        public void Dispose()
        {
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
        }
    }
}
