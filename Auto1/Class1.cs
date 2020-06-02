
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class Test1Test
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test]
    public void test1()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.Id("story")).Click();
        driver.FindElement(By.Id("story")).SendKeys("перси джексон");
        driver.FindElement(By.LinkText("Поиск")).Click();
        driver.FindElement(By.CssSelector(".shortpost:nth-child(4) img:nth-child(1)")).Click();
        js.ExecuteScript("window.scrollTo(0,418.6666564941406)");
    }

    [Test]
    public void test2()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.Id("login_button")).Click();
        driver.FindElement(By.Id("login_name")).Click();
        {
            var element = driver.FindElement(By.Id("login_name"));
            Actions builder = new Actions(driver);
            builder.DoubleClick(element).Perform();
        }
        driver.FindElement(By.Id("login_name")).SendKeys("roman@gmail.com");
        driver.FindElement(By.Id("login_password")).Click();
        driver.FindElement(By.Id("login_password")).SendKeys("12345678");
        driver.FindElement(By.Name("image")).Click();
    }

    [Test]
    public void test5()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.LinkText("Криминальные")).Click();
        driver.FindElement(By.LinkText("Дате")).Click();
    }

    [Test]
    public void test6()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.LinkText("Помощь")).Click();
        driver.FindElement(By.CssSelector(".hfeedback")).Click();
        driver.FindElement(By.Name("name")).Click();
        driver.FindElement(By.Name("name")).SendKeys("меню");
        driver.FindElement(By.Name("email")).Click();
        driver.FindElement(By.Name("email")).SendKeys("romadep228@gmail.com");
        driver.FindElement(By.Name("subject")).Click();
        driver.FindElement(By.Name("subject")).SendKeys("сдача лаб");
        driver.FindElement(By.Name("message")).Click();
        driver.FindElement(By.Name("message")).SendKeys("помогите сделать лабу");
        driver.FindElement(By.CssSelector(".fbutton > span")).Click();
    }

    [Test]
    public void test9()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.LinkText("Для правообладателей")).Click();
        driver.FindElement(By.Id("abuse_organization")).Click();
        driver.FindElement(By.Id("abuse_organization")).SendKeys("kpi");
        driver.FindElement(By.Id("abuse_name")).Click();
        driver.FindElement(By.Id("abuse_name")).SendKeys("laba");
        driver.FindElement(By.Id("abuse_email")).Click();
        driver.FindElement(By.Id("abuse_email")).SendKeys("laba@ukr.net");
        driver.FindElement(By.Id("abuse_links")).Click();
        driver.FindElement(By.Id("abuse_links")).SendKeys("ghjk");
        driver.FindElement(By.Id("abuse_document")).Click();
        driver.FindElement(By.Id("abuse_document")).SendKeys("ghjkhg");
        driver.FindElement(By.Id("abuse_text")).Click();
        driver.FindElement(By.Id("abuse_text")).SendKeys("ghjkhg");
        driver.FindElement(By.Name("send_btn")).Click();
    }

    [Test]
    public void test10()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.Id("login_button")).Click();
        driver.FindElement(By.LinkText("Восстановить пароль")).Click();
        js.ExecuteScript("window.scrollTo(0,140)");
        driver.FindElement(By.Name("lostname")).Click();
        driver.FindElement(By.Name("lostname")).SendKeys("hjkjh");
        driver.FindElement(By.CssSelector(".fbutton > span")).Click();
    }

    [Test]
    public void test11()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.CssSelector(".next")).Click();
        driver.FindElement(By.CssSelector(".next")).Click();
        driver.FindElement(By.CssSelector(".next")).Click();
        driver.FindElement(By.CssSelector(".prev")).Click();
        driver.FindElement(By.CssSelector(".prev")).Click();
        driver.FindElement(By.CssSelector(".prev")).Click();
    }

    [Test]
    public void test13()
    {
        driver.Navigate().GoToUrl("http://baskino.me/");
        driver.FindElement(By.LinkText("Рейтингу")).Click();
        driver.FindElement(By.CssSelector(".navigation > a:nth-child(3)")).Click();
        driver.FindElement(By.CssSelector(".navigation > a:nth-child(4)")).Click();
        driver.FindElement(By.LinkText("Вперед")).Click();
        driver.FindElement(By.LinkText("1985")).Click();
    }
}
