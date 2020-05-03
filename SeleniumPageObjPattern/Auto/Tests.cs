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
            string contact_name = "ывавып";
            string contact_surname = "ывавып";
            string contact_middlename = "ывавып";
            string contact_email = "uawe@gmail.com";

            PgObj._gotopage("https://www.analizfamilii.ru/")._fillincontactsurname(contact_name)._fillincontactname(contact_surname)._fillincontactmiddlename(contact_middlename)._fillincontactemail(contact_email)._startgenetree();
            
            Assert.AreEqual("https://www.analizfamilii.ru/login.php", PgObj.GetCurrentUrl());
        }


        [Test]
        public void Test2()
        {
            string top_name = "ывааып";
            string date = "2000.2000.2000";

            PgObj._gotopage("https://www.analizfamilii.ru/")._fillintopname(top_name)._starttopsearch()._wait()._fillindate(date)._wait();
            
            Assert.AreEqual("Не верный формат даты рождения", PgObj.GetDateCheckMessage());
        }
        

        [Test]
        public void Test3()
        {
            string top_name = "ывааып";
            string email = "#%@%$@#.com";

            PgObj._gotopage("https://www.analizfamilii.ru/")._fillintopname(top_name)._starttopsearch()._wait()._fillinemail(email)._wait();

            Assert.AreEqual("Некорректный адрес e-mail", PgObj.GetEmailCheckMessage());
        }
      

        [Test]
        public void Test4()
        {
            string Surname = "ывааып2";

            PgObj._gotopage("https://www.analizfamilii.ru/")._fillinsurname(Surname)._startanalysis().CheckAlert();
        }
       

        [Test]
        public void Test5()
        {
            string Surname = "ывааып";

            PgObj._gotopage("https://www.analizfamilii.ru/")._fillinsurname(Surname)._startanalysis().GoBack();

            Assert.AreEqual("ывааып", PgObj.GetSurname());
        }

        [Test]
        public void Test6()
        {
            string login = "qwerty@qwerty.com";

            PgObj._gotopage("https://www.analizfamilii.ru/rec.php")._fillinlogin(login)._wait()._submit().CheckAlert();
        }

        [Test]
        public void Test7()
        {
            PgObj._gotopage("https://www.analizfamilii.ru/")._startphoto().CheckSideBar();
        }


        [Test]
        public void Test8()
        {
            string contact_name = "ывавып";
            string contact_surname = "ывавып";
            string contact_middlename = "ывавып";
            string contact_email = "uawe@gmail.com";

            PgObj._gotopage("https://www.analizfamilii.ru/")._fillincontactsurname(contact_name)._fillincontactname(contact_surname)._fillincontactmiddlename(contact_middlename)._fillincontactemail(contact_email)._startgenetree().GoBack();

            Assert.AreEqual("ывавып", PgObj.GetContactSurname());
        }
    }
}
