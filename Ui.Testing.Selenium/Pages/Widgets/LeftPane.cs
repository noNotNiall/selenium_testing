using OpenQA.Selenium;

namespace Ui.Testing.Selenium.Pages.Widgets{
    public class LeftPane{

        IWebDriver _driver;
        
        public LeftPane(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement RootElement => _driver.FindElement(By.Id("pane"));

    }
}