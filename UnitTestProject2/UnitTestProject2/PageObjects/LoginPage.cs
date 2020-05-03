using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject2.PageObjects
{
    public class LoginPage : TemplatePage
    {
        private const string Url = "https://moonvillageassociation.org/wp-login.php";

        [FindsBy(How = How.CssSelector, Using = "[name='log']")]
        public IWebElement usernameElement;

        [FindsBy(How = How.CssSelector, Using = "[name='wp-submit']")]
        public IWebElement submitElement;

        [FindsBy(How = How.Id, Using = "login_error")]
        public IWebElement alertElement;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public LoginPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public LoginPage Fill()
        {
            var username = "qwerty";

            usernameElement.SendKeys(username.ToString());

            return this;
        }

        public LoginPage Submit()
        {

            submitElement.Click();

            return this;
        }

        public bool AlertPresent()
        {

            string atext = alertElement.GetAttribute("innerText");

            return atext.ToLower().Contains("the password field is empty");

        }
    }
}
