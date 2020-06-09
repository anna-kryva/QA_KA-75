using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace PageObjSol
{
    class Tests
    {
        [TestFixture]
        public class Selenium
        {
            private IWebDriver driver;
            private PageObj page;
            private string _url = "https://www.zendesk.com/contact/";

            [SetUp]
            public void StartBrowser()
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized");
                driver = new ChromeDriver(options);
                page = new PageObj(driver);
            }
            [TearDown]
            public void TestCleanup()
            {
                driver.Close();
            }
            [Test]
            public void TestLink()
            {
                page.GoTo(_url);
            }

            [TestCase("/html/body/header/div/div[2]/nav/ul[2]/li[1]/span", "/html/body/header/div/div[2]/nav/ul[2]/li[1]/div")]
            [TestCase("/html/body/header/div/div[2]/nav/ul[2]/li[3]/span", "/html/body/header/div/div[2]/nav/ul[2]/li[3]/div")]
            [TestCase("/html/body/header/div/div[2]/nav/ul[2]/li[6]/span", "/html/body/header/div/div[2]/nav/ul[2]/li[6]/div")]
            public void DropDownItems_AfterHover_ShouldBeVisible(string itemXPath, string dropdownMenuXPath)
            {
                page.GoTo(_url).Wait1000().Activate_item(itemXPath).Wait1000();
                bool is_displayed = page.Is_dispalyed(dropdownMenuXPath);
                Assert.IsTrue(is_displayed, "The dropdown menu is expected to be visible");
            }

            [Test]
            public void Contact_Sales_Popup_Must_Appear_After_Click()
            {
                page.GoTo(_url).Contact_Sales_Button_Click().Wait1000();
                bool is_displayed = page.Is_dispalyed("/html/body/div[2]");
                Assert.IsTrue(is_displayed, "The contact sales popup is expected to be visible");
            }

            [Test]
            public void Go_to_the_help_center_Must_Redirect_to_Support_Page()
            {
                page.GoTo(_url).Contact_Sales_Button_Click().Wait1000();
                String currentURL = page.Get_url();
                currentURL.Contains("https://support.zendesk.com/");
            }

            [TestCase("example1234@mail.com", "some msg", "Tom", "Smith", "Company", "5000+", "+77077-777-77-77")]
            public void Contsct_Us_Request_Is_sent(String Work_email, String Message, String First_name, String Last_name, String Company_name, String Number_of_employees, String Phone_number)
            {
                page.GoTo(_url).Contact_Sales_Button_Click().Wait1000();
                page
                    .SetEmailInput(Work_email)
                    .SetQuestionInput(Message)
                    .SetFirstNameInput(First_name)
                    .SetLastNameInput(Last_name)
                    .SetCompany_nameInput(Company_name)
                    .SetNumber_of_employeesInput(Number_of_employees)
                    .SetPhone_numberInput(Phone_number);
                page.SubmitButton_Click();
                page.Wait10000();
                bool is_displayed = page.Is_dispalyed("/html/body/div[2]/div/form/div[2]");
                Assert.IsTrue(is_displayed, "The 'Your request has been sent!' is expected to be visible");
            }
        }
    }
}
