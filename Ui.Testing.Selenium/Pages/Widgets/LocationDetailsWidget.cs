using OpenQA.Selenium;
using System.Linq;

namespace Ui.Testing.Selenium.Pages.Widgets
{
    public class LocationDetailsWidget
    {
        private IWebDriver _driver;

        public LocationDetailsWidget(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement RootElement => _driver.FindElement(By.CssSelector("div[class='widget-pane widget-pane-visible']"));
        
        public IWebElement ImgLocation => _driver.FindElement(By.ClassName("section-hero-header-image"));
        
        public NameAndWeatherWidget NameAndWeatherWidget => new(_driver);

        public LocationActionsWidget  LocationActionsWidget => new(_driver);

        public IWebElement LocationTitle => RootElement.FindElements(By.TagName("span")).First();

        public bool LocationTitleEqualsExpectedName(string expectedName){
            return LocationTitle.Text.Equals(expectedName);
        }

        public void ClickDirections(){
            LocationActionsWidget.ClickDirections();
        }
    }
}