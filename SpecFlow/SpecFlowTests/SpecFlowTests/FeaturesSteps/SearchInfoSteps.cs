using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class SearchInfoSteps
    {
        ChromeDriver driver;
        [Given(@"I have been on the website https://www\.vmr\.gov\.ua/default\.aspx")]
        public void GivenIHaveBeenOnTheWebsiteHttpsWww_Vmr_Gov_UaDefault_Aspx()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vmr.gov.ua/default.aspx");
        }

        [Given(@"I have entered '(.*)' in the search raw")]
        public void GivenIHaveEnteredInTheSearchRaw(string text)
        {
            driver.FindElementById("ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sbox").Clear();
            driver.FindElementById("ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sbox").SendKeys(text);
        }

        [When(@"I press find")]
        public void WhenIPressFind()
        {
            driver.FindElementById("ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_SearchLink").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Then(@"The pagege with a list of related to the '(.*)' links should be shown")]
        public void ThenThePagegeWithAListOfRelatedToTheLinksShouldBeShown(string p0)
        {
            var searchInfo = driver.FindElementByClassName("ms-srch-item-highlightedText").Text;
            Assert.AreEqual(p0.ToLower(), searchInfo.ToLower());
            driver.Close();
        }
    }
}