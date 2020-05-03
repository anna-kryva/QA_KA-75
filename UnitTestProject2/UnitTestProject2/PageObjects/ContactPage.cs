using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject2.PageObjects
{
    public class ContactPage : TemplatePage
    {
        private const string Url = "https://moonvillageassociation.org/contact/";

        [FindsBy(How = How.CssSelector, Using = "[name='control7209631']")]
        public IWebElement mailElement;

        [FindsBy(How = How.Id, Using = "id123-fielderror7209631")]
        public IWebElement mailAlertElement;

        [FindsBy(How = How.Id, Using = "id123-fielderror7643121")]
        public IWebElement agreeAlertElement;

        [FindsBy(How = How.CssSelector, Using = "[value='SUBMIT FORM']")]
        public IWebElement SubmitElement;

        public ContactPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ContactPage LoadPage(IWebDriver driver)
        {
            Driver.Url = Url;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.SwitchTo().Frame("iFrameResizer0");

            return this;
        }

        public ContactPage FillIncorrect()
        {
            var mail = "qwerty@%#.com";
            
            mailElement.SendKeys(mail.ToString());

            return this;
        }

        public ContactPage Submit()
        {

            SubmitElement.Click();
            SubmitElement.Click();

            return this;
        }

        public bool AlertMailPresent()
        {
            
            string atext = mailAlertElement.GetAttribute("innerText");

            return atext.ToLower().Contains("expected input: email");
            
        }

        public bool AlertAgreePresent()
        {

            string atext = agreeAlertElement.GetAttribute("innerText");

            return atext.ToLower().Contains("this field is required.");


        }
    }
}
