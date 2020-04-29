using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace KaggleSeleniumTesting
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        private string _email;
        private string _password;

        [SetUp]
        public void StartDriver()
        {
            _email = Environment.GetEnvironmentVariable("EMAIL_KAGGLE");
            _password = Environment.GetEnvironmentVariable("PASSWORD_KAGGLE");

            ChromeOptions chromeOptions = new ChromeOptions();
            // chromeOptions.AddArguments("headless");
            
            _driver = new ChromeDriver(chromeOptions);
        }

        [TearDown]
        public void StopDriver()
        {
            _driver.Close();
        }

        [Test]
        public void LeaveCommentLoggedIn()
        {
            const string expectedComment = "Awesome!";
            string actualComment;
            
            LogIn(5);
            _driver.Url = "https://www.kaggle.com/discussion";
            _driver.Url = FindElement(By.XPath("//*[@id='site-content']/div[2]/div[2]/div[2]/div/div[2]/div[2]/div/div[1]/div/a"),
                5).GetAttribute("href");

            IWebElement commentElement = FindElement(
                By.XPath("//div[span/span/a/text() = 'VVRudenko']" +
                         "//div[@class='markdown-converter__text--rendered']/p"), 5);
            if (commentElement is null)
            {
                FindElement(By.XPath("//textarea[@id='placeholder-input']"), 5).Click();
                FindElement(By.XPath("//textarea[@class='react-mentions__input']"), 5).SendKeys(expectedComment);
                FindElement(By.XPath("//a[contains(@class, 'button__anchor-wrapper')]"), 5).Click();
                Thread.Sleep(5000);
                _driver.Navigate().Refresh();
                actualComment = FindElement(
                    By.XPath("//div[span/span/a/text() = 'VVRudenko']" +
                             "//div[@class='markdown-converter__text--rendered']/p"), 5).Text;
            }
            else actualComment = commentElement.Text;
            StringAssert.AreEqualIgnoringCase(expectedComment, actualComment);
        }

        [Test]
        public void LeaveCommentLoggedOut()
        {
            const string expectedString = "Please sign in to leave a comment.";
            
            _driver.Url = "https://www.kaggle.com/discussion";
            _driver.Url = FindElement(By.XPath("//*[@id='site-content']/div[2]/div[2]/div[2]/div/div[2]/div[2]/div/div[1]/div/a"),
                5).GetAttribute("href");
            
            string actualString = FindElement(
                By.XPath("//div[@class='comment-list__login-warning']"), 5).Text;

            StringAssert.AreEqualIgnoringCase(expectedString, actualString);
        }

        [Test]
        public void CreateDatasetLoggedIn()
        {
            LogIn(5);

            _driver.Url = "https://www.kaggle.com/datasets";
            FindElement(By.XPath("//*[@id='site-content']/div[2]/div[1]/div/div[2]/div/button"), 5).Click();
            IWebElement createDatasetElement = FindElement(
                By.XPath("//div[@class='ReactModalPortal']//input[@placeholder='Enter Dataset Title']"), 5);
            if (createDatasetElement is null) Assert.Fail();
            else Assert.Pass();
        }
        
        [Test]
        public void CreateDatasetLoggedOut()
        {
            _driver.Url = "https://www.kaggle.com/datasets";
            FindElement(By.XPath("//*[@id='site-content']/div[2]/div[1]/div/div[2]/div/button"), 5).Click();
            IWebElement createDatasetElement = FindElement(
                By.XPath("//div[@class='ReactModalPortal']//input[@placeholder='Enter Dataset Title']"), 5);
            if (createDatasetElement is null) Assert.Pass();
            else Assert.Fail();
        }

        [Test]
        public void DownloadDataLoggedIn()
        {
            string expectedLink = "https://www.kaggle.com/c/10684/download-all";
            LogIn(5);

            _driver.Url = "https://www.kaggle.com/c/vsb-power-line-fault-detection/data";
            string actualLink = FindElement(
                By.XPath("//*[@id='comp-data-download-all']"), 5).GetAttribute("href");
            Console.WriteLine(actualLink);
            StringAssert.AreEqualIgnoringCase(expectedLink, actualLink);
        }
        
        [Test]
        public void DownloadDataLoggedOut()
        {
            string expectedLink = "https://www.kaggle.com/account/" +
                                  "login?returnUrl=%2Fc%2Fvsb-power-line-fault-detection%2Frules%3Fcontinue%3Ddata";

            _driver.Url = "https://www.kaggle.com/c/vsb-power-line-fault-detection/data";
            string actualLink = FindElement(
                By.XPath("//*[@id='comp-data-download-all']"), 5).GetAttribute("href");
            StringAssert.AreEqualIgnoringCase(expectedLink, actualLink);
        }
        
        [TestCase("VVRudenko", "Changes to your profile have been saved.")]
        [TestCase(" \b", "Please enter a display name.")]
        public void ChangeNickname(string nickname, string expectedResponse)
        {
            LogIn(5);
            _driver.Url = "https://www.kaggle.com/vrkaggler";
            FindElement(By.XPath("//a[contains(@class, 'pageheader__calltoaction')]"), 5).Click();
            IWebElement input = FindElement(
                By.XPath("//input[contains(@class, 'profile__display-name--input')]"),
                5);
            input.Clear();
            input.SendKeys(nickname);
            FindElement(By.XPath("//a[contains(@class, 'pageheader__calltoaction')]"), 5).Click();

            string actualResponse = FindElement(
                By.XPath("//span[contains(@class, 'pageheader__pagemessagecontent')]"),
                5).Text;
            StringAssert.AreEqualIgnoringCase(expectedResponse, actualResponse);
        }

        private IWebElement FindElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    return wait.Until(drv =>
                    {
                        try
                        {
                            Thread.Sleep(250);
                            return drv.FindElement(by);
                        }
                        catch (NoSuchElementException)
                        {
                        }
                        catch (StaleElementReferenceException)
                        {
                        }

                        return null;
                    });
                }
                catch (WebDriverTimeoutException)
                {
                    return null;
                }
            }
            return _driver.FindElement(by);
        }

        private void LogIn(int timeoutInSeconds)
        {
            _driver.Url = "https://kaggle.com";
            FindElement(By.XPath("//*[@id='site-container']/div/div[1]/div[2]/div[2]/div[1]/a/div/button"),
                    timeoutInSeconds).Click();
            FindElement(By.XPath("//*[@id='site-container']/div[1]/div/form/div[2]/div/div[2]/a/li"),
                timeoutInSeconds).Click();
            FindElement(By.Name("email"), timeoutInSeconds).SendKeys(_email);
            FindElement(By.Name("password"), timeoutInSeconds).SendKeys(_password);
            FindElement(By.XPath("//*[@id='site-container']/div[1]/div/form/div[2]/div[3]/div/button"),
                timeoutInSeconds).Click();
        }
    }
}