using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecFlowTests.FeaturesSteps
{
    public class Page
    {
        public Page(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "switchmodebase")]
        protected IWebElement switchModeButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "bw")]
        protected IWebElement switchColorButton { get; set; }
        [FindsBy(How = How.Id, Using = "s4-bodyContainer")]
        protected IWebElement chengedElement { get; set; }

        private readonly IWebDriver _driver;

        public void PressSettingsButton()
        {
            switchModeButton.Click();
        }
        public void SwitchColorMode()
        {
            switchColorButton.Click();
        }
        public bool GetResults()
        {
            string background = chengedElement.GetCssValue("background-color");
            var itemClass = chengedElement.GetAttribute("class").Split(' ');
            if (background == "rgba(102, 102, 102, 1)" && itemClass[1] == "black")
            {
                return true;
            }
            return false;
        }
    }

    [Binding]
    public class ChangeFontBackgroundColorSteps
    {
        ChromeDriver driver;
        Page myPage;
        [Given(@"I have been on any page of the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnAnyPageOfTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            string url = "https://www.vmr.gov.ua";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new Page(driver);
        }

        [Given(@"I have pressed a UI settings button")]
        public void GivenIHavePressedAUISettingsButton()
        {
            myPage.PressSettingsButton();
        }

        [When(@"I press a change UI color button")]
        public void WhenIPressAChangeUIColorButton()
        {
            myPage.SwitchColorMode();
        }

        [Then(@"the website`s UI cullor should be changed")]
        public void ThenTheWebsiteSUICullorShouldBeChanged()
        {
            bool res = myPage.GetResults();
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}