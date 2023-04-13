using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ToDoTests
{
    public class UnitTest1 : IDisposable
    {   
        private const int WAIT_TIME = 30;
        private const string URL = "https://todomvc.com/";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _action;

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME));
            _action = new Actions(_driver);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        private IWebElement WaitUntilElementIsFound(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        private void OpenTechnology(string name)
        {
            var technologyLink = WaitUntilElementIsFound(By.LinkText(name));
            technologyLink.Click();
        }

        private void AddNewTodoItem(string input)
        {
            var todoInputField = WaitUntilElementIsFound(By.XPath("//input[@placeholder=\"What needs to be done?\"]"));
            todoInputField.SendKeys(input);

            _action.Click(todoInputField).SendKeys(Keys.Enter).Perform();
        }

        [Fact]
        public void VerifyTodoIsCreated()
        {
            _driver.Navigate().GoToUrl(URL);
            OpenTechnology("React");
            AddNewTodoItem("Breakfast");
        }
    }
}