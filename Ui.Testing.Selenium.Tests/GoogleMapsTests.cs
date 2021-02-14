using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Ui.Testing.Selenium.Pages;

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
        [TestCase("Dublin")]
        public void Verify_Can_Search_For_Location(string searchTerm)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Driver.Url = "https://www.google.com/maps";

            var googleMapsPage = new GoogleMapsPage(Driver);
            
            //1a. Accept cookies agreement
            googleMapsPage.AcceptCookies();
            
            //2. Enter Dublin in the search box
            googleMapsPage.SearchForLocation(searchTerm);

            var locationDetailsWidget = googleMapsPage.LocationDetailsWidget;
            
            //4. Verify left panel has "Dublin" as a headline text
            Assert.That(locationDetailsWidget.LocationTitleEqualsExpectedName(searchTerm), $"Expected location title to be {searchTerm} but was {locationDetailsWidget.LocationTitle.Text}");
            
            //5. Click Directions icon
            googleMapsPage.ClickBtnDirections();
            
            //6. Verify destination field is "Dublin"
            Assert.That(googleMapsPage.DestinationContainsExpectedString(searchTerm), $"Expected the destination field to contain {searchTerm} but value was");
        }
    }
}