using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class ChangeFontSizeSteps
    {
        ChromeDriver driver;
        MainPage myPage;
        [Given(@"I have been on page of the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnPageOfTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            ScenarioContext.Current.Pending(); string url = "https://www.vmr.gov.ua";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new MainPage(driver);
        }
        
        [Given(@"I have pressed UI settings button")]
        public void GivenIHavePressedUISettingsButton()
        {
            myPage.PressSettingsButton();
        }
        
        [When(@"I press a change font size button")]
        public void WhenIPressAChangeFontSizeButton()
        {
            myPage.ChooseLargeButtonMode();
        }
        
        [Then(@"the font size on the page should be changed")]
        public void ThenTheFontSizeOnThePageShouldBeChanged()
        {
            bool res = myPage.LargeButtonChangingRes();
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}
