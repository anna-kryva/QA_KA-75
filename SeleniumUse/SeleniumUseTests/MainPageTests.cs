using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras;
using System;
using System.Collections.Generic;
using SeleniumUse;

namespace SeleniumUseTests
{
    [TestFixture]
    public class FirstTrySelenium
    {
        IWebDriver driver;
        string _url = "https://www.unian.ua/";
        WebDriverWait wait;
        
        [SetUp]
        public void StartBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);

            wait = new WebDriverWait(driver, new TimeSpan(0,0,20));
            wait.Until(d => d.Url == _url); 
        }
        [Test]
        public void TestLink()
        {
            driver.Navigate().GoToUrl("https://www.unian.net/search?q=%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0&token=xLXMPYRZKVfm0icDmziXmxMU2iy_9QKbcBdeh0lf4Co&search_date=17.04.2020+-+17.04.2020&rubric_id=&news_title_only=1");           
        }

        [TestCase("Послуги")]
        [TestCase("Соцмережі")]
        [TestCase("Укр")]
        public void DropDownItems_AfterClick_ShouldBeVisible(string str)
        {
            IWebElement link= driver.FindElement(By.XPath("//li[contains(@class,'dropdown')]/..//a[contains(text(),'"+str+"')]"));
            link.Click();
            bool is_displayed = link.FindElement(By.XPath("..//ul")).Displayed;
            Assert.IsTrue(is_displayed, "The dropdown menu is expected to be visible");            
        }

        [TestCase("Укр","Вхід")]
        [TestCase("Eng","Login")]
        [TestCase("Рус", "Вход")]
        public void LoginButtonConctent_LanguageChange_ShouldChageContent(string lang,string login_str)
        {
            IWebElement lang_link= driver.FindElement(By.XPath("//*[@class='dropdown']/a"));
            lang_link.Click();
            if (!lang_link.Text.Contains(lang))
            {        
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='dropdown']//ul//a")));
                lang_link.FindElement(By.XPath("../ul//a[contains(text(),'" + lang + "')]")).Click();
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".sign a")));
            string res = driver.FindElement(By.CssSelector(".sign a")).Text;
            Assert.AreEqual(login_str, res, "Login buttons are different");
            
        }
        [TestCase("погода")]
        [TestCase("поранення")]
        [TestCase("жителька")]
        [TestCase("справа")]
        public void Search_ByTitle_ShouldReturnValidResults(string search_item)
        {            
            //search for specific item

            driver.FindElement(By.CssSelector(".text-right button")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".result-form__search input[name=q]")));
            IWebElement search_field = driver.FindElement(By.CssSelector(".result-form__search input[name=q]"));
            search_field.SendKeys(search_item);
            driver.FindElement(By.CssSelector("label[for=searchCheck2]")).Click();
            search_field.FindElement(By.XPath("../button")).Click();

            //check search results
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("span.search--query")));
            string result_item = driver.FindElement(By.CssSelector("span.search--query")).Text;
            StringAssert.Contains( result_item.Substring(0, result_item.Length - 1).ToLower(), search_item, String.Format("The search result expected to be {0}", search_item));
        }
        [TestCase("погода","04.03.2020")]
        [TestCase("поранення", "24.04.2020")]
        [TestCase("жителька", "08.04.2020")]
        [TestCase("справа", "23.04.2020")]

         
        public void Search_ByTitleAndOneDate_ShouldReturnListOfValidResults(string item,string date)
        {
            bool are_equal=true;
            string message="";
            IWebElement search_field;
            IWebElement search_date;

            //set search-word and search-date

            driver.FindElement(By.CssSelector(".text-right button")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".result-form__search input[name=q]")));
            search_field = driver.FindElement(By.CssSelector(".result-form__search input[name=q]"));
            search_field.SendKeys(item);
            driver.FindElement(By.CssSelector("label[for=searchCheck2]")).Click();
            search_date = driver.FindElement(By.CssSelector("[name=search_date]"));
            search_date.SendKeys(String.Concat(date," - ",date));
            search_field.FindElement(By.XPath("../button")).Click();

            //Check every result item using collection

            IList<IWebElement> search_results =  driver.FindElements(By.ClassName("news-inline-item"));
            foreach(IWebElement e in search_results)
            {
                string item_result = e.FindElement(By.ClassName("search--query")).Text;
                if (item.Contains(item_result.Substring(0,item_result.Length-1).ToLower()))
                {
                    string item_date_result = e.FindElement(By.ClassName("time")).Text;
                    if (!item_date_result.Contains(Help.ReplaceMonth(date)))
                    {
                        are_equal = false;
                        message = String.Format("Search date expected - {0}, but was - {1}", Help.ReplaceMonth(date), item_date_result);
                        break;
                    }
                }
                else
                {
                    are_equal = false;
                    message = String.Format("The search result expected to be {0},but was - {1}", item,item_result);
                    break;
                }                                
            }
            Assert.IsTrue(are_equal, message);                     
        }

        [TestCase("Головна",1360)]
        [TestCase("Головна", 1040)]
        [TestCase("Погода", 1040)]
        [TestCase("Погода", 460)]
        public void PopUpWindowCloseButton_WhenBrowserWidthChange_ShouldBeAccessible(string category,int width)
        {
            bool is_displayed = true;

            //Navigate to necessary category
            IWebElement need_category= driver.FindElement(By.ClassName("main-menu")).FindElement(By.XPath(".//*[contains(text(),'" + category + "')]"));
            try
            {
                need_category.FindElement(By.XPath("./ancestor::li[@class='selected]'"));
            }
            catch(NoSuchElementException)
            {                
                need_category.Click();
            }
            
            driver.Manage().Window.Size = new System.Drawing.Size(width, 840);
            try
            {
                driver.FindElement(By.ClassName("api-gpt-close-btn")).Click();
            }
            catch(NoSuchElementException) {}

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("cookies__close")));
                driver.FindElement(By.ClassName("cookies__close")).Click();
            }
            catch(Exception)
            {
                is_displayed = false;
            }
            Assert.IsTrue(is_displayed, "Close button is not accessible for browser width = " + width);
        }

        [TestCase("Погода","Укр")]
        [TestCase("Погода", "Рус")]
        [TestCase("Головна", "Укр")]
        [TestCase("Головна", "Eng")]
        [TestCase("Головна", "Рус")]
        public void PopUpWindow_LanguageChange_ShouldChangeContent(string category,string lang)
        {           
            string check_word="";
            IWebElement lang_link;
            IWebElement need_category;
            switch (lang)
            {
                case "Укр":
                    check_word = "Погоджуюся";
                    break;
                case "Рус":
                    check_word = "Соглашаюсь";
                    break;
                case "Eng":
                    check_word = "Agree!";
                    break;
            }
            //Navigate to category
            need_category = driver.FindElement(By.ClassName("main-menu")).FindElement(By.XPath(".//*[contains(text(),'" + category + "')]"));
            try
            {
                need_category.FindElement(By.XPath("./ancestor::li[@class='selected']"));
            }
            catch (NoSuchElementException)
            {
                need_category.Click();
            }

            //Change language
            try
            {
                lang_link = driver.FindElement(By.XPath("//*[@class='dropdown']/a"));
                if (!lang_link.Text.Contains(lang))
                {
                    lang_link.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='dropdown']//ul//a")));
                    lang_link.FindElement(By.XPath("../ul//a[contains(text(),'" + lang + "')]")).Click();
                }
            }
            catch(NoSuchElementException)//Category page design differs
            {

                check_word = lang == "Рус" ? "Принять" : check_word;//ask person responsible for content
                IJavaScriptExecutor je = (IJavaScriptExecutor)driver;

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("cookies__close")));               
                je.ExecuteScript("arguments[0].click();", driver.FindElement(By.ClassName("cookies__close")));

                lang_link = driver.FindElement(By.XPath("//li[@class=' language']//*[contains(text(),'"+lang+"')]"));
                try
                {                   
                    je.ExecuteScript("arguments[0].scrollIntoView(true);", lang_link);
                    lang_link.Click();
                }
                catch (NoSuchElementException) { driver.Navigate().Refresh(); }                
            }
            
            try
            {
                driver.FindElement(By.ClassName("api-gpt-close-btn")).Click();
            }
            catch (NoSuchElementException) { }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".cookies__agree")));
            string res = driver.FindElement(By.CssSelector(".cookies__agree")).Text;
            Assert.AreEqual(check_word, res, "Pop up window content is not translated to "+lang+" language");

        }
        [Test]
        public void CheckUserPermissions_WhenTryingToAddComment()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            IWebElement comment_icon;
            IWebElement comment_area;
            bool auth_window_opened;

            driver.Navigate().GoToUrl("https://www.unian.net/politics/roman-cimbalyuk-potuhshaya-neftyanaya-skvazhina-usyhayushchie-velichie-rossii-novosti-ukrainy-10972511.html");
            comment_icon = driver.FindElements(By.ClassName("comment"))[1];
            je.ExecuteScript("arguments[0].scrollIntoView(true);", comment_icon);
            comment_icon.Click();

            //Close advertisement
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("api-gpt-close-btn")));
            driver.FindElement(By.ClassName("api-gpt-close-btn")).Click();

            comment_area = driver.FindElement(By.CssSelector(".new-comment textarea"));
            comment_area.SendKeys("some text");
            driver.FindElement(By.CssSelector(".buttons button[type='submit']")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("auth-widget")));
            auth_window_opened = driver.FindElement(By.Id("auth-widget")).Displayed;
            Assert.IsTrue(auth_window_opened, "Authorization window is expected to be opened");
        }

        [TestCase("Facebook", "https://www.facebook.com/UNIAN.net/")]
        [TestCase("Telegram", "https://t.me/uniannet")]
        public void SocialLinkIsOpenedInAnotherTab(string link_name,string link_url)
        {
            string result_url;

            IWebElement links = driver.FindElement(By.CssSelector(".social"));
            links.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".social ul")));
            links.FindElement(By.XPath(".//*[contains(text(),'"+link_name+"')]")).Click();
            
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            result_url = driver.Url;
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Assert.AreEqual(link_url, result_url, String.Format("Opened page is not related to УНИАН {0}",link_name));
        }


        //[Test]
       /* public void TestReplaceFunc()
        {
            string date = "04.12.2000";
            string res = Help.ReplaceMonth(date);
            StringAssert.Contains("грудня",res );
        }*/
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
