using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ui.Testing.Selenium.Tests
{
    [TestFixture]
    public class GoogleMapsTests
    {
        IWebDriver Driver;

        [SetUp]
        public void BeforeEach()
        {

            var driverPath = Path.GetFullPath(@"../../../../" + "_drivers");
            Driver = new ChromeDriver(driverPath);
        }

        [TearDown]
        public void AfterEach(){
            Driver.Quit();
        }

        [Test]
        public void Verify_Can_Search_For_Dublin()
        {
            var searchTerm = "Dublin";

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //1.	Go to https://www.google.com/maps
            Driver.Url = "https://www.google.com/maps";
            
            //1a. Accept cookies agreement
            var consentFrame = Driver.FindElement(By.ClassName("widget-consent-frame"));
            Driver.SwitchTo().Frame(consentFrame);

            var btnAgree = Driver.FindElement(By.Id("introAgreeButton"));
            btnAgree.Click();
            
            //2.	Enter Dublin in the search box
            var txtFieldSearch = Driver.FindElement(By.Id("searchboxinput"));
            txtFieldSearch.SendKeys(searchTerm);
            
            //3.	Search
            var btnSearch = Driver.FindElement(By.Id("searchbox-searchbutton"));
            btnSearch.Click();
            
            //4.	Verify left panel has "Dublin" as a headline text
            var locationHeader = Driver.FindElement(By.CssSelector("h1[class^='section-hero-header-title-title'"));
            var locationTitle = locationHeader.FindElements(By.TagName("span")).First();
            Assert.That(locationHeader.Text.Equals(searchTerm), $"Expected location title to be Dublin but was {locationHeader.Text}");
            
            //5.	Click Directions icon
            var btnDirections = Driver.FindElement(By.CssSelector("button[data-value='Directions']"));
            btnDirections.Click();
            
            //6.	Verify destination field is "Dublin"
            var inputDestination = Driver.FindElement(By.CssSelector($"input[aria-label^='Destination']")); 
            var txtDestination = inputDestination.GetAttribute("aria-label");

            Assert.That(txtDestination.Contains(searchTerm), $"Expected the destination field to contain {searchTerm} but value was {txtDestination} ");
        }
    }
}