using System;

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace UnitTestProject1
{
    [TestFixture]
    public class TaskUnitTest
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

        public bool isAlertPresents()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }// try
            catch (Exception e)
            {
                return false;
            }// catch
        }



        [Test]
        public void Test_Newsletter()
        {
            var fname = "qwerty";
            var lname = "qwerty";
            var mail = "qwerty@%#.com";

            driver.FindElement(By.Id("menu-item-2190")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            driver.FindElement(By.CssSelector("[name='FNAME']")).SendKeys(fname.ToString());
            driver.FindElement(By.CssSelector("[name='LNAME']")).SendKeys(lname.ToString());
            driver.FindElement(By.CssSelector("[name='EMAIL']")).SendKeys(mail.ToString());

            driver.FindElement(By.CssSelector("[value='Sign up']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            
            Assert.IsTrue(isAlertPresents());

        }

        [Test]
        public void Test_email_val()
        {
            var mail = "qwerty@%#.com";

            driver.FindElement(By.Id("menu-item-349")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.SwitchTo().Frame("iFrameResizer0");

            driver.FindElement(By.CssSelector("[name='control7209631']")).SendKeys(mail.ToString());
            

            IWebElement element = driver.FindElement(By.CssSelector("[value='SUBMIT FORM']"));
            
            driver.FindElement(By.CssSelector("[value='SUBMIT FORM']")).Click();
            driver.FindElement(By.CssSelector("[value='SUBMIT FORM']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string atext = driver.FindElement(By.Id("id123-fielderror7209631")).GetAttribute("innerText");
           
            Assert.IsTrue(atext.ToLower().Contains("expected input: email"), $"expected '{atext}' to contain 'expected input: email'");

        }

        [Test]
        public void Test_agree_val()
        {

            driver.FindElement(By.Id("menu-item-349")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.SwitchTo().Frame("iFrameResizer0");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            
            driver.FindElement(By.CssSelector("[value='SUBMIT FORM']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string atext = driver.FindElement(By.Id("id123-fielderror7643121")).GetAttribute("innerText");

            Assert.IsTrue(atext.ToLower().Contains("this field is required."), $"expected '{atext}' to contain 'this field is required.'");
            
        }
        
        [Test]
        public void Test_downl()
        {
            
            driver.Navigate().GoToUrl("https://moonvillageassociation.org/white-paper-of-the-architectural-concepts-wg");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement element = driver.FindElement(By.ClassName("button"));

            Actions actions = new Actions(driver);

            actions.MoveToElement(element).Click().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);
            String url = driver.Url;


            Assert.IsTrue(url.Contains("moonvillageassociation.org/wp-content/uploads/"));

        }

        [Test]
        public void Test_login_val()
        {

            var username = "qwerty";

            IWebElement hoverElement = driver.FindElement(By.Id("menu-item-666"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(hoverElement).Perform();
            
            driver.FindElement(By.Id("menu-item-742")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            
            driver.FindElement(By.CssSelector("[name='log']")).SendKeys(username.ToString());
            
            driver.FindElement(By.CssSelector("[name='wp-submit']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string atext = driver.FindElement(By.Id("login_error")).GetAttribute("innerText");

            Assert.IsTrue(atext.ToLower().Contains("the password field is empty"), $"expected '{atext}' to contain 'The password field is empty'");

        }

        [Test]
        public void Test_event_val()
        {

            var username = "684654.561.65";

            IWebElement hoverElement = driver.FindElement(By.Id("menu-item-497"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(hoverElement).Perform();

            driver.FindElement(By.Id("menu-item-1662")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            driver.FindElement(By.CssSelector("[name='tribe-bar-date']")).SendKeys(Keys.Control + "a");
            driver.FindElement(By.CssSelector("[name='tribe-bar-date']")).SendKeys(Keys.Delete);
            driver.FindElement(By.CssSelector("[name='tribe-bar-date']")).SendKeys(username.ToString());
            IWebElement moveElement = driver.FindElement(By.ClassName("tribe-events-page-title"));
            Actions builder2 = new Actions(driver);
            builder2.MoveToElement(moveElement).Click().Perform();
            
       
            string atext = driver.FindElement(By.CssSelector("[name='tribe-bar-date']")).GetAttribute("value");


            Assert.AreNotEqual(atext, "684654.561.65");
            
        }

        [Test]
        public void Test_phone_val()
        {



            var username = "qwerty";
            
            driver.FindElement(By.Id("menu-item-206")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            IWebElement scroll = driver.FindElement(By.Id("text-7"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(scroll);
            actions.Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.Id("post-156")).Click();

            IWebElement scroll1 = driver.FindElement(By.Id("text-7"));
            Actions actions1 = new Actions(driver);
            actions1.MoveToElement(scroll1).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.ClassName("mepr-price-box-button")).Click();

            

            driver.FindElement(By.CssSelector("[name='mepr_mobile']")).SendKeys(username.ToString());

            IWebElement scroll2 = driver.FindElement(By.ClassName("mepr-submit"));
            Actions actions2 = new Actions(driver);
            actions2.MoveToElement(scroll2).Perform();
            driver.FindElement(By.ClassName("mepr-submit")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string atext = driver.FindElement(By.CssSelector("[name='mepr_mobile']")).GetAttribute("class");
            
            Assert.IsTrue(atext.ToLower().Contains("invalid"), $"expected '{atext}' to contain 'invalid'");
            
        }

        [Test]
        public void Test_date_val()
        {

            var date = "8989098709";
            
            driver.FindElement(By.Id("menu-item-206")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("post-156")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.ClassName("mepr-price-box-button")).Click();



            driver.FindElement(By.CssSelector("[name='mepr_date_of_birth']")).SendKeys(date.ToString());

            IWebElement scroll2 = driver.FindElement(By.ClassName("mepr-submit"));
            Actions actions2 = new Actions(driver);
            actions2.MoveToElement(scroll2).Perform();
            driver.FindElement(By.ClassName("mepr-submit")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string atext = driver.FindElement(By.CssSelector("[name='mepr_date_of_birth']")).GetAttribute("class");

            Assert.IsTrue(atext.ToLower().Contains("invalid"), $"expected '{atext}' to contain 'invalid'");

        }

    }
}