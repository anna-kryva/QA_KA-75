using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SeleniumUsePageObjects
{
    public class MainPage:RootPage
    {
        IWebDriver _driver;
        public MainPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        

        //elements
        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'dropdown')]/..//a[contains(text(),'Послуги')]")]
        public IWebElement Services;
        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'dropdown')]/..//a[contains(text(),'Соцмережі')]")]
        public IWebElement Social_links;
        [FindsBy(How = How.XPath, Using = "//li[contains(@class,'dropdown')]/..//a[contains(text(),'Укр')]")]
        public IWebElement Languages;
        [FindsBy(How = How.CssSelector, Using = ".sign a")]
        public IWebElement LoginButton;
        [FindsBy(How = How.CssSelector, Using = ".text-right button")]
        public IWebElement SearchUpperCornerLink;



        //get values
        public string LoginButton_value { get { return LoginButton.Text; } }
        
        
        
        
        //actions
        public bool ItemsDisplayed(ref string problem_message)
        {
            bool is_displayed=true;           
            IList<IWebElement> links = new List<IWebElement> { Services, Social_links, Languages };
            foreach(IWebElement item in links)
            {
                item.Click();
                if (!item.FindElement(By.XPath("../ul")).Displayed)
                {
                    is_displayed = false;
                    problem_message += item.Text + " items are not displayed\n";
                }               
            }
            return is_displayed;
        }
               
        public MainPage NavigateSearchPage()
        {
            SearchUpperCornerLink.Click();
            return this;
        }
        
        
        public MainPage ChangeLanguage(string lang)
        {           
            try
            {
                if (!Languages.Text.Contains(lang))
                {
                    Languages.Click();
                    Languages.FindElement(By.XPath("../ul//a[contains(text(),'" + lang + "')]")).Click();
                }
            }
            catch (NoSuchElementException)
            {
                if (Url.Contains("/pogoda"))
                {
                    var WeatherPage = new WeatherPage(_driver);
                    WeatherPage.ChangeLanguage(lang);
                }
                
            }
            return this;
        }
        
        public MainPage NavigateToSocialLink(string link_name)
        {
            Social_links.Click();
            Social_links.FindElement(By.XPath("..//*[contains(text(),'" + link_name + "')]")).Click();
            return this;
        }


    }
}
