using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject2.PageObjects
{
    public class DownlPage : TemplatePage
    {
        private const string Url = "https://moonvillageassociation.org/white-paper-of-the-architectural-concepts-wg";

        [FindsBy(How = How.ClassName, Using = "button")]
        public IWebElement buttonElement;
        
        public DownlPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public DownlPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }
        
        public DownlPage Submit()
        {

            buttonElement.Click();

            return this;
        }

        public bool UploadCheck(IWebDriver driver)
        {

            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);
            String newurl = driver.Url;


            return newurl.Contains("moonvillageassociation.org/wp-content/uploads/");
            
        }
    }
}
