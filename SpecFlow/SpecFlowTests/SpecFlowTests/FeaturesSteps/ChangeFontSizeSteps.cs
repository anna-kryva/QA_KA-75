using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class ChangeFontSizeSteps
    {
        ChromeDriver driver;
        [Given(@"I have been on page of the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnPageOfTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vmr.gov.ua");
        }
        
        [Given(@"I have pressed UI settings button")]
        public void GivenIHavePressedUISettingsButton()
        {
            driver.FindElementByClassName("switchmodebase").Click();
        }
        
        [When(@"I press a change font size button")]
        public void WhenIPressAChangeFontSizeButton()
        {
            driver.FindElementByClassName("lb").Click();
        }
        
        [Then(@"the font size on the page should be changed")]
        public void ThenTheFontSizeOnThePageShouldBeChanged()
        {
            var itemClass = driver.FindElementById("s4-bodyContainer").GetAttribute("class").Split(' ');
            var titleFontSize = driver.FindElementByTagName("h1").GetCssValue("font-size");
            Assert.IsTrue(itemClass[0] == "lt" && titleFontSize == "52px");
            driver.Close();
        }
    }
}
