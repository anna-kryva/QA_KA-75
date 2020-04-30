using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace SpecFlowTests
{
    [TestFixture]
    class Test
    {
        [Test]
        public void TestMethod()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vmr.gov.ua");
            driver.FindElementByClassName("switchmodebase").Click();
            var status = driver.FindElementByClassName("accessibility-button");
        }
    }
}
