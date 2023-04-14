
namespace ToDoTests.Fixture_version2
{
    public class SafariDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Start(BrowserType.Safari);
        }

        public override int WaitForElementTimeout => 8;
    }
}
