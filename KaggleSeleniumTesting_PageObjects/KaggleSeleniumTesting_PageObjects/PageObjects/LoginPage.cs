using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KaggleSeleniumTesting_PageObjects.PageObjects
{
    public class LoginPage : BasicPage
    {
        private const string Url = "https://www.kaggle.com/account/login?phase=emailSignIn";
        private const string EmailFieldName = "email";
        private const string PasswordFieldName = "password";
        private const string SubmitButtonXpath = "//button[@type='submit']";

        [FindsBy(How = How.Name, Using = EmailFieldName)]
        public IWebElement EmailField;
        
        [FindsBy(How = How.Name, Using = PasswordFieldName)]
        public IWebElement PasswordField;
        
        [FindsBy(How = How.XPath, Using = SubmitButtonXpath)]
        public IWebElement SubmitButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public LoginPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public LoginPage LogIn(string email, string password)
        {
            WaitUntilDisplayed(EmailField).Clear();
            EmailField.SendKeys(email);
            WaitUntilDisplayed(PasswordField).Clear();
            PasswordField.SendKeys(password);
            WaitUntilDisplayed(SubmitButton).Click();
            return this;
        }
    }
}