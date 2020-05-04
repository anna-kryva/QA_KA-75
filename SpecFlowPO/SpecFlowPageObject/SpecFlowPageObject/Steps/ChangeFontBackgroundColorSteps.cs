using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class ChangeFontBackgroundColorSteps
    {
        ChromeDriver driver;
        MainPage myPage;
        [Given(@"I have been on any page of the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnAnyPageOfTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            string url = "https://www.vmr.gov.ua";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new MainPage(driver);
        }

        [Given(@"I have pressed a UI settings button")]
        public void GivenIHavePressedAUISettingsButton()
        {
            myPage.PressSettingsButton();
        }

        [When(@"I press a change UI color button")]
        public void WhenIPressAChangeUIColorButton()
        {
            myPage.ChooseDarkBackgroundColorColorMode();
        }

        [Then(@"the website`s UI cullor should be changed")]
        public void ThenTheWebsiteSUICullorShouldBeChanged()
        {
            bool res = myPage.BackgroudColorChangingRes();
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}
