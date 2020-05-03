using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject2.PageObjects
{
    public class MainPage : TemplatePage
    {
        private const string Url = "https://moonvillageassociation.org/the-moon/";

        [FindsBy(How = How.CssSelector, Using = "[name='FNAME']")]
        public IWebElement fnameElement;

        [FindsBy(How = How.CssSelector, Using = "[name='LNAME']")]
        public IWebElement lnameElement;

        [FindsBy(How = How.CssSelector, Using = "[name='EMAIL']")]
        public IWebElement mailElement;

        [FindsBy(How = How.CssSelector, Using = "[value='Sign up']")]
        public IWebElement SignUpElement;

        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public MainPage FillIncorrect()
        {
            var fname = "qwerty";
            var lname = "qwerty";
            var mail = "qwerty@%#.com";

            fnameElement.SendKeys(fname.ToString());
            lnameElement.SendKeys(lname.ToString());
            mailElement.SendKeys(mail.ToString());
            
            return this;
        }

        public MainPage Submit()
        {

            SignUpElement.Click();
            
            return this;
        }

        public bool AlertPresent(IWebDriver driver)
        {
            
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
