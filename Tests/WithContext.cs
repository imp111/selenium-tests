using OpenQA.Selenium;
using Xunit.Abstractions;

namespace Tests
{
    public class WithContext : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly WebDriverFixture webDriverFixture;

        public WithContext(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void NavigateToUrl()
        {
            webDriverFixture.ChromeDriver.Navigate().GoToUrl(webDriverFixture.URL);
            testOutputHelper.WriteLine("Navigating to URL sucessfull");
        }

        [Theory]
        [InlineData("Do the dishes")]
        [InlineData("!@#$-()*")]
        [InlineData("")]
        [InlineData(" ")]
        public void TryAddingToDoFirstWay(string input)
        {
            var driver = webDriverFixture.ChromeDriver;
            
            driver
                .Navigate()
                .GoToUrl(webDriverFixture.URL);

            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(input);
            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(Keys.Enter);

            testOutputHelper.WriteLine("Successfuly added to do!");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TryAddingToDoSecondWay(string input)
        {
            var driver = webDriverFixture.ChromeDriver;

            driver
                .Navigate()
                .GoToUrl(webDriverFixture.URL);

            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(input);
            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(Keys.Enter);
            
            testOutputHelper.WriteLine("Successfuly added to do!");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                "Do the dishes"
            },
            new object[]
            {
                " "
            },
            new object[]
            {
                ""
            },
            new object[]
            {
                "!@#$-()*"

            }
        };
    }
}
