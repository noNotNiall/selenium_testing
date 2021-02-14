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

        public IWebElement TxtFieldSearch => _driver.FindElement(By.Id("searchboxinput"));
        public IWebElement BtnSearch => _driver.FindElement(By.Id("searchbox-searchbutton"));
        public IWebElement BtnDirections => _driver.FindElement(By.CssSelector("button[data-value='Directions']"));
        public IWebElement DestinationSearchBox => _driver.FindElement(By.CssSelector($"input[aria-label^='Destination']"));

        public CookiesConsentFrame CookiesConsentFrame => new CookiesConsentFrame(_driver);

        public LocationDetailsWidget LocationDetailsWidget => new LocationDetailsWidget(_driver);

        public void AcceptCookies(){
            CookiesConsentFrame.AcceptCookies();
        }

        public void SearchForLocation(string locationName){
            TxtFieldSearch.SendKeys(locationName);
            BtnSearch.Click();
        }

        public void ClickBtnDirections(){
            BtnDirections.Click();
        }

        public bool DestinationContainsExpectedString(string expectedString){
            return DestinationSearchBox.GetAttribute("aria-label").Contains(expectedString);
        }
    }
}
