using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();
        string url = "https://todomvc.com/";

        [Fact]
        public void NavigateToWebsite()
        {
            driver.Navigate().GoToUrl(url);

            driver.Quit();
        }

        [Fact]
        public void UsernameTest()
        {
            driver.Navigate().GoToUrl(url);

            IWebElement textInputBox = driver.FindElement(By.Name("my-text"));
            textInputBox.SendKeys("TestUser1");

            IWebElement passwordInputBox = driver.FindElement(By.Name("my-password"));
            passwordInputBox.SendKeys("testpassword1");

            IWebElement textareaInputBox = driver.FindElement(By.Name("my-textarea"));
            textareaInputBox.SendKeys("This is the description for TestUser1");

            IWebElement dropDownMenu = driver.FindElement(By.Name("my-select"));

            SelectElement selectDropDownMenu = new SelectElement(dropDownMenu);
            selectDropDownMenu.SelectByIndex(1);

            IWebElement submitButton = driver.FindElement(By.XPath("/html/body/main/div/form/div/div[2]/button"));
            submitButton.Click();

            driver.Quit();
        }
    }
}