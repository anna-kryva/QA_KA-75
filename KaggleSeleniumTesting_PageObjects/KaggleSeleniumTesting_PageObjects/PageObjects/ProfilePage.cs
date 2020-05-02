using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KaggleSeleniumTesting_PageObjects.PageObjects
{
    public class ProfilePage : BasicPage
    {
        private const string Url = "https://www.kaggle.com/vrkaggler";
        private const string MessageNicknameChanged = "Changes to your profile have been saved.";
        private const string ActionButtonXpath = "//a[contains(@class, 'pageheader__calltoaction')]";
        private const string NicknameFieldXpath = "//input[contains(@class, 'profile__display-name--input')]";
        private const string MessageFieldXpath = "//span[contains(@class, 'pageheader__pagemessagecontent')]";

        [FindsBy(How = How.XPath, Using = ActionButtonXpath)]
        public IWebElement ActionButton;
        
        [FindsBy(How = How.XPath, Using = NicknameFieldXpath)]
        public IWebElement NicknameField;
        
        [FindsBy(How = How.XPath, Using = MessageFieldXpath)]
        public IWebElement MessageField;

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public ProfilePage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public ProfilePage ChangeNickname(string nickname)
        {
            WaitUntilDisplayed(ActionButton).Click();
            WaitUntilDisplayed(NicknameField).Clear();
            NicknameField.SendKeys(nickname);
            WaitUntilDisplayed(ActionButton).Click();
            
            return this;
        }

        public bool NicknameChanged()
        {
             return string.Equals(WaitUntilDisplayed(MessageField).Text, MessageNicknameChanged);
        }
    }
}