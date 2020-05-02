using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KaggleSeleniumTesting_PageObjects.PageObjects
{
    public class CompetitionDataPage : BasicPage
    {
        private const string Url = "https://www.kaggle.com/c/vsb-power-line-fault-detection/data";
        private const string DownloadDataUrl = "https://www.kaggle.com/c/10684/download-all";
        private const string DownloadDataXpath = "//*[@id='comp-data-download-all']";

        [FindsBy(How = How.XPath, Using = DownloadDataXpath)]
        public IWebElement DownloadData;

        public CompetitionDataPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public CompetitionDataPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public bool DownloadDataAvailable()
        {
            string actualUrl = WaitUntilDisplayed(DownloadData).GetProperty("href");
            return string.Equals(actualUrl, DownloadDataUrl);
        }
    }
}