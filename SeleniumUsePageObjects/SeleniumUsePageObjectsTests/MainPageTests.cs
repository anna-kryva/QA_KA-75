using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumUsePageObjects;
using System;

namespace SeleniumUsePageObjectsTests
{
    public abstract class BaseTestClass
    {
        protected IWebDriver driver;
        ChromeOptions options;
        
        public void StartBrowser(string _url)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(_url);
            new WebDriverWait(driver, new System.TimeSpan(0, 0, 20)).Until(d => d.Url == _url);
        }
        
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }


    [TestFixture]
    public class MainPageTests:BaseTestClass
    {
        
        string _url = "https://www.unian.ua/";
        [SetUp]
        public void NavigateNeedLink()
        {
            base.StartBrowser(_url);
        }

        [Test]
        public void DropDownItems_AfterClick_ShouldBeVisible()
        {
            var MainPage = new MainPage(driver);
            string info="";

            var are_displayed = MainPage.ItemsDisplayed(ref info);
            Assert.IsTrue(are_displayed, info);
        }
        [TestCase("Укр", "Вхід")]
        [TestCase("Eng", "Login")]
        [TestCase("Рус", "Вход")]
        public void LoginButtonContent_LanguageChange_ShouldChageContent(string lang, string expected_value)
        {
            var MainPage = new MainPage(driver);

            MainPage.ChangeLanguage(lang);
            
            Assert.AreEqual(MainPage.LoginButton_value, expected_value, String.Format("Login button content expected to be {0},but was {1}",expected_value,MainPage.LoginButton_value));
        }
        [TestCase("Головна", 1360)]
        [TestCase("Головна", 1040)]
        [TestCase("Погода", 1040)]
        [TestCase("Погода", 460)]
        public void PopUpWindowCloseButton_WhenBrowserWidthChange_ShouldBeAccessible(string category, int width)
        {
            var MainPage = new MainPage(driver);

            MainPage.ChangeCategory(category).ChangeWindowSize(width).CloseAdvertisement();

            bool is_displayed = MainPage.IsAbleToClickOnElement(MainPage.PopUpWindowCloseButton);
            Assert.IsTrue(is_displayed, "Close button is not accessible for browser width = " + width);
        }
        [TestCase("Погода", "Укр")]
        [TestCase("Погода", "Рус")]
        [TestCase("Головна", "Укр")]
        [TestCase("Головна", "Eng")]
        [TestCase("Головна", "Рус")]
        public void PopUpWindow_LanguageChange_ShouldChangeContent(string category, string lang)
        {
            var MainPage = new MainPage(driver);
            string check_word = "";
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
            MainPage.ChangeCategory(category);
            MainPage.ChangeLanguage(lang);           
            if (MainPage.Url.Contains("/pogoda"))
            {
                check_word = lang == "Рус" ? "Принять" : check_word;
            }
            MainPage.Refresh().CloseAdvertisement();
            string res = MainPage.PopUpWindowAgreeButton.Text;
            Assert.AreEqual(check_word, res, "Pop up window content is not translated to " + lang + " language");
        }
        [TestCase("Facebook", "https://www.facebook.com/UNIAN.net/")]
        [TestCase("Telegram", "https://t.me/joinchat/AAAAAEHhvOisFfUQetRBow")]
        public void SocialLinkIsOpenedInAnotherTab(string link_name, string link_url)
        {
            var MainPage = new MainPage(driver);
            MainPage.NavigateToSocialLink(link_name);
            MainPage.ChangeCurrentTab();
            string social_link_url = MainPage.Url;
            MainPage.CloseCurrentTab();
            Assert.AreEqual(link_url, social_link_url, String.Format("Opened page is not related to УНИАН {0}", link_name));
        }
        


















        /*    [Test]
            public void UpperNavigationBarDropDownItems_AfterClick_ShouldBeVisible()
            {
                var MainPage = new MainPage(driver);
                bool factor=true;
                string problem_message="";
                try
                {
                    factor=MainPage.ItemsDisplayed1();
                }
                catch(Exception e)
                {
                    factor = false;
                    problem_message = e.Message;
                }
                Assert.IsTrue(factor, problem_message);
            }*/
        /*  [Test]
          public void ItemsDisplayed1()
          {
              IList<IWebElement> DropDownItems = driver.FindElements(By.XPath("//li[contains(@class,'dropdown')]"));
              Assert.Multiple(() =>
              {

                  Assert.False(true);
                  Assert.IsTrue(false, "hjdbvj");
              });


          }*/
    }
}
