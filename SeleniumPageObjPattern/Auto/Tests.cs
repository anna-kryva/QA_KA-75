using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;
//using OpenQA.Selenium.Support.PageObjects;
//using System.Xml.XPath.XPathNavigator;

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
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
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
            
            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._index()._ga()._choose2()._choose3();

        }

        [Test]
        public void Test2()
        {

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._selectedArticles()._criteria()._disclaimer()._developers();

        }

        [Test]
        public void Test3()
        {

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._communityPortal()._wikiquote();

        }

        [Test]
        public void Test4()
        {

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._updateCache()._ok();

        }

        [Test]
        public void Test5()
        {

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._tables()._polski();

        }

        [Test]
        public void Test6()
        {

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._choose4()._wikimediaCommons()._choose5()._mayByYear();

        }

        [Test]
        public void Test7()
        {

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._viewHistory()._choose6()._viewSourceCode();

        }

        [Test]
        public void Test8()
        {
            string name = "hjdkshf";
            string password = "123";

            PgObj._gotopage("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0")._entrence()._nameUser(name)._password(password)._login();

        }
    }
}
