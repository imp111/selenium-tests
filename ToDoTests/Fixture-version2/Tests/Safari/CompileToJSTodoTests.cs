using OpenQA.Selenium;

namespace ToDoTests.Fixture_version2.Tests.Safari
{
    public class CompileToJSTodoTests : IClassFixture<SafariDriverFixture>
    {
        private const string URL = "https://todomvc.com/";
        private readonly SafariDriverFixture _fixture;

        public CompileToJSTodoTests(SafariDriverFixture fixture)
        {
            _fixture = fixture;
        }

        private void OpenTechnology(string name)
        {
            var technologyLink = _fixture.Driver.FindElement(By.LinkText(name));
            technologyLink.Click();
        }

        private void AddNewTodoItem(string input)
        {
            string xPath = "//input[@placeholder=\"What needs to be done?\"]";
            var todoInputField = _fixture.Driver.FindElement(By.XPath(xPath));
            todoInputField.SendKeys(input);
            todoInputField.SendKeys(Keys.Enter);
        }

        private void ItemCheckBox(string checkBoxName)
        {
            string xPath = $"//label[text()=\"{checkBoxName}\"]/preceding-sibling::input";
            var todoCheckBox = _fixture.Driver.FindElement(By.XPath(xPath));
            todoCheckBox.Click();
        }

        private void AssertNumberOfItems(int count)
        {
            string xPath = "//footer/span";
            var footer = _fixture.Driver.FindElement(By.XPath(xPath));
            _fixture.Driver.ValidateTextInElement(footer, count.ToString());
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
            _fixture.Driver.GoToUrl(URL);
            OpenTechnology(technology);
            AddNewTodoItem("Breakfast");
            ItemCheckBox("Breakfast");
            AssertNumberOfItems(0);
        }
    }
}
