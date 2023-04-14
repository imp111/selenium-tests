using OpenQA.Selenium;

//[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 2)]
namespace ToDoTests.Fixture_version2.Tests.Firefox
{
    public class PureJSTodoTests : IClassFixture<FirefoxDriverFixture>
    {
        private const string URL = "https://todomvc.com/";
        private readonly FirefoxDriverFixture _fixture;

        public PureJSTodoTests(FirefoxDriverFixture fixture)
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

        private void AssertNumberOfItemsForMarionette(int count)
        {
            string xPath = "//footer/div/span";
            var footer = _fixture.Driver.FindElement(By.XPath(xPath));
            _fixture.Driver.ValidateTextInElement(footer, count.ToString());
        }

        [Theory]
        [InlineData("Backbone.js")]
        [InlineData("AngularJS")]
        [InlineData("Ember.js")]
        [InlineData("React")]
        [InlineData("Vue.js")]
        [InlineData("CanJS")]
        [InlineData("KnockoutJS")]
        [InlineData("Dojo")]
        [InlineData("Marionette.js")]
        [InlineData("Polymer")]
        [InlineData("Vanilla JS")]
        [InlineData("jQuery")]
        public void VerifyTodoIsCreatedMultiple(string technology) // parameterized testing
        {
            _fixture.Driver.GoToUrl(URL);

            if (technology == "Marionette.js")
            {
                OpenTechnology(technology);
                AddNewTodoItem("Breakfast");
                ItemCheckBox("Breakfast");
                AssertNumberOfItemsForMarionette(0);
            }
            else
            {
                OpenTechnology(technology);
                AddNewTodoItem("Breakfast");
                ItemCheckBox("Breakfast");
                AssertNumberOfItems(0);
            }
        }
    }
}
