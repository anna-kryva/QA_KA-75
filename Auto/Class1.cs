using NUnit.Framework;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
        public void iioio()
        {
            // Test name: iioio
            // Step # | name | target | value
            // 1 | open | /ua | 
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            // 2 | setWindowSize | 1004x498 | 
            //driver.Manage().Window.Size = new System.Drawing.Size(1004, 498);
            // 3 | click | linkText=Вхід | 
            driver.FindElement(By.LinkText("Вхід")).Click();
            // 4 | click | id=txtLogin | 
            driver.FindElement(By.Id("txtLogin")).Click();
            // 5 | type | id=txtLogin | Julis2@ukr.net
            driver.FindElement(By.Id("txtLogin")).SendKeys("Julis2@ukr.net");
            // 6 | click | id=txtPassword | 
            driver.FindElement(By.Id("txtPassword")).Click();
            // 7 | type | id=txtPassword | 098765
            driver.FindElement(By.Id("txtPassword")).SendKeys("098765");
            // 8 | click | css=.btn:nth-child(16) | 
            driver.FindElement(By.CssSelector(".btn:nth-child(16)")).Click();
        }

        [Test]
        public void test2()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1004, 498);
            driver.FindElement(By.LinkText("Вхід")).Click();
            driver.FindElement(By.Id("txtLogin")).Click();
            driver.FindElement(By.Id("txtLogin")).SendKeys("klop");
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).SendKeys("klop");
            driver.FindElement(By.CssSelector(".btn:nth-child(16)")).Click();
            driver.FindElement(By.LinkText("Вхід")).Click();
        }

        [Test]
        public void test3()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1004, 498);
            //js.ExecuteScript("window.scrollTo(0,108.66666412353516)");
            driver.FindElement(By.CssSelector(".row:nth-child(3) > .col-xs-6:nth-child(5) img")).Click();
            //js.ExecuteScript("window.scrollTo(0,458)");
            //js.ExecuteScript("window.scrollTo(0,986.6666870117188)");
            driver.FindElement(By.CssSelector(".radio-inline:nth-child(5) > input")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs > .btn")).Click();
            //js.ExecuteScript("window.scrollTo(0,2)");
        }

        [Test]
        public void test4()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1004, 604);
            driver.FindElement(By.LinkText("Вхід")).Click();
            driver.FindElement(By.LinkText("Забули пароль?")).Click();
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).SendKeys("klop@ukr.net");
            driver.FindElement(By.CssSelector(".btn-primary > span")).Click();
        }

        [Test]
        public void test5()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1004, 604);
            driver.FindElement(By.LinkText("Вхід")).Click();
            driver.FindElement(By.Id("txtLogin")).Click();
            driver.FindElement(By.Id("txtLogin")).SendKeys("Julis2@ukr.net");
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).SendKeys("098765");
            driver.FindElement(By.CssSelector(".btn:nth-child(16)")).Click();
            driver.FindElement(By.LinkText("Зареєструвати Дисконтну картку")).Click();
            driver.FindElement(By.Name("card")).Click();
            driver.FindElement(By.Name("card")).SendKeys("123");
            driver.FindElement(By.CssSelector(".btn-primary > span")).Click();
        }

        [Test]
        public void test6()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
            driver.FindElement(By.Id("search_inp")).Click();
            driver.FindElement(By.Id("search_inp")).SendKeys("місто дівчат");
            driver.FindElement(By.CssSelector(".input-group-btn > .btn")).Click();
            driver.FindElement(By.CssSelector(".colorbox .price_text_left")).Click();
            driver.SwitchTo().Frame(1);
            driver.FindElement(By.CssSelector(".btn:nth-child(1)")).Click();
        }

        [Test]
        public void test7()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1050, 660);
            driver.FindElement(By.Id("search_inp")).Click();
            driver.FindElement(By.LinkText("Вхід")).Click();
            driver.FindElement(By.Id("txtLogin")).Click();
            driver.FindElement(By.Id("txtLogin")).SendKeys("Julis2@ukr.net");
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).SendKeys("098765");
            {
                var element = driver.FindElement(By.CssSelector(".btn:nth-child(16)"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.CssSelector(".btn:nth-child(16)")).Click();
            driver.FindElement(By.Id("search_inp")).Click();
            driver.FindElement(By.Id("search_inp")).SendKeys("мобі");
            driver.FindElement(By.CssSelector(".btn-primary:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".no2 .hidden-xs .price_text_left")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".no2 .hidden-xs .price_text_left"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.SwitchTo().Frame(1);
            driver.FindElement(By.CssSelector(".btn:nth-child(1)")).Click();
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.LinkText("Вийти")).Click();
            driver.FindElement(By.CssSelector(".col-md-1 .fa")).Click();
        }

        [Test]
        public void test8()
        {
            driver.Navigate().GoToUrl("https://bukva.ua/ua");
            //driver.Manage().Window.Size = new System.Drawing.Size(1050, 660);
            driver.FindElement(By.LinkText("Вхід")).Click();
            driver.FindElement(By.Id("txtLogin")).Click();
            driver.FindElement(By.Id("txtLogin")).SendKeys("Julis2@ukr.net");
            driver.FindElement(By.Id("txtPassword")).Click();
            driver.FindElement(By.Id("txtPassword")).SendKeys("098765");
            {
                var element = driver.FindElement(By.CssSelector(".btn:nth-child(16)"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.CssSelector(".btn:nth-child(16)")).Click();
            driver.FindElement(By.LinkText("Бестселлери")).Click();
            driver.FindElement(By.CssSelector(".col-xs-6:nth-child(5) .bukva-hiden:nth-child(5) .hidden-xs .price_text")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".col-xs-6:nth-child(5) .bukva-hiden:nth-child(5) .hidden-xs .price_text"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.CssSelector(".col-md-1 .fa")).Click();
            driver.SwitchTo().Frame(1);
            driver.FindElement(By.CssSelector(".btn:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(3)")).Click();
        }

    }
}
