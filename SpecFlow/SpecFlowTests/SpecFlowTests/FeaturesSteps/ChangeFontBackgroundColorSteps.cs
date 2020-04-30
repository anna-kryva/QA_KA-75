using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class ChangeFontBackgroundColorSteps
    {
        ChromeDriver driver;
        [Given(@"I have been on any page of the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnAnyPageOfTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vmr.gov.ua");
        }
        
        [Given(@"I have pressed a UI settings button")]
        public void GivenIHavePressedAUISettingsButton()
        {
            driver.FindElementByClassName("switchmodebase").Click();
        }
        
        [When(@"I press a change UI color button")]
        public void WhenIPressAChangeUIColorButton()
        {
            driver.FindElementByClassName("bw").Click();
        }
        
        [Then(@"the website`s UI cullor should be changed")]
        public void ThenTheWebsiteSUICullorShouldBeChanged()
        {
            var background = driver.FindElementById("s4-bodyContainer").GetCssValue("background-color");
            var itemClass = driver.FindElementById("s4-bodyContainer").GetAttribute("class").Split(' ');
            Assert.IsTrue(background == "rgba(102, 102, 102, 1)" && itemClass[1] == "black");
            driver.Close();
        }
    }
}