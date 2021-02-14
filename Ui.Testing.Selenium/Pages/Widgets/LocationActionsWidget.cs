using OpenQA.Selenium;

namespace Ui.Testing.Selenium.Pages.Widgets
{
    public class LocationActionsWidget
    {
        private IWebDriver _driver;

        public LocationActionsWidget(IWebDriver driver)
        {
            _driver = driver;       
        }

        public IWebElement BtnDirections => _driver.FindElement(By.CssSelector("button[data-value='Directions']"));

        public void ClickDirections(){
            BtnDirections.Click();
        }
    }
}