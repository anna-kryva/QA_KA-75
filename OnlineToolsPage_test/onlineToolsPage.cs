using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace OnlineToolsPage
{ 
    public class OnlineToolsPage
    {
        private IWebDriver _driver;

        public OnlineToolsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[9]/a")] 
        public IWebElement sha256Button;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[2]/a")] 
        public IWebElement crc16Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[3]/a")] 
        public IWebElement crc32Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[4]/a")] 
        public IWebElement md2Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[5]/a")] 
        public IWebElement md4Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[6]/a")] 
        public IWebElement md5Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[7]/a")] 
        public IWebElement sha1Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='index']/ul[1]/li[8]/a")] 
        public IWebElement sha224Button;

        [FindsBy(How = How.XPath, Using = "//*[@id='input']")]
        public IWebElement inputArea;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='output']")]
        public IWebElement outputArea;

        [FindsBy(How = How.XPath, Using = "//*[@id='execute']")]
        public IWebElement hashButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='auto-update']")]
        public IWebElement checkButton;

        public bool sha256TestPassed => outputArea.GetAttribute("value").Equals("3f7ed440f078bd06775b276636be0833014c4f07b9c306111ece75906b381b8d");
        public bool crc16TestPassed => outputArea.GetAttribute("value").Equals("9b64");
        public bool crc32TestPassed => outputArea.GetAttribute("value").Equals("c8cb0285");
        public bool md2TestPassed => outputArea.GetAttribute("value").Equals("d04535d520109f876f3fdbd068bf62b1");
        public bool md4TestPassed => outputArea.GetAttribute("value").Equals("820157f121c6a7783d17f7957151d1ac");
        public bool md5TestPassed => outputArea.GetAttribute("value").Equals("1c98f1efe3fb6b9ac52a8c572480c9ec");
        public bool sha1TestPassed => outputArea.GetAttribute("value").Equals("fb7c51bb1b29c53b6ea110a56a65062463425e18");
        public bool sha224TestPassed => outputArea.GetAttribute("value").Equals("275f81a077aa3f0950148a0b5547777b49591892b16978a62ec4c172");

        public OnlineToolsPage ClickButton(IWebElement buttonToClick)
        {
            buttonToClick.Click();
            return this;
        }

        public OnlineToolsPage fillInputArea(IWebElement inputArea, string message_to_send)
        {
            inputArea.SendKeys(message_to_send);
            return this;
        }
        
   
    }
}