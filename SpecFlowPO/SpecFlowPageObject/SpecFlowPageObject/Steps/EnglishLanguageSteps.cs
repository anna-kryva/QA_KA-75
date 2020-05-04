using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class EnglishLanguageSteps
    {
        ChromeDriver driver;
        MainPage myPage;

        [Given(@"I have been on the website https://www\.vmr\.gov\.ua/")]
        public void GivenIHaveBeenOnTheWebsiteHttpsWww_Vmr_Gov_Ua()
        {
            string url = "https://www.vmr.gov.ua";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new MainPage(driver);
        }

        [When(@"I have pressed an english translation button")]
        public void WhenIHavePressedAnEnglishTranslationButton()
        {
            myPage.ChooseEngLangMode();
        }

        [Then(@"the truslated webpage should be shown")]
        public void ThenTheTruslatedWebpageShouldBeShown()
        {
            bool res = myPage.EngModChoosingRes();
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}
