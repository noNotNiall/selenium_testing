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

        public IWebElement RootElement => _driver.FindElement(By.CssSelector("h1[class^='section-hero-header-title-title'"));

        public IWebElement LocationTitle => RootElement.FindElements(By.TagName("span")).First();

        public bool LocationTitleEqualsExpectedName(string expectedName){
            return LocationTitle.Text.Equals(expectedName);
        }
    }
}