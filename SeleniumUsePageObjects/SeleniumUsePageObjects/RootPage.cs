using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace SeleniumUsePageObjects
{
    //contains elements and actions that are common for all pages 
    public class RootPage
    {
        IWebDriver _driver;
        public RootPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        //elements
        [FindsBy(How = How.CssSelector, Using = "li.selected")]
        public IWebElement CurrentCategory;
        [FindsBy(How = How.ClassName, Using = "cookies__close")]
        public IWebElement PopUpWindowCloseButton;
        [FindsBy(How = How.CssSelector, Using = ".cookies__agree")]
        public IWebElement PopUpWindowAgreeButton;

        //get values
        public string Url { get { return _driver.Url; } }
        
        public bool IsAbleToClickOnElement(IWebElement elem)
        {
            try
            {
                elem.Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //actions
        public RootPage Refresh()
        {
            _driver.Navigate().Refresh();
            return this;
        }
        public void TakeIntoView(IWebElement elem)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
        }
        
        public RootPage ChangeWindowSize(int width)
        {
            _driver.Manage().Window.Size = new System.Drawing.Size(width, 840);
            return this;
        }
        public RootPage CloseAdvertisement()
        {
            try
            {
                _driver.FindElement(By.ClassName("api-gpt-close-btn")).Click();
            }
            catch (NoSuchElementException) { }
            return this;
        }
        public RootPage CloseWindow()
        {
            PopUpWindowCloseButton.Click();
            return this;
        }
        
        public RootPage ChangeCurrentTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            return this;
        }
        public RootPage CloseCurrentTab()
        {
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            return this;
        }
        public RootPage ChangeCategory(string need_category)
        {
            if (CurrentCategory.Text != need_category)
            {
                CurrentCategory.FindElement(By.XPath("..//a[contains(text(),'" + need_category + "')]")).Click();
            }
            return this;
        }
    }
}
