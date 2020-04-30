using NUnit.Framework;
using System;
using OpenQA.Selenium.Chrome;

namespace Auto
{
    [TestFixture]
    public class Tests_Main
    {
        private ChromeDriver driver;
        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void finish()
        {
            driver.Close();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("input[id=contact_surname]").SendKeys("ывавып");
            driver.FindElementByCssSelector("input[id=contact_name]").SendKeys("ывавпа");
            driver.FindElementByCssSelector("input[id=contact_middlename]").SendKeys("ывавпа");
            driver.FindElementByCssSelector("input[id=contact_email]").SendKeys("uawe@gmail.com");
            driver.FindElementByCssSelector("input[value=' Начать составление Вашего генеалогического дерева ']").Click();
            Assert.AreEqual(driver.Url, "https://www.analizfamilii.ru/login.php");
        }


        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("input[id=top_s]").SendKeys("ывааып");
            driver.FindElementByCssSelector("input[value = 'Найти']").Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElementByCssSelector("input[id = 'birth_date']").SendKeys("2000.2000.2000");
            System.Threading.Thread.Sleep(2000);
            Assert.AreEqual(driver.FindElementByCssSelector("img[id = birth_date_check]").GetAttribute("title"), "Не верный формат даты рождения");
        }


        [Test]
        public void Test3()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("input[id=top_s]").SendKeys("ывааып");
            driver.FindElementByCssSelector("input[value = 'Найти']").Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElementByCssSelector("input[id = email]").SendKeys("##%@%$@#.com");
            System.Threading.Thread.Sleep(2000);
            Assert.AreEqual(driver.FindElementByCssSelector("img[id = email_check]").GetAttribute("title"), "Некорректный адрес e-mail");
        }


        [Test]
        public void Test4()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("input[id=surname]").SendKeys("ывааып2");
            driver.FindElementByCssSelector("input[value = ' Проанализировать фамилию ']").Click();
            driver.SwitchTo().Alert().Accept();
        }


        [Test]
        public void Test5()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("input[id=surname]").SendKeys("ывааып");
            driver.FindElementByCssSelector("input[value = ' Проанализировать фамилию ']").Click();
            driver.Navigate().Back();
            Assert.AreEqual(driver.FindElementByCssSelector("input[id=surname]").GetAttribute("value"), "ывааып");
            
        }


        [Test]
        public void Test6()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/rec.php");
            driver.FindElementByCssSelector("input[id='login']").SendKeys("qwerty@qwerty.com");
            System.Threading.Thread.Sleep(2000);
            driver.FindElementByCssSelector("input[id = submitFormRec]").Click();
            Assert.IsTrue(driver.SwitchTo().Alert().Text.Contains("Отметь"));
            driver.SwitchTo().Alert().Accept();
        }


        [Test]
        public void Test7()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("a[href='https://www.analizfamilii.ru/foto/']").Click();
            Assert.AreEqual(driver.FindElementByCssSelector("td[class =b]").GetAttribute("style"), "color: red;");
        }


        [Test]
        public void Test8()
        {
            driver.Navigate().GoToUrl("https://www.analizfamilii.ru/");
            driver.FindElementByCssSelector("input[id=contact_surname]").SendKeys("ывавып");
            driver.FindElementByCssSelector("input[id=contact_name]").SendKeys("ывавпа");
            driver.FindElementByCssSelector("input[id=contact_middlename]").SendKeys("ывавпа");
            driver.FindElementByCssSelector("input[id=contact_email]").SendKeys("uawe@gmail.com");
            driver.FindElementByCssSelector("input[value=' Начать составление Вашего генеалогического дерева ']").Click();
            driver.Navigate().Back();
            Assert.AreEqual(driver.FindElementByCssSelector("input[id=contact_surname]").GetAttribute("value"), "ывавып");
        }
    }
}
