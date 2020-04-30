using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class EnglishLanguageSteps
    {
        ChromeDriver driver;
        [Given(@"I have been on the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vmr.gov.ua");
        }
        
        [When(@"I have pressed an english translation button")]
        public void WhenIHavePressedAnEnglishTranslationButton()
        {
            driver.FindElementByCssSelector(".lang:nth-child(1)").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        
        [Then(@"the truslated webpage should be shown")]
        public void ThenTheTruslatedWebpageShouldBeShown()
        {
            var htmlStyle = driver.FindElementByTagName("html").GetAttribute("lang");
            Assert.IsTrue(htmlStyle == "en-US");
            driver.Close();
        }
    }
}