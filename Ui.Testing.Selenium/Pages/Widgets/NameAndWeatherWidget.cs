using System.Linq;
using OpenQA.Selenium;

namespace Ui.Testing.Selenium.Pages.Widgets
{
    public class NameAndWeatherWidget
    {
        private IWebDriver _driver;

        public NameAndWeatherWidget(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement RootElement => _driver.FindElement(By.CssSelector("div[class='section-hero-header-title-description']"));

        public string LocationName => RootElement.FindElement(By.CssSelector("h1[class^='section-hero-header-title-title']")).FindElements(By.TagName("span")).First().Text;

        public bool LocationTitleEqualsExpectedName(string expectedName){
            return LocationName.Contains(expectedName);
        }
    }
}