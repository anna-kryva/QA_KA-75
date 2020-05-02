using System;
using KaggleSeleniumTesting_PageObjects.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KaggleSeleniumTesting_PageObjects
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
            chromeOptions.AddArguments("headless");
            
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
            LoginPage login = new LoginPage(_driver)
                .LoadPage()
                .LogIn(_email, _password);

            DiscussionPage discussion = new DiscussionPage(_driver)
                .LoadPage();
            
            Assert.True(discussion.CommentFieldOnThePage() && !discussion.WarningFieldOnThePage());
        }
        
        [Test]
        public void LeaveCommentLoggedOut()
        {
            DiscussionPage discussion = new DiscussionPage(_driver)
                .LoadPage();

            Assert.True(!discussion.CommentFieldOnThePage() && discussion.WarningFieldOnThePage());
        }
        
        [Test]
        public void CreateDatasetLoggedIn()
        {
            LoginPage login = new LoginPage(_driver)
                .LoadPage()
                .LogIn(_email, _password);

            DatasetsPage datasets = new DatasetsPage(_driver)
                .LoadPage()
                .CreateDataset();
            
            Assert.True(datasets.DatasetTitleFieldDisplayed());
        }
        
        [Test]
        public void CreateDatasetLoggedOut()
        {
            DatasetsPage datasets = new DatasetsPage(_driver)
                .LoadPage()
                .CreateDataset();
            
            Assert.True(!datasets.DatasetTitleFieldDisplayed());
        }
        
        [Test]
        public void DownloadDataLoggedIn()
        {
            LoginPage login = new LoginPage(_driver)
                .LoadPage()
                .LogIn(_email, _password);

            CompetitionDataPage competitionDataPage = new CompetitionDataPage(_driver)
                .LoadPage();
            Assert.True(competitionDataPage.DownloadDataAvailable());
        }
        
        [Test]
        public void DownloadDataLoggedOut()
        {
            CompetitionDataPage competitionDataPage = new CompetitionDataPage(_driver)
                .LoadPage();
            Assert.True(!competitionDataPage.DownloadDataAvailable());
        }

        [TestCase("VVRudenko", true)]
        [TestCase(" \b", false)]
        public void ChangeNickname(string nickname, bool expected)
        {
            LoginPage login = new LoginPage(_driver)
                .LoadPage()
                .LogIn(_email, _password);
            
            ProfilePage profile = new ProfilePage(_driver)
                .LoadPage()
                .ChangeNickname(nickname);

            Assert.AreEqual(expected, profile.NicknameChanged());
        }
    }
}