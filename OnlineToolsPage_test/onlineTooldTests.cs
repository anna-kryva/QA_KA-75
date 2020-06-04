using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OnlineToolsPage
{
    [TestFixture]
    public class OnlineToolsTests
    {
        private IWebDriver driver;
        private string _url = "http://emn178.github.io/online-tools/";
        
        [SetUp]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_url);
        }

        [TearDown]
        public void TestFinalize()
        {
            driver.Quit();
        }

        [Test]
        public void sha256Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.sha256Button)
                .fillInputArea(onlineToolsPage.inputArea,"nvdnsjjasn")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.sha256TestPassed);
        }
        
        [Test]
        public void crc16Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.crc16Button)
                .fillInputArea(onlineToolsPage.inputArea,"dfmmdkasdsfasfd")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.crc16TestPassed);
        }
        
        [Test]
        public void crc32Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.crc32Button)
                .fillInputArea(onlineToolsPage.inputArea,"bhfabbafhbahw")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.crc32TestPassed);
        }
        
        [Test]
        public void md2Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.md2Button)
                .fillInputArea(onlineToolsPage.inputArea,"bfhabhfs")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.md2TestPassed);
        }
        
        [Test]
        public void md4Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.md4Button)
                .fillInputArea(onlineToolsPage.inputArea,"mskkgsmk")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.md4TestPassed);
        }
        
        [Test]
        public void md5Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.md5Button)
                .fillInputArea(onlineToolsPage.inputArea,"amfsakmf")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.md5TestPassed);
        }
        
        [Test]
        public void sha1Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.sha1Button)
                .fillInputArea(onlineToolsPage.inputArea,"famkmfask")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.sha1TestPassed);
        }
        
        [Test]
        public void sha224Test()
        {
            var onlineToolsPage = new OnlineToolsPage(driver);
            onlineToolsPage.ClickButton(onlineToolsPage.sha224Button)
                .fillInputArea(onlineToolsPage.inputArea,",afskmfask")
                .ClickButton(onlineToolsPage.checkButton)
                .ClickButton(onlineToolsPage.hashButton);
            Assert.IsTrue(onlineToolsPage.sha224TestPassed);
        }
        
    }
}