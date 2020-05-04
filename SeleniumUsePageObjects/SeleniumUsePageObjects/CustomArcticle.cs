using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SeleniumUsePageObjects
{
    public class CustomArcticle:MainPage
    {
        IWebDriver _driver;
        public CustomArcticle(IWebDriver driver):base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        [FindsBy(How = How.ClassName, Using = "comment")]
        public IList<IWebElement> CommentsIcons { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".new-comment textarea")]
        public IWebElement CommentArea;
        [FindsBy(How = How.CssSelector, Using = ".buttons button[type='submit']")]
        public IWebElement CommentSubmitButton;
        [FindsBy(How = How.Id, Using = "auth-widget")]
        public IWebElement AuthorizationWindow;

        public CustomArcticle AddComment(string str="some text")
        {            
            TakeIntoView(CommentsIcons[1]);
            CommentsIcons[1].Click();
           // CloseAdvertisement();
            CommentArea.SendKeys(str);
            CommentSubmitButton.Click();
            return this;
        }
    }
}
