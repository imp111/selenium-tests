using AutoFixture;
using AutoFixture.Xunit2;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Tests
{
    public class WithAutoFixture : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly WebDriverFixture webDriverFixture;

        public WithAutoFixture(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TryAddingNote()
        {
            var driver = webDriverFixture.ChromeDriver;
            var input = new Fixture().Create<string>(); // using AutoFixture to create string
            var email = new Fixture().Create<MailAddress>();

            driver
                .Navigate()
                .GoToUrl(webDriverFixture.URL);

            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(email.Address);
            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(Keys.Enter);

            testOutputHelper.WriteLine("Successfuly added to do!");
        }

        [Fact]
        public void TryAddingNoteWithModel()
        {
            var driver = webDriverFixture.ChromeDriver;
            var fixture = new Fixture();

            var model = fixture
                            .Build<RegisterUserModel>()
                            .Without(x => x.Email) // email will have value null
                            .With(x => x.Name == "Gosho") // name will have value Gosho
                            .Create(); // using AutoFixture to create string
           
            driver
                .Navigate()
                .GoToUrl(webDriverFixture.URL);

            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(model.Name);
            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(Keys.Enter);

            testOutputHelper.WriteLine("Successfuly added to do!");
        }

        [Theory, AutoData]
        public void TryAddingNoteWithAutoData(RegisterUserModel model)
        {
            var driver = webDriverFixture.ChromeDriver;
            
            driver
                .Navigate()
                .GoToUrl(webDriverFixture.URL);

            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(model.Name);
            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(Keys.Enter);

            testOutputHelper.WriteLine("Successfuly added to do!");
        }

        [Theory, RegisterUser]
        public void TryAddingNoteWithRegisterUserAttribute(RegisterUserModel model)
        {
            var driver = webDriverFixture.ChromeDriver;

            driver
                .Navigate()
                .GoToUrl(webDriverFixture.URL);

            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(model.Name);
            driver.FindElement(By.XPath("/html/body/ng-view/section/header/form/input")).SendKeys(Keys.Enter);

            testOutputHelper.WriteLine("Successfuly added to do!");
        }
    }
}
