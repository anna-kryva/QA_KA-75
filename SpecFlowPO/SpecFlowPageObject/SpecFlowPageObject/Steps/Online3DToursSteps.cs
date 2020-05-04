using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class Online3DToursSteps
    {
        ChromeDriver driver;
        TourPage myPage;
        [Given(@"I have been on the webpage https://transparent\.vmr\.gov\.ua/default\.aspx")]
        public void GivenIHaveBeenOnTheWebpageHttpsTransparent_Vmr_Gov_UaDefault_Aspx()
        {
            string url = "https://transparent.vmr.gov.ua/default.aspx";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new TourPage(driver);
        }

        [When(@"I pressonline (.*)D-touras button")]
        public void WhenIPressonlineD_TourasButton(int p0)
        {
            myPage.openTours();
        }

        [Then(@"the list of (.*)D-tours should be shown")]
        public void ThenTheListOfD_ToursShouldBeShown(int p0)
        {
            var res = myPage.openToursRes();
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}
