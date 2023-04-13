using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ToDoTests
{
    public class UnitTest1 : IDisposable
    {   
        private const int WAIT_TIME = 30;
        private const string URL = "https://todomvc.com/";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME));
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void VerifyTodoIsCreated()
        {
            _driver.Navigate().GoToUrl(URL);
        }
    }
}