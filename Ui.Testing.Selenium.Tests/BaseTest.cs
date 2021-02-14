using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ui.Testing.Selenium.Tests
{
    public abstract class BaseTest
    {
        protected  IWebDriver _driver;
        
        [SetUp]
        public void BeforeEach()
        {
            var driverPath = Path.GetFullPath(@"../../../../" + "_drivers");
            _driver = new ChromeDriver(driverPath);
        }

        [TearDown]
        public void AfterEach()
        {
            _driver.Quit();
        }
    }
}