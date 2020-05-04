using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;


namespace PageObject
{
    public class Page
    {
        private IWebDriver _driver;

        public Page(IWebDriver driver)  
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = ".about button")]
        public IWebElement AppealButton;
        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        public IWebElement AgreeCheckbox;
        [FindsBy(How = How.CssSelector, Using = ".buttons button")]
        public IWebElement AcquaintedButton;
        [FindsBy(How = How.CssSelector, Using = ".PrepareQuestionsPage button")]
        public IWebElement ContinueButton;
        [FindsBy(How = How.CssSelector, Using = "div[role='alert']")]
        public IWebElement AlertBlock;
        [FindsBy(How = How.CssSelector, Using = ".Item :first-child")]
        public IWebElement FirstCheckbox;
        [FindsBy(How = How.CssSelector, Using = ".qa > :last-child > :nth-child(2)")]
        public IWebElement CheckboxFalse;
        [FindsBy(How = How.CssSelector, Using = ".qa > :last-child > :nth-child(1)")]
        public IWebElement CheckboxTrue;
        [FindsBy(How = How.CssSelector, Using = ".Section1_2 :nth-child(2) button")]
        public IWebElement HelpButton;
        [FindsBy(How = How.CssSelector, Using = ".ModalBodyHelp input[name='Name']")]
        public IWebElement MolalNameInput;
        [FindsBy(How = How.CssSelector, Using = ".ModalBodyHelp input[name='Telephone']")]
        public IWebElement MolalTelephoneInput;
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/form/div/label[1]/input")]
        public IWebElement NameInput;
        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SubmitButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/div/form/button")]
        public IWebElement NextButton;
        [FindsBy(How = How.CssSelector, Using = ".b4 .carModel span")]
        public IWebElement InputSpan;
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/form/div/div[2]/div[2]/label[1]/div[2]/span")]
        public IWebElement DatePicker;
        [FindsBy(How = How.CssSelector, Using = "div[aria-label='day-2']")]
        public IWebElement Day23Picker;
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div[2]/div/form/div/div[2]/div[2]/label[1]/div[2]/div[1]/div/input")]
        public IWebElement DateInput;


        public Page GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return this;
        }
        public string Get_url()
        {
            return _driver.Url;
        }
        public Page Appeal()
        {
            AppealButton.Click();
            return this;
        }
        public Page ToAgreeCheckbox()
        {
            AgreeCheckbox.Click();
            return this;
        }
        public Page Acquainte()
        {
            AcquaintedButton.Click();
            return this;
        }
        public Page Continue()
        {
            ContinueButton.Click();
            return this;
        }
        public string GetAlertText()
        {
            string text = AlertBlock.Text;
            return text;
        }
        public Page FirstCheckboxClick()
        {
            FirstCheckbox.Click();
            return this;
        }
        public Page CheckboxTrueClick()
        {
            CheckboxTrue.Click();
            return this;
        }
        public Page CheckboxFalseClick()
        {
            CheckboxFalse.Click();
            return this;
        }
        public Page HelpButtonClick()
        {
            HelpButton.Click();
            return this;
        }
        public Page MolalNameInputInsert(string name)
        {
            MolalNameInput.SendKeys(name);
            return this;
        }
        public Page MolalTelephoneInputtInsert(string tel)
        {
            MolalTelephoneInput.SendKeys(tel);
            return this;
        }
        public Page NameInputInsert(string name)
        {
            NameInput.SendKeys(name);
            return this;
        }
        public Page SubmitButtonClick()
        {
            SubmitButton.Click();
            return this;
        }
        public string GetNextButtonText()
        {
            string text = NextButton.Text;
            return text;
        }
        public Page NextButtonClick()
        {
            NextButton.Click();
            return this;
        }
        public Page InputSpanMove()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(InputSpan).Perform();
            return this;
        }
        public Page DatePickerClick()
        {
            DatePicker.Click();
            return this;
        }
        public Page Day2PickerClick()
        {
            Day23Picker.Click();
            return this;
        }
        public string GetDateInputValue()
        {
            string val = DateInput.GetAttribute("value");
            return val;
        }
        public Page Wait200()
        {
            Thread.Sleep(200);
            return this;
        }
        public Page Wait1000()
        {
            Thread.Sleep(1000);
            return this;
        }
    }
}
