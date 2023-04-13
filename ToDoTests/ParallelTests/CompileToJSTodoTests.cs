using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace ToDoTests.ParallelTests
{
    public class CompileToJSTodoTests : IDisposable
    {
        private const int WAIT_TIME = 5;
        private const string URL = "https://todomvc.com/";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly Actions _action;

        public CompileToJSTodoTests()
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

        private void ItemCheckBox(string checkBoxName)
        {
            var todoCheckBox = WaitUntilElementIsFound(By.XPath($"//label[text()=\"{checkBoxName}\"]/preceding-sibling::input"));
            todoCheckBox.Click();
        }

        private void AssertNumberOfItems(int count)
        {
            var footer = WaitUntilElementIsFound(By.XPath("//footer/span"));
            ValidateFooterCount(footer, count.ToString());
        }

        private void ValidateFooterCount(IWebElement resultSpan, string expectedText) // used to compare the parameter count to the number in the span
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
        }

        [Theory]
        [InlineData("Closure")]
        [InlineData("Dart")]
        [InlineData("Elm")]
        [InlineData("cujoJS")]
        [InlineData("Spine")]
        [InlineData("Angular 2.0")]
        [InlineData("Mithril")]
        [InlineData("Kotlin + React")]
        [InlineData("Firebase + AngularJS")]
        [InlineData("Vanilla ES6")]
        public void VerifyTodoIsCreatedMultiple(string technology) // parameterized testing
        {
            _driver.Navigate().GoToUrl(URL);
            OpenTechnology(technology);
            AddNewTodoItem("Breakfast");
            ItemCheckBox("Breakfast");
            AssertNumberOfItems(0);
        }
    }
}
