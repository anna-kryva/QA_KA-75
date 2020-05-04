using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class SearchInfoSteps
    {
        ChromeDriver driver;
        MainPage myPage;
        [Given(@"I have been on the website https://www\.vmr\.gov\.ua/default\.aspx")]
        public void GivenIHaveBeenOnTheWebsiteHttpsWww_Vmr_Gov_UaDefault_Aspx()
        {
            string url = "https://www.vmr.gov.ua";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new MainPage(driver);
        }

        [Given(@"I have entered '(.*)' in the search raw")]
        public void GivenIHaveEnteredInTheSearchRaw(string text)
        {
            myPage.EnterSearchText(text);
        }

        [When(@"I press find")]
        public void WhenIPressFind()
        {
            myPage.StartSearching();
        }

        [Then(@"The pagege with a list of related to the '(.*)' links should be shown")]
        public void ThenThePagegeWithAListOfRelatedToTheLinksShouldBeShown(string text)
        {
            var res = myPage.SearchRes(text);
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}
