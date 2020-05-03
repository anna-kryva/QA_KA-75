using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject2.PageObjects
{
    public class RegistrationPage : TemplatePage
    {
        private const string Url = "https://moonvillageassociation.org/register/individual-student/";

        [FindsBy(How = How.CssSelector, Using = "[name='mepr_mobile']")]
        public IWebElement mobileFieldElement;

        [FindsBy(How = How.CssSelector, Using = "[name='mepr_date_of_birth']")]
        public IWebElement dateFieldElement;

        [FindsBy(How = How.ClassName, Using = "mepr-submit")]
        public IWebElement submitElement;

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public RegistrationPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public RegistrationPage FillMobileIncorrect()
        {
            var mobile = "qwerty";

            mobileFieldElement.SendKeys(mobile.ToString());

            return this;
        }

        public RegistrationPage FillDateIncorrect()
        {
            var date = "8989098709";

            dateFieldElement.SendKeys(date.ToString());

            return this;
        }

        public RegistrationPage Submit()
        {

            submitElement.Click();

            return this;
        }

        
        public bool AlertMobilePresent()
        {
            string atext = mobileFieldElement.GetAttribute("class");

            return atext.ToLower().Contains("invalid");

        }

        public bool AlertDatePresent()
        {
            string atext = dateFieldElement.GetAttribute("class");

            return atext.ToLower().Contains("invalid");

        }
    }
}
