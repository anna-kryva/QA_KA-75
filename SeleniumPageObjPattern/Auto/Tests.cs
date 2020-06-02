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
            string login = "Julis2@ukr.net";
            string password = "098765";

            PgObj._gotopage("https://bukva.ua/ua")._entrence()._fillinlogin(login)._fillinpassword(password)._entrencebutton();

            Assert.AreEqual("https://bukva.ua/ua/account/personal", PgObj.GetCurrentUrl());
        }

        [Test]
        public void Test2()
        {
            string login = "klop";
            string password = "klop";

            PgObj._gotopage("https://bukva.ua/ua")._entrence()._fillinlogin(login)._fillinpassword(password)._entrencebutton()._entrence();

            //Assert.AreEqual("Не вірний логін або пароль", PgObj.GetLoginCheckMessage());
        }

        [Test]
        public void Test3()
        {
            PgObj._gotopage("https://bukva.ua/ua/catalog/browse/312/1/757553")._grade()._gradeButton();

            //Assert.AreEqual("Дякуємо, Ваш голос прийнято!", PgObj.GetGradeCheckMessage());
        }

        [Test]
        public void Test4()
        {
            string name = "klop";
            string comment = "хорошая книга";

            PgObj._gotopage("https://bukva.ua/ua/catalog/browse/1436/1/757638")._fillinName(name)._fillinComment(comment)._addComment();

            //Assert.AreEqual("Коментар успішно додано", PgObj.GetCommentCheckMessage());
        }
        [Test]
        public void Test5()
        {
            string login = "Julis2@ukr.net";
            string password = "098765";
            string comment = "хорошая книга";

            PgObj._gotopage("https://bukva.ua/ua")._entrence()._fillinlogin(login)._fillinpassword(password)._entrencebutton()._top20()._buy()._fillinComment(comment)._addComment();
        }

        [Test]
        public void Test6()
        {
            string pricelow = "100";
            string pricehigh = "150";

            PgObj._gotopage("https://bukva.ua/ua")._otherbook()._company()._advancedsearch()._pricelow(pricelow)._pricehigh(pricehigh)._search();

            //Assert.AreEqual("Такої адреси електронної пошти немає в системі", PgObj.GetEmailCheckMessage());
        }

        [Test]
        public void Test7()
        {
            string login = "Julis2@ukr.net";
            string password = "098765";
            string card = "123";

            PgObj._gotopage("https://bukva.ua/ua")._entrence()._fillinlogin(login)._fillinpassword(password)._entrencebutton()._diskontCard()._fillincard(card)._registerCard();

            //Assert.AreEqual("Поле 13 цифр із зворотної сторони картки повинно містити у точності 13 символів", PgObj.GetCardCheckMessage());
        }
        [Test]
        public void Test8()
        {
            PgObj._gotopage("https://bukva.ua/ua")._book()._vsevolod()._sort();
        }
    }
}
