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


        [FindsBy(How = How.Id, Using = "story")]
        public IWebElement Search;
        [FindsBy(How = How.LinkText, Using = "Поиск")]
        public IWebElement FoundButton;
        [FindsBy(How = How.CssSelector, Using = ".shortpost:nth-child(4) img:nth-child(1)")]
        public IWebElement Persi;

        [FindsBy(How = How.Id, Using = "login_button")]
        public IWebElement Login;
        [FindsBy(How = How.Id, Using = "login_name")]
        public IWebElement LoginName;
        [FindsBy(How = How.Id, Using = "login_password")]
        public IWebElement LoginPassword;
        [FindsBy(How = How.Name, Using = "image")]
        public IWebElement Entrence;

        [FindsBy(How = How.LinkText, Using = "Рейтингу")]
        public IWebElement Rating;
        [FindsBy(How = How.CssSelector, Using = ".navigation > a:nth-child(3)")]
        public IWebElement Page2;
        [FindsBy(How = How.CssSelector, Using = ".navigation > a:nth-child(4)")]
        public IWebElement Page3;
        [FindsBy(How = How.LinkText, Using = "Вперед")]
        public IWebElement Forward;
        [FindsBy(How = How.LinkText, Using = "1985")]
        public IWebElement LastPage;

        [FindsBy(How = How.CssSelector, Using = ".next")]
        public IWebElement Next;
        [FindsBy(How = How.CssSelector, Using = ".prev")]
        public IWebElement Prev;

        [FindsBy(How = How.LinkText, Using = "Криминальные")]
        public IWebElement Criminal;
        [FindsBy(How = How.LinkText, Using = "Дате")]
        public IWebElement Date;

        [FindsBy(How = How.LinkText, Using = "Помощь")]
        public IWebElement Help;
        [FindsBy(How = How.CssSelector, Using = ".hfeedback")]
        public IWebElement Feedback;
        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement Name;
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email;
        [FindsBy(How = How.Name, Using = "subject")]
        public IWebElement Subject;
        [FindsBy(How = How.Name, Using = "message")]
        public IWebElement Message;
        [FindsBy(How = How.CssSelector, Using = ".fbutton > span")]
        public IWebElement Send;

        [FindsBy(How = How.LinkText, Using = "Восстановить пароль")]
        public IWebElement Forgotten;
        [FindsBy(How = How.Name, Using = "lostname")]
        public IWebElement Lostname;
        [FindsBy(How = How.CssSelector, Using = ".fbutton > span")]
        public IWebElement Submit;

        [FindsBy(How = How.LinkText, Using = "Для правообладателей")]
        public IWebElement Report;
        [FindsBy(How = How.Id, Using = "abuse_organization")]
        public IWebElement Organization;
        [FindsBy(How = How.Id, Using = "abuse_name")]
        public IWebElement Abusename;
        [FindsBy(How = How.Id, Using = "abuse_email")]
        public IWebElement Abuseemail;
        [FindsBy(How = How.Id, Using = "abuse_links")]
        public IWebElement Abuselinks;
        [FindsBy(How = How.Id, Using = "abuse_document")]
        public IWebElement Abusedoc;
        [FindsBy(How = How.Id, Using = "abuse_text")]
        public IWebElement Abusetext;
        [FindsBy(How = How.Name, Using = "send_btn")]
        public IWebElement SendReport;

        public Page _lastpage()
        {
            LastPage.Click();
            return this;
        }
        public Page _forward()
        {
            Forward.Click();
            return this;
        }
        public Page _page3()
        {
            Page3.Click();
            return this;
        }
        public Page _page2()
        {
            Page2.Click();
            return this;
        }
        public Page _rating()
        {
           Rating.Click();
            return this;
        }
        public Page _prev()
        {
            Prev.Click();
            Prev.Click();
            Prev.Click();
            return this;
        }
        public Page _next()
        {
            Next.Click();
            Next.Click();
            Next.Click();
            return this;
        }
        public Page _submit()
        {
            Submit.Click();
            return this;
        }
        public Page _lostname(string key)
        {
            Lostname.SendKeys(key);
            return this;
        }
        public Page _forgotten()
        {
            Forgotten.Click();
            return this;
        }
        public Page _sendreport()
        {
            SendReport.Click();
            return this;
        }
        public Page _fillinabusetext(string key)
        {
            Abusetext.SendKeys(key);
            return this;
        }
        public Page _fillinabusedoc(string key)
        {
            Abusedoc.SendKeys(key);
            return this;
        }
        public Page _fillinabuselinks(string key)
        {
            Abuselinks.SendKeys(key);
            return this;
        }
        public Page _fillinabuseemail(string key)
        {
            Abuseemail.SendKeys(key);
            return this;
        }
        public Page _fillinabusename(string key)
        {
            Abusename.SendKeys(key);
            return this;
        }
        public Page _report()
        {
            Report.Click();
            return this;
        }
        public Page _fillinorganization(string key)
        {
            Organization.SendKeys(key);
            return this;
        }

       
        public Page _send()
        {
            Send.Click();
            return this;
        }
        public Page _fillinmessage(string key)
        {
            Message.SendKeys(key);
            return this;
        }
        public Page _fillinsubject(string key)
        {
            Subject.SendKeys(key);
            return this;
        }
        public Page _fillinemail(string key)
        {
            Email.SendKeys(key);
            return this;
        }
        public Page _fillinname(string key)
        {
            Name.SendKeys(key);
            return this;
        }
        public Page _feedback()
        {
            Feedback.Click();
            return this;
        }
        public Page _help()
        {
            Help.Click();
            return this;
        }
        public Page _criminal()
        {
            Criminal.Click();
            return this;
        }
        public Page _date()
        {
            Date.Click();
            return this;
        }
       
        public Page _entrence()
        {
            Entrence.Click();
            return this;
        }
        public Page _fillinloginpassword(string key)
        {
            LoginPassword.SendKeys(key);
            return this;
        }
        public Page _fillinloginname(string key)
        {
            LoginName.SendKeys(key);
            return this;
        }
        public Page _login()
        {
            Login.Click();
            return this;
        }
        public Page _persi()
        {
            Persi.Click();
            return this;
        }
        public Page _find()
        {
            FoundButton.Click();
            return this;
        }
        public Page _search()
        {
            Search.Click();
            return this;
        }

        public Page _fillinsearch(string key)
        {
            Search.SendKeys(key);
            return this;
        }

        public Page _gotopage(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;   
        }

       

    }
}
