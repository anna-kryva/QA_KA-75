using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;

namespace Auto
{
    [TestFixture]
    public class Tests_Main
    {
        private IWebDriver driver;
        private Page PgObj;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            PgObj = new Page(driver);
        }
        [TearDown]
        public void finish()
        {
            driver.Close();
        }


        [Test]
        public void Test1()
        {
            string search = "перси джексон";

            PgObj._gotopage("http://baskino.me/")._search()._fillinsearch(search)._find()._persi();
            
        }


        [Test]
        public void Test2()
        {
            string loginname = "roman@gmail.com";
            string loginpassword = "12345678";

            PgObj._gotopage("http://baskino.me/")._login()._fillinloginname(loginname)._fillinloginpassword(loginpassword)._entrence();
            
        }
        

        [Test]
        public void Test3()
        {
            PgObj._gotopage("http://baskino.me/")._rating()._page2()._page3()._forward()._lastpage();
        }
      

        [Test]
        public void Test4()
        {
            PgObj._gotopage("http://baskino.me/")._next()._prev();
        }
       

        [Test]
        public void Test5()
        {
            PgObj._gotopage("http://baskino.me/")._criminal()._date();
        }

        [Test]
        public void Test6()
        {

            string name = "меню";
            string email = "romadep228@gmail.com";
            string subject = "сдача лаб";
            string message = "помогите сделать лабу";

            PgObj._gotopage("http://baskino.me/")._help()._feedback()._fillinname(name)._fillinemail(email)._fillinsubject(subject)._fillinmessage(message)._send();
        }

        [Test]
        public void Test7()
        {
            string lostname = "ghjgkj";

            PgObj._gotopage("http://baskino.me/")._login()._forgotten()._lostname(lostname)._submit();
        }


        [Test]
        public void Test8()
        {
            string organization = "kpi";
            string abusename = "menu";
            string abuseemail = "laba@ukr.net";
            string abuselinks = "hfjdklsh";
            string abusedoc = "hfkjdsh";
            string abusetext = "jkfdjs";

            PgObj._gotopage("http://baskino.me/")._report()._fillinorganization(organization)._fillinabusename(abusename)._fillinabuseemail(abuseemail)._fillinabuselinks(abuselinks)._fillinabusedoc(abusedoc)._fillinabusetext(abusetext)._sendreport();
        }
    }
}
