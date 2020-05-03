using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class Page
    {
        private IWebDriver _driver;
        
        public Page(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "input[id=contact_surname]")]
        public IWebElement ContactSurname;
        [FindsBy(How = How.CssSelector, Using = "input[id=contact_name]")]
        public IWebElement ContactName;
        [FindsBy(How = How.CssSelector, Using = "input[id=contact_middlename]")]
        public IWebElement ContactMiddleName;
        [FindsBy(How = How.CssSelector, Using = "input[id=contact_email]")]
        public IWebElement ContactEmail;
        [FindsBy(How = How.CssSelector, Using = "input[value=' Начать составление Вашего генеалогического дерева ']")]
        public IWebElement GeneTreeButton;
        [FindsBy(How = How.CssSelector, Using = "input[id=top_s]")]
        public IWebElement TopName;
        [FindsBy(How = How.CssSelector, Using = "input[value = 'Найти']")]
        public IWebElement StartSearchButton;
        [FindsBy(How = How.CssSelector, Using = "input[id = 'birth_date']")]
        public IWebElement Date;
        [FindsBy(How = How.CssSelector, Using = "img[id = birth_date_check]")]
        public IWebElement DateCheck;
        [FindsBy(How = How.CssSelector, Using = "input[id = email]")]
        public IWebElement Email;
        [FindsBy(How = How.CssSelector, Using = "img[id = email_check]")]
        public IWebElement EmailCheck;
        [FindsBy(How = How.CssSelector, Using = "input[id=surname]")]
        public IWebElement Surname;
        [FindsBy(How = How.CssSelector, Using = "input[value = ' Проанализировать фамилию ']")]
        public IWebElement AnalysisButton;
        [FindsBy(How = How.CssSelector, Using = "input[id='login']")]
        public IWebElement Login;
        [FindsBy(How = How.CssSelector, Using = "input[id = submitFormRec]")]
        public IWebElement SubmitButton;
        [FindsBy(How = How.CssSelector, Using = "a[href='https://www.analizfamilii.ru/foto/']")]
        public IWebElement PhotosButton;
        [FindsBy(How = How.CssSelector, Using = "td[class =b]")]
        public IWebElement SideBar;

        public string GetContactSurname()
        {
            return ContactSurname.GetAttribute("value");
        }

        public bool CheckSideBar()
        {
            return SideBar.GetAttribute("style") == "color: red;";
        }

        public Page _startphoto()
        {
            PhotosButton.Click();
            return this;
        }

        public Page _submit()
        {
            SubmitButton.Click();
            return this;
        }

        public Page _fillinlogin(string key)
        {
            Login.SendKeys(key);
            return this;
        }

        public void GoBack()
        {
            _driver.Navigate().Back();
        }

        public string GetSurname()
        {
            return Surname.GetAttribute("value");
        }

        public void CheckAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public Page _fillinsurname(string key)
        {
            Surname.SendKeys(key);
            return this;
        }

        public Page _startanalysis()
        {
            AnalysisButton.Click();
            return this;
        }

        public string GetEmailCheckMessage()
        {
            return EmailCheck.GetAttribute("title");
        }

        public string GetDateCheckMessage()
        {
            return DateCheck.GetAttribute("title");
        }

        public Page _fillinemail(string key)
        {
            Email.SendKeys(key);
            return this;
        }

        public Page _fillindate(string key)
        {
            Date.SendKeys(key);
            return this;
        }

        public Page _wait()
        {
            System.Threading.Thread.Sleep(3000);
            return this;
        }

        public Page _starttopsearch()
        {
            StartSearchButton.Click();
            return this;
        }

        public Page _fillintopname(string key)
        {
            TopName.SendKeys(key);
            return this;
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public Page _startgenetree()
        {
            GeneTreeButton.Click();
            return this;
        }

        public Page _fillincontactemail(string key)
        {
            ContactEmail.SendKeys(key);
            return this;
        }

        public Page _fillincontactmiddlename(string key)
        {
            ContactMiddleName.SendKeys(key);
            return this;
        }

        public Page _fillincontactname(string key)
        {
            ContactName.SendKeys(key);
            return this;
        }

        public Page _fillincontactsurname(string key)
        {
            ContactSurname.SendKeys(key);
            return this;
        }

        public Page _gotopage(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;   
        }

        public Page SetSnth()
        {
            return this;
        }

    }
}
