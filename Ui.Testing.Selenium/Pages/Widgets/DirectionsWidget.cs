using OpenQA.Selenium;

namespace Ui.Testing.Selenium.Pages.Widgets
{
    public class DirectionsWidget
    {
        private IWebDriver _driver;

        public DirectionsWidget(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement DestinationSearchBox => _driver.FindElement(By.CssSelector($"input[aria-label^='Destination']"));

        public string DestinationSearchBoxText => DestinationSearchBox.GetAttribute("aria-label");

        public bool DestinationContainsExpectedString(string expectedString){

            return DestinationSearchBoxText.Contains(expectedString);
        }
    }
}