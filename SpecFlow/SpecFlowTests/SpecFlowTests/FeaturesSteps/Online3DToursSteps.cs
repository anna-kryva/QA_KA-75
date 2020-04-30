using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class Online3DToursSteps
    {
        ChromeDriver driver;
        [Given(@"I have been on the webpage https://transparent\.vmr\.gov\.ua/default\.aspx")]
        public void GivenIHaveBeenOnTheWebpageHttpsTransparent_Vmr_Gov_UaDefault_Aspx()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://transparent.vmr.gov.ua/default.aspx");
        }
        
        [When(@"I pressonline (.*)D-touras button")]
        public void WhenIPressonlineD_TourasButton(int p0)
        {
            var xpath = "//*[@id='zz2_RootAspMenu']/li[4]/a";
            driver.FindElementByXPath(xpath).Click();
        }
        
        [Then(@"the list of (.*)D-tours should be shown")]
        public void ThenTheListOfD_ToursShouldBeShown(int p0)
        {
            var text = driver.FindElementByTagName("h1").Text;
            Assert.AreEqual(text, "The page cannot be found");
            driver.Close();
        }
    }
}
