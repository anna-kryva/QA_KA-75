using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras;
using System;
using System.Collections.Generic;

namespace SeleniumNUnit
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        string _url = "https://app.pipedrive.com/";
        WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));

            wait.Until(d => d.Url == _url);
        }

        [TestCase("examplemail.com")]
        public void InvalidEmail(string email)
        {
            driver.Navigate().GoToUrl("https://app.pipedrive.com/auth/login");
            IWebElement email_field = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[1]/input"));
            IWebElement email_error_field = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[2]"));
            IWebElement login_button = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[3]/button"));
            email_field.SendKeys(email);
            login_button.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(email_error_field, "Please add a valid email address"));
            Assert.AreEqual("Pleaseaddavalidemailaddress", email_error_field.Text);
        }

		[TestCase("@email.com")]
		public void InvalidEmailAdvanced(string email)
		{
			driver.Navigate().GoToUrl("https://app.pipedrive.com/auth/login");
			IWebElement email_field = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[1]/input"));
			IWebElement email_error_field = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[2]"));
			IWebElement login_button = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[3]/button"));
			email_field.SendKeys(email);
			login_button.Click();
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(email_error_field, "Please add a valid email address"));
			Assert.AreEqual("Pleaseaddavalidemailaddress", email_error_field.Text);
		}

		[TestCase("qwe@emailcom")]
		public void UnregisteredEmail(string email)
		{
			driver.Navigate().GoToUrl("https://app.pipedrive.com/auth/login/forgot_password");
			IWebElement email_field = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[1]/input"));
			IWebElement got_a_new_button = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div[1]/div/form/div/div[2]/button"));
			email_field.SendKeys(email);
			got_a_new_button.Click();
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/h1")));
			IWebElement check_inbox = driver.FindElement(By.XPath("driver.FindElement"));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(check_inbox, "Check your inbox"));
			Assert.AreNotEqual("Checkyourinbox", check_inbox.Text);
		}

		[Test]
        public void GoogleAuth()
        {
            driver.Navigate().GoToUrl("https://app.pipedrive.com/auth/login");
            IWebElement google_auth_button = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/div[2]/div[2]/div[1]/a"));
            google_auth_button.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://accounts.google.com/signin/oauth"));
            Assert.IsTrue(driver.Url.Contains("https://accounts.google.com/signin/oauth"));
        }

        [Test]
        public void SSOAuth()
        {
            driver.Navigate().GoToUrl("https://app.pipedrive.com/auth/login");
            IWebElement sso_auth_button = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div[1]/div/div[2]/div[2]/div[2]/a"));
            sso_auth_button.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://app.pipedrive.com/auth/sso"));
            Assert.IsTrue(driver.Url.Contains("https://app.pipedrive.com/auth/sso"));
        }

        [Test]
        public void TryItFreeButton()
        {
            driver.Navigate().GoToUrl("https://www.pipedrive.com/");
            IWebElement try_it_free_button = driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/div[2]/div[1]"));
            try_it_free_button.Click();
            IWebElement sing_up_popup = driver.FindElement(By.XPath("/html/body/div/div[7]/div[2]/div[1]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[7]/div[2]/div[1]")));
            Assert.IsTrue(sing_up_popup.Displayed);
        }

        [Test]
        public void DocumentationButton()
        {
            driver.Navigate().GoToUrl("https://developers.pipedrive.com/");
			IWebElement docs_button = driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[1]/a");
			docs_button.Click();
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://pipedrive.readme.io/docs"));
			Assert.IsTrue(driver.Url.Contains("https://pipedrive.readme.io/docs"));
		}

		[Test]
		public void APIButton()
		{
			driver.Navigate().GoToUrl("https://developers.pipedrive.com/");
			IWebElement api_button = driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[2]/a");
			api_button.Click();
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://developers.pipedrive.com/docs/api/"));
			Assert.IsTrue(driver.Url.Contains("https://developers.pipedrive.com/docs/api/"));
		}

		[Test]
		public void 
    }
}