using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTests.Fixture_version2
{
    internal class FirefoxDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Start(BrowserType.Firefox);
        }

        public override int WaitForElementTimeout => 10;
    }
}
