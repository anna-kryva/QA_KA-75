using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjSol
{
    public class PageObj
    {
        private IWebDriver _driver;

        public PageObj(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "/html/body/article/section[1]/div[2]/div[2]/div[1]/div/a")]
        public IWebElement Contact_Sales_Button;
        [FindsBy(How = How.XPath, Using = "//*[@id='owner[email]']")]
        public IWebElement EmailInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='question']")]
        public IWebElement QuestionInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='FirstName']")]
        public IWebElement FirstNameInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='LastName']")]
        public IWebElement LastNameInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='account[name]']")]
        public IWebElement Company_nameInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='account[help_desk_size]']")]
        public IWebElement Number_of_employeesInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='address[phone]']")]
        public IWebElement Phone_numberInput;
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/form/div[1]/div[8]/button")]
        public IWebElement SubmitButton;




        public PageObj GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }
        public string Get_url()
        {
            return _driver.Url;
        }
        public PageObj Activate_item(string itemXPath)
        {
            Actions actions = new Actions(_driver);
            IWebElement link = this.Get_link(itemXPath);
            actions.MoveToElement(link).Perform();
            return this;
        }
        public IWebElement Get_link(string itemXPath)
        {
            IWebElement link = _driver.FindElement(By.XPath(itemXPath));
            return link;
        }
        public bool Is_dispalyed(string itemXPath)
        {
            bool isnt = this.Get_link(itemXPath).FindElement(By.XPath(itemXPath)).Displayed;
            return isnt;
        }
        public PageObj Contact_Sales_Button_Click()
        {
            Contact_Sales_Button.Click();
            return this;
        }
        public PageObj SetEmailInput(string Work_email)
        {
            EmailInput.SendKeys(Work_email);
            return this;
        }
        public PageObj SetQuestionInput(string Message)
        {
            QuestionInput.SendKeys(Message);
            return this;
        }
        public PageObj SetFirstNameInput(string First_name)
        {
            FirstNameInput.SendKeys(First_name);
            return this;
        }
        public PageObj SetLastNameInput(string Last_name)
        {
            LastNameInput.SendKeys(Last_name);
            return this;
        }
        public PageObj SetCompany_nameInput(string Company_name)
        {
            Company_nameInput.SendKeys(Company_name);
            return this;
        }
        public PageObj SetNumber_of_employeesInput(string Number_of_employees)
        {
            Number_of_employeesInput.SendKeys(Number_of_employees);
            return this;
        }
        public PageObj SetPhone_numberInput(string Phone_number)
        {
            Phone_numberInput.SendKeys(Phone_number);
            return this;
        }
        public PageObj SubmitButton_Click()
        {
            SubmitButton.Click();
            return this;
        }
        public PageObj Wait1000()
        {
            Thread.Sleep(1000);
            return this;
        }
        public PageObj Wait10000()
        {
            Thread.Sleep(10000);
            return this;
        }
    }
}
