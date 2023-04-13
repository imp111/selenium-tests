
namespace ToDoTests.Fixture_version2
{
    public class ChromeDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Start(BrowserType.Chrome);
        }

        public override int WaitForElementTimeout => 10;
    }
}
