using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Threading;

namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class ShowServiceQualitySteps
    {
        ChromeDriver driver;
        StatisticsPage myPage;
        [Given(@"I have been on the website https://transparent\.vmr\.gov\.ua/ReportPages/Score\.aspx")]
        public void GivenIHaveBeenOnTheWebsiteHttpsTransparent_Vmr_Gov_UaReportPagesScore_Aspx()
        {
            string url = "https://transparent.vmr.gov.ua/ReportPages/Score.aspx";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new StatisticsPage(driver);
            Thread.Sleep(6000);
        }
        
        [Given(@"I have chosen as a start data next '(.*)' as a start data")]
        public void GivenIHaveChosenAsAStartDataNextAsAStartData(string startDate)
        {
            myPage.SetStartDate(startDate);
        }
        
        [Given(@"I have chosen as an end data next '(.*)'as an end date")]
        public void GivenIHaveChosenAsAnEndDataNextAsAnEndDate(string endDate)
        {
            myPage.SetEndDate(endDate);
        }
        
        [Given(@"I have chosen next '(.*)' as a serviceCenter")]
        public void GivenIHaveChosenNextAsAServiceCenter(string serviceCenter)
        {
            myPage.SetServiceCenter(serviceCenter);
        }
        
        [When(@"I press view report")]
        public void WhenIPressViewReport()
        {
            myPage.GetStatistics();
        }
        
        [Then(@"the statistics and marks of quality of '(.*)' should be showen")]
        public void ThenTheStatisticsAndMarksOfQualityOfShouldBeShowen(string serviceCenter)
        {
            bool res = myPage.ShowStatisticsRes(serviceCenter);
            Assert.IsTrue(res);
            driver.Close();
        }
    }
}
