using System;

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;



namespace Task2Selenium
{
    [TestFixture]
    public class UnitTests
    {
        private ChromeDriver driver;
        private string _url = "https://avtoshtraf.com/";

        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TestCleanup()
        {
           driver.Close();
        }


        [Test]
        public void Checkbox_check()
        {

            driver.FindElementByCssSelector(".about button").Click();
            Thread.Sleep(1000);

            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            Thread.Sleep(100);

            driver.FindElementByCssSelector(".buttons button").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

        }
        [Test]
        public void Inputs_notfill_check()
        {
            string expected = "Заповніть усі відповіді!";

            driver.FindElementByCssSelector(".about button").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(1000);

            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElementByCssSelector(".buttons button").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(1000);

            driver.FindElementByCssSelector(".PrepareQuestionsPage button").Click();
            Thread.Sleep(1000);

            string res = driver.FindElementByCssSelector("div[role='alert']").Text;

            Assert.AreEqual(expected, res);

        }
        [Test]
        public void Inputs_filling()
        {

            driver.FindElementByCssSelector(".about button").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Thread.Sleep(1000);

            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElementByCssSelector(".buttons button").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(2000);

            driver.FindElementByCssSelector(".Item :first-child").Click();
            Thread.Sleep(500);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(500);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(500);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(500);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(500);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(500);

            driver.FindElementByCssSelector(".PrepareQuestionsPage button").Click();
            Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://avtoshtraf.com/declaration");
        }
        [Test]
        public void Help_check()
        {
            string name = "Въячеслав Украинцев";
            string tel = "+8800 555 35 35";

            driver.FindElementByCssSelector(".Section1_2 :nth-child(2) button").Click();
            Thread.Sleep(200);

            driver.FindElementByCssSelector(".ModalBodyHelp input[name='Name']").SendKeys(name);
            driver.FindElementByCssSelector(".ModalBodyHelp input[name='Telephone']").SendKeys(tel);
            Thread.Sleep(200);

            Assert.AreEqual(driver.Url, "https://avtoshtraf.com/");
        }
        [Test]
        public void Send_data_check()
        {
            string name = "Въячеслав Украинцев";
            string expected = "Оплатити 50 UAH";

            driver.FindElementByCssSelector(".about button").Click();
            Thread.Sleep(1000);
            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            driver.FindElementByCssSelector(".buttons button").Click();
            Thread.Sleep(1000);

            driver.FindElementByCssSelector(".Item :first-child").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);

            driver.FindElementByCssSelector(".PrepareQuestionsPage button").Click();
            Thread.Sleep(1000);

            driver.FindElementByXPath("//*[@id='root']/div/div[2]/div/form/div/label[1]/input").SendKeys(name);
            driver.FindElementByCssSelector("button[type='submit']").Click();
            Thread.Sleep(1000);

            string result = driver.FindElementByXPath("//*[@id='root']/div/div[2]/div/div/form/button").Text;
            Assert.AreEqual(result.ToLower(), expected.ToLower());
        }
        [Test]
        public void Check_Modal()
        {
            string expected = "Переписати зі свідоцтва про реєстрацію транспортного засобу";

            driver.FindElementByCssSelector(".about button").Click();
            Thread.Sleep(1000);
            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            driver.FindElementByCssSelector(".buttons button").Click();
            Thread.Sleep(1000);

            driver.FindElementByCssSelector(".Item :first-child").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);

            driver.FindElementByCssSelector(".PrepareQuestionsPage button").Click();
            Thread.Sleep(1000);

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElementByCssSelector(".b4 .carModel span")).Perform();
        }
        [Test]
        public void Date_check()
        {
            string expected = "2020-04-23";

            driver.FindElementByCssSelector(".about button").Click();
            Thread.Sleep(1000);
            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            driver.FindElementByCssSelector(".buttons button").Click();
            Thread.Sleep(1000);

            driver.FindElementByCssSelector(".Item :first-child").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);

            driver.FindElementByCssSelector(".PrepareQuestionsPage button").Click();
            Thread.Sleep(1000);

            driver.FindElementByXPath("//*[@id='root']/div/div[2]/div/form/div/div[2]/div[2]/label[1]/div[2]/span").Click();
            Thread.Sleep(1000);

            driver.FindElementByCssSelector("div[aria-label='day-23']").Click();
            Thread.Sleep(500);

            string result = driver.FindElementByXPath("//*[@id='root']/div/div[2]/div/form/div/div[2]/div[2]/label[1]/div[2]/div[1]/div/input").GetAttribute("value");
            Assert.AreEqual(result.ToLower(), expected.ToLower());
        }
        [Test]
        public void Sending_check()
        {
            string name = "Майкл Джордан";
            string expected = "https://www.liqpay.ua";

            driver.FindElementByCssSelector(".about button").Click();
            Thread.Sleep(1000);
            driver.FindElementByCssSelector("input[type='checkbox']").Click();
            driver.FindElementByCssSelector(".buttons button").Click();
            Thread.Sleep(1000);

            driver.FindElementByCssSelector(".Item :first-child").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(1)").Click();
            Thread.Sleep(200);
            driver.FindElementByCssSelector(".qa > :last-child > :nth-child(2)").Click();
            Thread.Sleep(200);

            driver.FindElementByCssSelector(".PrepareQuestionsPage button").Click();
            Thread.Sleep(1000);

            driver.FindElementByXPath("//*[@id='root']/div/div[2]/div/form/div/label[1]/input").SendKeys(name);
            driver.FindElementByCssSelector("button[type='submit']").Click();
            Thread.Sleep(500);
            driver.FindElementByXPath("//*[@id='root']/div/div[2]/div/div/form/button").Click();
            Thread.Sleep(2000);

            Assert.AreEqual(driver.Url.Substring(0, 21), expected);
        }
    }
}
