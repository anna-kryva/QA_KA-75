using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Threading;

namespace SpecFlowPageObject.Steps
{
    [Binding]
    public class SubventionCalculationSteps
    {
        ChromeDriver driver;
        SubventionPage myPage;
        [Given(@"I have been on the webpage https://www\.vmr\.gov\.ua/TransparentCity/Lists/Subsidy/Default\.aspx")]
        public void GivenIHaveBeenOnTheWebpageHttpsWww_Vmr_Gov_UaTransparentCityListsSubsidyDefault_Aspx()
        {
            string url = "https://www.vmr.gov.ua/TransparentCity/Lists/Subsidy/Default.aspx";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            myPage = new SubventionPage(driver);
        }
        
        [Given(@"I have entered '(.*)' in general flat square row")]
        public void GivenIHaveEnteredInGeneralFlatSquareRow(int square)
        {
            myPage.SetFaltSquare(square.ToString());
        }
        
        [Given(@"I have entered '(.*)' in registered people number row")]
        public void GivenIHaveEnteredInRegisteredPeopleNumberRow(int peopleNum)
        {
            myPage.SetPepopleNum(peopleNum.ToString());
        }
        
        [Given(@"I have entered '(.*)' in overall incom per month row")]
        public void GivenIHaveEnteredInOverallIncomPerMonthRow(int income)
        {
            myPage.SetIncome(income.ToString());
        }
        
        [Given(@"I have entered '(.*)' in overall taxes per month row")]
        public void GivenIHaveEnteredInOverallTaxesPerMonthRow(int taxes)
        {
            myPage.SetTaxes(taxes.ToString());
        }
        
        [When(@"I press count")]
        public void WhenIPressCount()
        {
            myPage.Calculate();
        }
        
        [Then(@"the subvention should be shown")]
        public void ThenTheSubventionShouldBeShown()
        {
            string res = myPage.CalculationRes();
            Assert.IsNotNull(res);
            driver.Close();
        }
    }
}
