using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject2.PageObjects
{
    public class EventPage : TemplatePage
    {
        private const string Url = "https://moonvillageassociation.org/events/";

        [FindsBy(How = How.CssSelector, Using = "[name='tribe-bar-date']")]
        public IWebElement eventElement;

        [FindsBy(How = How.ClassName, Using = "tribe-events-page-title")]
        public IWebElement tmpElement;
        
        string date = "684654.561.65";

        public EventPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public EventPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public EventPage CleanField()
        {

            eventElement.SendKeys(Keys.Control + "a");
            eventElement.SendKeys(Keys.Delete);

            return this;
        }

        public EventPage Fill()
        {
            
            eventElement.SendKeys(date.ToString());

            return this;
        }

        public EventPage ClickSomewhere()
        {

            tmpElement.Click();

            return this;
        }

        public bool dateChanged()
        {

            string atext = eventElement.GetAttribute("value");
            
            return atext != date;

        }


    }
}
