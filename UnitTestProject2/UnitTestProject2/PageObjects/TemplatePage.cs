using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject2.PageObjects
{
    public abstract class TemplatePage
    {
        private IWebDriver _driver;
        public IWebDriver Driver => _driver;

        public TemplatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement WaitUntilDisplayed(IWebElement element, int timeout = 5)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(drv => element.Displayed);
                return element;
            }
            catch (WebDriverTimeoutException)
            {

            }

            return null;
        }
    }
}
