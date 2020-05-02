using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KaggleSeleniumTesting_PageObjects.PageObjects
{
    public class DiscussionPage : BasicPage
    {
        private const string Url = "https://www.kaggle.com/c/deepfake-detection-challenge/discussion/145721";
        private const string CommentFieldXpath = "//textarea[@id='placeholder-input']";
        private const string WarningFieldXpath = "//div[@class='comment-list__login-warning']";

        [FindsBy(How = How.XPath, Using = CommentFieldXpath)]
        public IWebElement CommentField;
        
        [FindsBy(How = How.XPath, Using = WarningFieldXpath)]
        public IWebElement WarningField;

        public DiscussionPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public DiscussionPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public bool CommentFieldOnThePage() => !(WaitUntilDisplayed(CommentField) is null);

        
        public bool WarningFieldOnThePage() => !(WaitUntilDisplayed(WarningField) is null);
 
    }
}