﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTests.Fixture_version2
{
    public class EdgeDriverFixture : DriverFixture
    {
        protected override void InitializeDriver()
        {
            Driver.Start(BrowserType.Edge);
        }

        public override int WaitForElementTimeout => 20;
    }
}
