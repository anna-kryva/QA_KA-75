using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KaggleSeleniumTesting_PageObjects.PageObjects
{
    public class DatasetsPage : BasicPage
    {
        private const string Url = "https://www.kaggle.com/datasets";
        private const string NewDatasetButtonXpath = "//*[@id='site-content']/div[2]/div[1]/div/div[2]/div/button";
        private const string DatasetTitleFieldXpath =
            "//div[@class='ReactModalPortal']//input[@placeholder='Enter Dataset Title']";

        [FindsBy(How = How.XPath, Using = NewDatasetButtonXpath)]
        public IWebElement NewDatasetButton;
        
        [FindsBy(How = How.XPath, Using = DatasetTitleFieldXpath)]
        public IWebElement DatasetTitleField;
        
        public DatasetsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public DatasetsPage LoadPage()
        {
            Driver.Url = Url;
            return this;
        }

        public DatasetsPage CreateDataset()
        {
            WaitUntilDisplayed(NewDatasetButton).Click();
            return this;
        }

        public bool DatasetTitleFieldDisplayed()
        {
            return !(WaitUntilDisplayed(DatasetTitleField) is null);
        }
    }
}