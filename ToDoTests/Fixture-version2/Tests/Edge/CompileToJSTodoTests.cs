using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using ToDoTests.Fixture_version1;

namespace ToDoTests.ParallelTests
{
    public class CompileToJSTodoTests : IClassFixture<DriverFixture>
    {
        private const string URL = "https://todomvc.com/";
        private readonly DriverFixture _fixture;

        public CompileToJSTodoTests(DriverFixture fixture)
        {
            _fixture = fixture;
        }

        private IWebElement WaitUntilElementIsFound(By locator)
        {
            return _fixture.Wait.Until(ExpectedConditions.ElementExists(locator));
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

            _fixture.Action.Click(todoInputField).SendKeys(Keys.Enter).Perform();
            
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
            _fixture.Wait.Until(ExpectedConditions.TextToBePresentInElement(resultSpan, expectedText));
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
            _fixture.Driver.Navigate().GoToUrl(URL);
            OpenTechnology(technology);
            AddNewTodoItem("Breakfast");
            ItemCheckBox("Breakfast");
            AssertNumberOfItems(0);
        }
    }
}
