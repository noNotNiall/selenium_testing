using System;
using NUnit.Framework;
using Ui.Testing.Selenium.Pages;

namespace Ui.Testing.Selenium.Tests
{
    [TestFixture]
    public class GoogleMapsTests : BaseTest
    {
        [Test]
        [TestCase("Dublin")]
        public void Verify_Can_Search_For_Location(string searchTerm)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.Url = "https://www.google.com/maps";

            var googleMapsPage = new GoogleMapsPage(_driver);
            googleMapsPage.AcceptCookies();
            googleMapsPage.SearchForLocation(searchTerm);

            var locationDetailsWidget = googleMapsPage.LeftPane.LocationDetailsWidget;

            Assert.That(googleMapsPage.LocationDetailsContainsExpectedName(searchTerm), $"Expected location title to be {searchTerm} but was {locationDetailsWidget.LocationTitle.Text}");

            googleMapsPage.ClickBtnDirections();

            Assert.That(googleMapsPage.DestinationContainsExpectedString(searchTerm), $"Expected the destination field to contain {searchTerm} but value was {googleMapsPage.LeftPane.DirectionsWidget.DestinationSearchBoxText}");
        }
    }
}