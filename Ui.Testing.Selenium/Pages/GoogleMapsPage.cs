using OpenQA.Selenium;
using Ui.Testing.Selenium.Pages.Widgets;

namespace Ui.Testing.Selenium.Pages
{
    public class GoogleMapsPage
    {
        public IWebDriver _driver;

        public GoogleMapsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public CookiesConsentFrame CookiesConsentFrame => new(_driver);

        public LeftPane LeftPane => new(_driver);

        public void AcceptCookies(){

            CookiesConsentFrame.AcceptCookies();
        }

        public void SearchForLocation(string locationName){
            LeftPane.SearchForLocation(locationName);
        }

        public void ClickBtnDirections(){
            LeftPane.ClickBtnDirections();
        }

        public bool DestinationContainsExpectedString(string expectedString){

            return LeftPane.DestinationContainsExpectedString(expectedString);
        }

        public bool LocationDetailsContainsExpectedName(string expectedName){

            return LeftPane.LocationDetailsWidget.LocationTitleEqualsExpectedName(expectedName);
        }
    }
}
