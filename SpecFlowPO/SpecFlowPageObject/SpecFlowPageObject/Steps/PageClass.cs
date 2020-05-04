using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SpecFlowPageObject.Steps
{
    public class MainPage
    {
                /*Inicialization*/
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
                /*Elements*/
        [FindsBy(How = How.ClassName, Using = "switchmodebase")]
        protected IWebElement switchModeButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "bw")]
        protected IWebElement switchDarkBackgroundColorButton { get; set; }
        [FindsBy(How = How.Id, Using = "s4-bodyContainer")]
        protected IWebElement mainContainer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".lang:nth-child(1)")]
        protected IWebElement switchEngButton { get; set; }

        [FindsBy(How = How.TagName, Using = "h1")]
        protected IWebElement headerText { get; set; }
        [FindsBy(How = How.ClassName, Using = "lb")]
        protected IWebElement switchLargeFontSizeButton { get; set; }
        [FindsBy(How = How.TagName, Using = "html")]
        protected IWebElement html { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sbox")]
        protected IWebElement searchInfoRow { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_SearchLink")]
        protected IWebElement startSearchButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "ms-srch-item-highlightedText")]
        protected IWebElement firstSearchRes { get; set; }
        private readonly IWebDriver _driver;

                /*Functions*/
        public void PressSettingsButton()
        {
            switchModeButton.Click();
        }
        public void ChooseDarkBackgroundColorColorMode()
        {
            switchDarkBackgroundColorButton.Click();
        }
        public void ChooseLargeButtonMode()
        {
            switchLargeFontSizeButton.Click();
        }
        public void ChooseEngLangMode()
        {
            switchEngButton.Click();
            Thread.Sleep(5000);
        }
        public void EnterSearchText(string text)
        {
            searchInfoRow.Clear();
            searchInfoRow.SendKeys(text);
        }
        public void StartSearching()
        {
            startSearchButton.Click();
            Thread.Sleep(3000);
        }


        public bool BackgroudColorChangingRes()
        {
            string background = mainContainer.GetCssValue("background-color");
            var itemClass = mainContainer.GetAttribute("class").Split(' ');
            if (background == "rgba(102, 102, 102, 1)" && itemClass[1] == "black")
            {
                return true;
            }
            return false;
        }
        public bool LargeButtonChangingRes()
        {
            var itemClass = mainContainer.GetAttribute("class").Split(' ');
            string headerFontSize = headerText.GetCssValue("font-size");
            if (itemClass[0] == "lt" && headerFontSize == "52px")
            {
                return true;
            }
            return false;
        }
        public bool EngModChoosingRes()
        {
            var htmlStyle = html.GetAttribute("lang");
            if (htmlStyle == "en-US")
            {
                return true;
            }
            return false;
        }
        public bool SearchRes(string expectedText)
        {
            var searchedInfo = firstSearchRes.Text;
            if (searchedInfo.ToLower() == expectedText.ToLower())
            {
                return true;
            }
            return false;
        }
    }

    public class TourPage
    {
                /*Inicialization*/
        public TourPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
                /*Elements*/
        [FindsBy(How = How.XPath, Using = "//*[@id='zz2_RootAspMenu']/li[4]/a")]
        protected IWebElement onlineToursButton { get; set; }
        [FindsBy(How = How.TagName, Using = "h1")]
        protected IWebElement headerText { get; set; }
        private readonly IWebDriver _driver;
                /*Functions*/
        public void openTours()
        {
            onlineToursButton.Click();
        }
        public bool openToursRes()
        {
            var resText = headerText.Text;
            if (resText == "The page cannot be found")
            {
                return true;
            }
            return false;
        }
    }
    public class StatisticsPage
    {
                /*Inicialization*/
        public StatisticsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
                /*Elements*/
        [FindsBy(How = How.CssSelector, Using = "#ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl03_txtValue:nth-child(1)")]
        protected IWebElement startDateStr { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl07_txtValue:nth-child(1)")]
        protected IWebElement endDateStr { set; get; }
        [FindsBy(How = How.CssSelector, Using = "#ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl05_ddValue:nth-child(1)")]
        protected IWebElement serviceCenterSelector { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ctl34_g_fdb365db_d30e_48e5_bb89_aeac13ecb127_ctl00_ctl04_ctl00")]
        protected IWebElement startSearchButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='pc-wp-content-center']/div/div/div/div/div/span/div/table/tbody/tr[4]/td[3]/div/div/div/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr/td/div")]
        protected IWebElement statisticsTitle { get; set; }
        

        private readonly IWebDriver _driver;
                /*Functions*/
        public void SetStartDate(string date)
        {
            startDateStr.Clear();
            Thread.Sleep(1000);
            startDateStr.SendKeys(date);
            startDateStr.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        public void SetEndDate(string date)
        {
            endDateStr.Clear();
            Thread.Sleep(1000);
            endDateStr.SendKeys(date);
        }

        public void SetServiceCenter(string serviceCenter)
        {
            serviceCenterSelector.Click();
            Thread.Sleep(5000);
            var selectItem = new SelectElement(serviceCenterSelector);
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
        public void GetStatistics()
        {
            startSearchButton.Click();
            Thread.Sleep(60000);
        }
        public bool ShowStatisticsRes(string serviceCenter)
        {
            string unnecessaryText = "Вінницька міська рада ЦАП Відділення ";
            var text = statisticsTitle.Text.Replace(unnecessaryText, "");
            text = text.Replace("«", "").Replace("»", "");
            string correctText = serviceCenter.Replace("Відділення ", "").Replace("'", "");
            if(correctText == text)
            {
                return true;
            }
            return false;
        }
    }

    public class SubventionPage
    {
        /*Inicialization*/
        public SubventionPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        /*Elements*/
        [FindsBy(How = How.Id, Using = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_FlatArea")]
        protected IWebElement flatSquareRow { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_PeopleCount")]
        protected IWebElement peopleNumRow { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_AverageIncome")]
        protected IWebElement incomeRow { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_tb_ChargesSum")]
        protected IWebElement taxesRow { get; set; }
        [FindsBy(How = How.Id, Using = "ctl00_ctl34_g_8e483beb_519a_4e47_a3a7_f17341254a13_ctl00_btn_Calculate")]
        protected IWebElement calcButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='ms-formtable']/tbody/tr[7]/td")]
        protected IWebElement calcRes { get; set; }
        
        private readonly IWebDriver _driver;
        /*Functions*/
        public void SetFaltSquare(string square)
        {
            flatSquareRow.SendKeys(square);
        }
        public void SetPepopleNum(string peopleNum)
        {
            peopleNumRow.SendKeys(peopleNum);
        }
        public void SetIncome(string income)
        {
            incomeRow.SendKeys(income);
        }
        public void SetTaxes(string taxes)
        {
            taxesRow.SendKeys(taxes);
        }
        public void Calculate()
        {
            calcButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public string CalculationRes()
        {
            return calcRes.Text;
        }
    }
}
