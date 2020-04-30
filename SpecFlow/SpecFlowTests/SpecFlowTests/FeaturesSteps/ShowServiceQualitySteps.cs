using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SpecFlowTests.FeaturesSteps
{
    [Binding]
    public class ShowServiceQualitySteps
    {
        ChromeDriver driver;
        [Given(@"I have been on the website https://transparent\.vmr\.gov\.ua/ReportPages/Score\.aspx")]
        public void GivenIHaveBeenOnTheWebsiteHttpsTransparent_Vmr_Gov_UaReportPagesScore_Aspx()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://transparent.vmr.gov.ua/ReportPages/Score.aspx");
            Thread.Sleep(6000);
        }
        
        [Given(@"I have chosen as a start data next '(.*)' as a start data")]
        public void GivenIHaveChosenAsAStartDataNextAsAStartData(string startData)
        {
            string select = "#ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl03_txtValue:nth-child(1)";
            var item = driver.FindElementByCssSelector(select);
            item.Clear();
            Thread.Sleep(1000);
            item.SendKeys(startData);
            item.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        
        [Given(@"I have chosen as an end data next '(.*)'as an end date")]
        public void GivenIHaveChosenAsAnEndDataNextAsAnEndDate(string endData)
        {
            string select = "#ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl07_txtValue:nth-child(1)";
            var item = driver.FindElementByCssSelector(select);
            item.Clear();
            Thread.Sleep(1000);
            item.SendKeys(endData);
        }
        
        [Given(@"I have chosen next '(.*)' as a service center")]
        public void GivenIHaveChosenNextAsAServiceCenter(string serviceCenter)
        {
            var select = "#ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl05_ddValue:nth-child(1)";
            var item = driver.FindElementByCssSelector(select);
            item.Click();
            Thread.Sleep(500);
            var selectItem = new SelectElement(item);
            string value = "4";
            switch (serviceCenter)
            {
                case "Відділення 'Центр'":
                    value = "1";
                    break;
                case "Відділення 'Вишенька'":
                    value = "2";
                    break;
                case "Відділення 'Замостя'":
                    value = "3";
                    break;
            }
            selectItem.SelectByValue(value);
            Thread.Sleep(1000);
        }
        
        [When(@"I press view report")]
        public void WhenIPressViewReport()
        {
            var id = "ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl00";
            driver.FindElementById(id).Click();
            Thread.Sleep(45000);
        }
        
        [Then(@"the statistics and marks of quality of '(.*)' should be showen")]
        public void ThenTheStatisticsAndMarksOfQualityOfShouldBeShowen(string serviceCenter)
        {
            var xpath = "//*[@class='pc-wp-content-center']/div/div/div/div/div/span/div/table/tbody/tr[4]/td[3]/div/div/div/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr/td/div";
            string unnecessaryText = "Вінницька міська рада ЦАП Відділення ";
            string text = driver.FindElementByXPath(xpath).Text.Replace(unnecessaryText, "");
            text = text.Replace("«", "").Replace("»", "");
            string correctText = serviceCenter.Replace("Відділення ", "").Replace("'", "");
            Assert.AreEqual(text, correctText);
            driver.Close();
        }
    }
}
