using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections;
using System.Collections.Generic;
using System;
namespace SeleniumUsePageObjects
{
    public class WeatherPage:RootPage
    {
        IWebDriver _driver;
        public WeatherPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        //elements
        [FindsBy(How = How.XPath, Using = "//li[@class=' language']")]
        public IWebElement LanguagePanel;
        [FindsBy(How = How.XPath, Using = "//li[@class=' language']/span")]
        public IWebElement CurrentLanguage;

        //actions
        public WeatherPage ChangeLanguage(string lang)
        {
            CloseAdvertisement();
            PopUpWindowCloseButton.Click();
            TakeIntoView(LanguagePanel);
            LanguagePanel.FindElement(By.XPath(".//*[contains(text(),'" + lang + "')]")).Click();
            return this;
        }
    }
        
}
