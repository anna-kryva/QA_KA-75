using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject2.PageObjects
{
    public abstract class TemplatePage
    {
        public IWebDriver Driver;

        public TemplatePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement WaitUntilDisplayed(IWebElement element, int timeout = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
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
