
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
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");

        driver = new ChromeDriver(options);
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
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        driver.FindElement(By.LinkText("Індекс")).Click();
        driver.FindElement(By.LinkText("Ґа")).Click();
        driver.FindElement(By.Id("ooui-php-2")).Click();
        driver.FindElement(By.Id("ooui-php-2")).SendKeys("в");
        driver.FindElement(By.CssSelector(".oo-ui-inputWidget-input > .oo-ui-labelElement-label")).Click();
        driver.FindElement(By.LinkText("Попередня сторінка (Яшовець)")).Click();
    }

    [Test]
    public void test2()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        driver.FindElement(By.LinkText("Вибрані статті")).Click();
        driver.FindElement(By.LinkText("Критерії")).Click();
        driver.FindElement(By.LinkText("Відмова від відповідальності")).Click();
        driver.FindElement(By.LinkText("Розробники")).Click();
    }

    [Test]
    public void test3()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        driver.FindElement(By.LinkText("Портал спільноти")).Click();
        driver.FindElement(By.LinkText("Вікіфікуйте")).Click();
    }

    [Test]
    public void test4()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
       // driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        driver.FindElement(By.LinkText("Стиль")).Click();
        driver.FindElement(By.LinkText("Вікіпедія:Стиль викладу")).Click();
        driver.FindElement(By.LinkText("правило чи настанову")).Click();
    }
    [Test]
    public void test5()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        driver.FindElement(By.LinkText("Таблиці")).Click();
        driver.FindElement(By.LinkText("Polski")).Click();
    }
    [Test]
    public void test6()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        js.ExecuteScript("window.scrollTo(0,890)");
        js.ExecuteScript("window.scrollTo(0,1070)");
        driver.FindElement(By.CssSelector("#mf-his td:nth-child(2) a")).Click();
        driver.FindElement(By.LinkText("Вікісховище")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(6) > td:nth-child(17) > a")).Click();
        driver.FindElement(By.LinkText("15 May, by year")).Click();
    }
    [Test]
    public void test7()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1296, 696);
        driver.FindElement(By.LinkText("Переглянути історію")).Click();
        driver.FindElement(By.CssSelector(".mw-history-compareselectedversions:nth-child(4) > .historysubmit")).Click();
        driver.FindElement(By.LinkText("переглянути вихідний код")).Click();
    }

    [Test]
    public void test8()
    {
        driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki/%D0%93%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B0_%D1%81%D1%82%D0%BE%D1%80%D1%96%D0%BD%D0%BA%D0%B0");
        //driver.Manage().Window.Size = new System.Drawing.Size(1280, 680);
        driver.FindElement(By.CssSelector("#ca-talk > a")).Click();
        driver.FindElement(By.LinkText("Кнайпі")).Click();
        driver.FindElement(By.CssSelector("div > .plainlinks:nth-child(3) .mw-ui-button")).Click();
        driver.FindElement(By.CssSelector(".mw-ui-progressive")).Click();
    }
}
