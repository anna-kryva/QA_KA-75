using System;

using NUnit.Framework;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using UnitTestProject2.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject2
{
    [TestFixture]
    public class UnitTest1
    {

        private IWebDriver driver;
        private string _url = "https://moonvillageassociation.org/";

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(d => d.Url == _url);

            driver.FindElement(By.ClassName("accept")).Click();
            
        }

        [TearDown]
        public void TestCleanup()
        {
            driver.Close();
        }


        [Test]
        public void Test_Newsletter()
        {
            MainPage newpage = new MainPage(driver)
                .LoadPage()
                .FillIncorrect()
                .Submit();
            
            Assert.IsTrue(newpage.AlertPresent(driver));
        }


        [Test]
        public void Test_email_val()
        {
            ContactPage newpage = new ContactPage(driver)
                .LoadPage(driver)
                .FillIncorrect()
                .Submit();

            Assert.IsTrue(newpage.AlertMailPresent());
        }

        [Test]
        public void Test_agree_val()
        {
            ContactPage newpage = new ContactPage(driver)
                .LoadPage(driver)
                .Submit();

            Assert.IsTrue(newpage.AlertAgreePresent());
        }

        [Test]
        public void Test_downl()
        {
            DownlPage newpage = new DownlPage(driver)
                .LoadPage()
                .Submit();

            Assert.IsTrue(newpage.UploadCheck(driver));
        }

        [Test]
        public void Test_login_val()
        {
            LoginPage newpage = new LoginPage(driver)
                .LoadPage()
                .Fill()
                .Submit();

            Assert.IsTrue(newpage.AlertPresent());
        }

        [Test]
        public void Test_event_val()
        {
            EventPage newpage = new EventPage(driver)
                .LoadPage()
                .CleanField()
                .Fill()
                .ClickSomewhere();

            Assert.IsTrue(newpage.dateChanged());
        }

        [Test]
        public void Test_phone_val()
        {
            RegistrationPage newpage = new RegistrationPage(driver)
                .LoadPage()
                .FillMobileIncorrect()
                .Submit();

            Assert.IsTrue(newpage.AlertMobilePresent());
        }

        [Test]
        public void Test_date_val()
        {
            RegistrationPage newpage = new RegistrationPage(driver)
                .LoadPage()
                .FillDateIncorrect()
                .Submit();

            Assert.IsTrue(newpage.AlertDatePresent());
        }
    }
}
