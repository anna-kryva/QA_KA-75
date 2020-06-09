using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras;
using System;
using System.Collections.Generic;
using SeleniumUse;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SeleniumTests
{
    [TestFixture]
    public class Selenium
    {
        IWebDriver driver;
        string _url = "https://www.zendesk.com/contact/";
        WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 400));
            wait.Until(d => d.Url == _url);
        }
        [Test]
        public void TestLink()
        {
            driver.Navigate().GoToUrl("https://www.zendesk.com/");
        }

        [TestCase("/html/body/header/div/div[2]/nav/ul[2]/li[1]/span", "/html/body/header/div/div[2]/nav/ul[2]/li[1]/div")]
        [TestCase("/html/body/header/div/div[2]/nav/ul[2]/li[3]/span", "/html/body/header/div/div[2]/nav/ul[2]/li[3]/div")]
        [TestCase("/html/body/header/div/div[2]/nav/ul[2]/li[6]/span", "/html/body/header/div/div[2]/nav/ul[2]/li[6]/div")]
        public void DropDownItems_AfterHover_ShouldBeVisible(string itemXPath, string dropdownMenuXPath)
        {
            Actions actions = new Actions(driver);
            IWebElement link = driver.FindElement(By.XPath(itemXPath));
            actions.MoveToElement(link).Perform();
            bool is_displayed = link.FindElement(By.XPath(dropdownMenuXPath)).Displayed;
            Assert.IsTrue(is_displayed, "The dropdown menu is expected to be visible");
        }

        [Test]
        public void Contact_Sales_Popup_Must_Appear_After_Click()
        {
            IWebElement contact_btn = driver.FindElement(By.XPath("/html/body/article/section[1]/div[2]/div[2]/div[1]/div/a"));
            contact_btn.Click();
            bool is_displayed = driver.FindElement(By.XPath("/html/body/div[2]")).Displayed;
            Assert.IsTrue(is_displayed, "The contact sales popup is expected to be visible");
        }

        [Test]
        public void Go_to_the_help_center_Must_Redirect_to_Support_Page()
        {
            IWebElement go_to_btn = driver.FindElement(By.XPath("/html/body/article/section[1]/div[2]/div[2]/div[2]/div/a"));
            go_to_btn.Click();
            String currentURL = driver.Url;
            currentURL.Contains("https://support.zendesk.com/");
        }

        [TestCase("example1234@mail.com","some msg", "Tom", "Smith", "Company","5000+","+77077-777-77-77")]
        public void Contsct_Us_Request_Is_sent(String Work_email, String Message, String First_name, String Last_name, String Company_name, String Number_of_employees, String Phone_number)
        {
            IWebElement contact_btn = driver.FindElement(By.XPath("/html/body/article/section[1]/div[2]/div[2]/div[1]/div/a"));
            contact_btn.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='owner[email]']")).SendKeys(Work_email);
            driver.FindElement(By.XPath("//*[@id='question']")).SendKeys(Message);
            driver.FindElement(By.XPath("//*[@id='FirstName']")).SendKeys(First_name);
            driver.FindElement(By.XPath("//*[@id='LastName']")).SendKeys(Last_name);
            driver.FindElement(By.XPath("//*[@id='account[name]']")).SendKeys(Company_name);
            driver.FindElement(By.XPath("//*[@id='account[help_desk_size]']")).SendKeys(Number_of_employees);
            driver.FindElement(By.XPath("//*[@id='address[phone]']")).SendKeys(Phone_number);
            driver.FindElement(By.XPath("/html/body/div[2]/div/form/div[1]/div[8]/button")).Click();
            Thread.Sleep(10000);
            bool is_displayed = driver.FindElement(By.XPath("/html/body/div[2]/div/form/div[2]")).Displayed;
            Assert.IsTrue(is_displayed, "The 'Your request has been sent!' is expected to be visible");
        }

       
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
