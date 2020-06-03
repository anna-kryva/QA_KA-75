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




        [FindsBy(How = How.Name, Using = "txtLogin")]
        public IWebElement Login;
        [FindsBy(How = How.CssSelector, Using = "#txtPassword")]
        public IWebElement Password;
        [FindsBy(How = How.LinkText, Using = "Вхід")]
        public IWebElement Entrence;
        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Вхід')]")]
        public IWebElement EntrenceButton;

        [FindsBy(How = How.CssSelector, Using = "#errorContainer")]
        public IWebElement LoginCheck;
        [FindsBy(How = How.XPath, Using = "//div[2]/label[5]/input")]
        public IWebElement Grade;
        [FindsBy(How = How.XPath, Using = "//div[2]/button")]
        public IWebElement GradeButton;
        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Дякуємо, Ваш голос прийнято!')]")]
        public IWebElement GradeCheck;

        [FindsBy(How = How.Name, Using = "txtName")]
        public IWebElement Name;
        [FindsBy(How = How.XPath, Using = "//textarea[@name='txtText']")]
        public IWebElement Comment;
        [FindsBy(How = How.XPath, Using = "//button[@onclick=\"$('#AddCommentsForm').submit();\"]")]
        public IWebElement AddCommentButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='art_data']/div[5]/p")]
        public IWebElement CommentCheck;

        [FindsBy(How = How.LinkText, Using = "ТОП 20")]
        public IWebElement Top20;
        [FindsBy(How = How.XPath, Using = "//img[@alt='купити: Книга Місто дівчат']")]
        public IWebElement Buy;


        [FindsBy(How = How.XPath, Using = "//img[@alt='купити: Книга 365 історій на ніч']")]
        public IWebElement OtherBook;
        [FindsBy(How = How.LinkText, Using = "Золоті казки")]
        public IWebElement Company;
        [FindsBy(How = How.LinkText, Using = "Розширений пошук")]
        public IWebElement AdvancedSearch;
        [FindsBy(How = How.XPath, Using = "//form[@id='ext_search_form']/div[8]/div/input")]
        public IWebElement PriceLow;
        [FindsBy(How = How.XPath, Using = "//form[@id='ext_search_form']/div[8]/div[2]/input")]
        public IWebElement PriceHigh;
        [FindsBy(How = How.LinkText, Using = "пошук")]
        public IWebElement Search;


        [FindsBy(How = How.LinkText, Using = "Зареєструвати Дисконтну картку")]
        public IWebElement DiskontCard;
        [FindsBy(How = How.Name, Using = "card")]
        public IWebElement Card;
        [FindsBy(How = How.LinkText, Using = "Зареєструвати карту")]
        public IWebElement RegisterCard;
        [FindsBy(How = How.XPath, Using = "//form[@id='aRegForm']/div/span/p")]
        public IWebElement CardCheck;

        [FindsBy(How = How.XPath, Using = "//img[@alt='купити: Книга Тореадори з Васюківки']")]
        public IWebElement Book;
        [FindsBy(How = How.LinkText, Using = "Всеволод Нестайко")]
        public IWebElement Vsevolod;
        [FindsBy(How = How.XPath, Using = "//select[@id='dd_sort']")]
        public IWebElement Sort;
        // [FindsBy(How = How.XPath, Using = "//select[@id='dd_sort']")]
        // public IWebElement Delete;

       

        public Page _otherbook()
        {
            OtherBook.Click();
            return this;
        }

        public Page _company()
        {
            Company.Click();
            return this;
        }

        public Page _advancedsearch()
        {
            AdvancedSearch.Click();
            return this;
        }

        public Page _search()
        {
            Search.Click();
            return this;
        }


        public Page _pricelow(string key)
        {
            PriceLow.SendKeys(key);
            return this;
        }

        public Page _pricehigh(string key)
        {
            PriceHigh.SendKeys(key);
            return this;
        }

        public Page _sort()
        {
            Sort.Click();
            return this;
        }

        public Page _vsevolod()
        {
            Vsevolod.Click();
            return this;
        }

        public Page _book()
        {
            Book.Click();
            return this;
        }

        public string GetCardCheckMessage()
        {
            return CardCheck.GetAttribute("p");
        }

        public Page _registerCard()
        {
            RegisterCard.Click();
            return this;
        }

        public Page _fillincard(string key)
        {
            Card.SendKeys(key);
            return this;
        }

        public Page _diskontCard()
        {
            DiskontCard.Click();
            return this;
        }


       

        public Page _buy()
        {
            Buy.Click();
            return this;
        }

        public Page _top20()
        {
            Top20.Click();
            return this;
        }
        public string GetCommentCheckMessage()
        {
            return CommentCheck.GetAttribute("p");
        }

        public Page _addComment()
        {
            AddCommentButton.Click();
            return this;
        }

        public Page _fillinName(string key)
        {
            Name.SendKeys(key);
            return this;
        }

        public Page _fillinComment(string key)
        {
            Comment.SendKeys(key);
            return this;
        }

        public Page _fillinlogin(string key)
        {
            Login.SendKeys(key);
            return this;
        }

        public Page _fillinpassword(string key)
        {
            Password.SendKeys(key);
            return this;
        }

        public Page _entrence()
        {
            Entrence.Click();
            return this;
        }
       
        public Page _entrencebutton()
        {
            EntrenceButton.Click();
            return this;
        }
      
        public string GetLoginCheckMessage()
        {
            return LoginCheck.GetAttribute("div");
        }

        public string GetGradeCheckMessage()
        {
            return GradeCheck.GetAttribute("b");
        }

        public Page _grade()
        {
            Grade.Click();
            return this;
        }

        public Page _gradeButton()
        {
            GradeButton.Click();
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
