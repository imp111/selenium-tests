using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ToDoTests.Fixture_version2
{
    public abstract class DriverFixture : IDisposable
    {
        public DriverAdapter Driver { get; private set; }

        public const int WAIT_TIME = 5;

        public DriverFixture()
        {
            Driver = new DriverAdapter();
            InitializeDriver();
        }

        protected abstract void InitializeDriver();
        public virtual int WaitForElementTimeout { get; set; } = WAIT_TIME;
        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
