using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class SubventionCalculationSteps
    {
        ChromeDriver driver;
        [Given(@"I have been on the webpage https://www\.vmr\.gov\.ua/TransparentCity/Lists/Subsidy/Default\.aspx")]
        public void GivenIHaveBeenOnTheWebpageHttpsWww_Vmr_Gov_UaTransparentCityListsSubsidyDefault_Aspx()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vmr.gov.ua/TransparentCity/Lists/Subsidy/Default.aspx");
        }
        
        [Given(@"I have entered '(.*)' in general flat square row")]
        public void GivenIHaveEnteredInGeneralFlatSquareRow(int square)
        {
            var id = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_FlatArea";
            driver.FindElementById(id).SendKeys(square.ToString());
        }
        
        [Given(@"I have entered '(.*)' in registered people number row")]
        public void GivenIHaveEnteredInRegisteredPeopleNumberRow(int people)
        {
            var id = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_PeopleCount";
            driver.FindElementById(id).SendKeys(people.ToString());
        }
        
        [Given(@"I have entered '(.*)' in overall incom per month row")]
        public void GivenIHaveEnteredInOverallIncomPerMonthRow(int income)
        {
            var id = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_AverageIncome";
            driver.FindElementById(id).SendKeys(income.ToString());
        }
        
        [Given(@"I have entered '(.*)' in overall taxes per month row")]
        public void GivenIHaveEnteredInOverallTaxesPerMonthRow(int taxes)
        {
            var id = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_ChargesSum";
            driver.FindElementById(id).SendKeys(taxes.ToString());
        }
        
        [When(@"I press count")]
        public void WhenIPressCount()
        {
            var id = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_btn_Calculate";
            driver.FindElementById(id).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        
        [Then(@"the subvention should be shown")]
        public void ThenTheSubventionShouldBeShown()
        {
            var xpath = "//*[@class='ms-formtable']/tbody/tr[7]/td";
            string text = driver.FindElementByXPath(xpath).Text;
            Assert.IsNotNull(text);
            driver.Close();
        }
    }
}
