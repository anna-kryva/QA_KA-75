using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject;
using System.Security.Policy;

namespace Tests
{
    [TestFixture]
    public class MainClass
    {
        private IWebDriver driver;
        private Page page;
        private string _url = "https://avtoshtraf.com/";
        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            page = new Page(driver);
        }
        [TearDown]
        public void TestCleanup()
        {
            driver.Close();
        }
        [Test]
        public void Test1()
        {
            page.GoTo(_url).Appeal().ToAgreeCheckbox().Acquainte();
        }
        [Test]
        public void Test2()
        {
            string expected = "Заповніть усі відповіді!";
            page.GoTo(_url).Appeal().Wait1000().ToAgreeCheckbox().Acquainte().Continue();
            string result = page.GetAlertText();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test3()
        {
            string expected_url = "https://avtoshtraf.com/declaration";
            page.GoTo(_url).Appeal().Wait1000().ToAgreeCheckbox().Acquainte();
            page.FirstCheckboxClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick();
            page.Continue();
            Assert.AreEqual(page.Get_url(), expected_url);
        }
        [Test]
        public void Test4()
        {
            string name = "Въячеслав Украинцев";
            string tel = "+8800 555 35 35";
            string expected_url = "https://avtoshtraf.com/";
            page.GoTo(_url).Wait1000().HelpButtonClick()
                .MolalNameInputInsert(name)
                .MolalTelephoneInputtInsert(tel);
            Assert.AreEqual(page.Get_url(), expected_url);
        }
        [Test]
        public void Test5()
        {
            string name = "Въячеслав Украинцев";
            string expected = "Оплатити 50 UAH".ToLower();
            page.GoTo(_url).Appeal().Wait1000().ToAgreeCheckbox().Acquainte();
            page.FirstCheckboxClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick();
            page.Continue().NameInputInsert(name).SubmitButtonClick().Wait1000();
            string result = page.GetNextButtonText().ToLower();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test7()
        {
            string expected = "2020-05-02";
            page.GoTo(_url).Appeal().Wait1000().ToAgreeCheckbox().Acquainte();
            page.FirstCheckboxClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick();
            page.Continue().DatePickerClick().Day2PickerClick();
            string result = page.GetDateInputValue();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test6()
        {
            string expected = "Переписати зі свідоцтва про реєстрацію транспортного засобу";
            page.GoTo(_url).Appeal().Wait1000().ToAgreeCheckbox().Acquainte();
            page.FirstCheckboxClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick();
            page.Continue().InputSpanMove();
        }
        public void Test8()
        {
            string name = "Майкл Джордан";
            string expected = "https://www.liqpay.ua";
            page.GoTo(_url).Appeal().Wait1000().ToAgreeCheckbox().Acquainte();
            page.FirstCheckboxClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick()
                .CheckboxFalseClick()
                .CheckboxTrueClick();
            page.Continue().NameInputInsert(name).SubmitButtonClick().NextButtonClick();
            string result = page.Get_url().Substring(0, 21);
            Assert.AreEqual(result, expected);
        }
    }
}
