using OpenQA.Selenium;

namespace Ui.Testing.Selenium.Pages.Widgets{
    public class LeftPane{

        IWebDriver _driver;
        
        public LeftPane(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement RootElement => _driver.FindElement(By.Id("pane"));
        public IWebElement TxtFieldSearch => _driver.FindElement(By.Id("searchboxinput"));
        public IWebElement BtnSearch => _driver.FindElement(By.Id("searchbox-searchbutton"));
        public IWebElement BtnDirections => _driver.FindElement(By.CssSelector("button[data-value='Directions']"));

        public DirectionsWidget DirectionsWidget => new(_driver);

        public LocationDetailsWidget LocationDetailsWidget => new(_driver);

        public void SearchForLocation(string locationName){
            TxtFieldSearch.SendKeys(locationName);
            BtnSearch.Click();
        }

        public void ClickBtnDirections(){
            BtnDirections.Click();
        }

        public bool DestinationContainsExpectedString(string expectedString){

            return DirectionsWidget.DestinationContainsExpectedString(expectedString);
        }
    }
}