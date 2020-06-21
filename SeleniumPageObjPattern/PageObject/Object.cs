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




        [FindsBy(How = How.LinkText, Using = "Індекс")]
        public IWebElement Index;
        [FindsBy(How = How.LinkText, Using = "Ґа")]
        public IWebElement Ga;
        [FindsBy(How = How.CssSelector, Using = ".oo-ui-inputWidget-input > .oo-ui-labelElement-label")]
        public IWebElement Choose2;
        [FindsBy(How = How.LinkText, Using = "Попередня сторінка (Яшовець)")]
        public IWebElement Choose3;
        public Page _index()
        {
            Index.Click();
            return this;
        }
        public Page _ga()
        {
            Ga.Click();
            return this;
        }
        public Page _choose2()
        {
            Choose2.Click();
            return this;
        }
        public Page _choose3()
        {
            Choose3.Click();
            return this;
        }

        [FindsBy(How = How.LinkText, Using = "Вибрані статті")]
        public IWebElement SelectedArticles;
        [FindsBy(How = How.LinkText, Using = "Критерії")]
        public IWebElement Criteria;
        [FindsBy(How = How.LinkText, Using = "Відмова від відповідальності")]
        public IWebElement Disclaimer;
        [FindsBy(How = How.LinkText, Using = "Розробники")]
        public IWebElement Developers;
        public Page _selectedArticles()
        {
            SelectedArticles.Click();
            return this;
        }
        public Page _criteria()
        {
            Criteria.Click();
            return this;
        }
        public Page _disclaimer()
        {
            Disclaimer.Click();
            return this;
        }
        public Page _developers()
        {
            Developers.Click();
            return this;
        }

        [FindsBy(How = How.LinkText, Using = "Портал спільноти")]
        public IWebElement CommunityPortal;
        [FindsBy(How = How.LinkText, Using = "Вікіфікуйте")]
        public IWebElement Wikiquote;
        public Page _communityPortal()
        {
            CommunityPortal.Click();
            return this;
        }
        public Page _wikiquote()
        {
            Wikiquote.Click();
            return this;
        }


        [FindsBy(How = How.LinkText, Using = "Оновити кеш")]
        public IWebElement UpdateCache;
        [FindsBy(How = How.CssSelector, Using = ".oo-ui-inputWidget-input > .oo-ui-labelElement-label")]
        public IWebElement Ok;
        public Page _updateCache()
        {
            UpdateCache.Click();
            return this;
        }
        public Page _ok()
        {
            Ok.Click();
            return this;
        }

        [FindsBy(How = How.LinkText, Using = "Таблиці")]
        public IWebElement Tables;
        [FindsBy(How = How.LinkText, Using = "Polski")]
        public IWebElement Polski;
        public Page _tables()
        {
            Tables.Click();
            return this;
        }
        public Page _polski()
        {
            Polski.Click();
            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "#mf-his td:nth-child(2) a")]
        public IWebElement Choose4;
        [FindsBy(How = How.LinkText, Using = "Вікісховище")]
        public IWebElement WikimediaCommons;
        [FindsBy(How = How.CssSelector, Using = "tr:nth-child(6) > td:nth-child(17) > a")]
        public IWebElement Choose5;
        [FindsBy(How = How.LinkText, Using = "15 May, by year")]
        public IWebElement MayByYear;
        public Page _choose4()
        {
            Choose4.Click();
            return this;
        }
        public Page _wikimediaCommons()
        {
            WikimediaCommons.Click();
            return this;
        }
        public Page _choose5()
        {
            Choose5.Click();
            return this;
        }
        public Page _mayByYear()
        {
            MayByYear.Click();
            return this;
        }

        [FindsBy(How = How.LinkText, Using = "Переглянути історію")]
        public IWebElement ViewHistory;
        [FindsBy(How = How.CssSelector, Using = ".mw-history-compareselectedversions:nth-child(4) > .historysubmit")]
        public IWebElement Choose6;
        [FindsBy(How = How.LinkText, Using = "переглянути вихідний код")]
        public IWebElement ViewSourceCode;
        public Page _viewHistory()
        {
            ViewHistory.Click();
            return this;
        }
        public Page _choose6()
        {
            Choose6.Click();
            return this;
        }
        public Page _viewSourceCode()
        {
            ViewSourceCode.Click();
            return this;
        }

        [FindsBy(How = How.LinkText, Using = "Увійти")]
        public IWebElement Entrence;
        [FindsBy(How = How.Id, Using = "wpName1")]
        public IWebElement NameUser;
        [FindsBy(How = How.Id, Using = "wpPassword1")]
        public IWebElement Password;
        [FindsBy(How = How.Id, Using = "wpLoginAttempt")]
        public IWebElement Login;
        public Page _entrence()
        {
            Entrence.Click();
            return this;
        }
        public Page _login()
        {
            Login.Click();
            return this;
        }
        public Page _nameUser(string key)
        {
            NameUser.SendKeys(key);
            return this;
        }
        public Page _password(string key)
        {
            Password.SendKeys(key);
            return this;
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public Page _gotopage(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;   
        }

        

    }
}
