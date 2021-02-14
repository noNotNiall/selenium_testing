using OpenQA.Selenium;

namespace Ui.Testing.Selenium.Pages.Widgets
{
    public class CookiesConsentFrame
    {
        private IWebDriver _driver;

        public CookiesConsentFrame(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement RootElement => _driver.FindElement(By.ClassName("widget-consent-frame"));
        
        public IWebElement BtnAgree => _driver.FindElement(By.Id("introAgreeButton"));

        public void AcceptCookies(){
            
            _driver.SwitchTo().Frame(RootElement);

            BtnAgree.Click();
        }
    }
}