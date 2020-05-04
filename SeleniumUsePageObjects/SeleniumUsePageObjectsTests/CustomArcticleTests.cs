using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUsePageObjects;


namespace SeleniumUsePageObjectsTests
{
    [TestFixture]
    class CustomArcticleTests:BaseTestClass
    {
        string _url = "https://www.unian.net/politics/roman-cimbalyuk-potuhshaya-neftyanaya-skvazhina-usyhayushchie-velichie-rossii-novosti-ukraina-10972511.html";
       
        [SetUp]
        public void NavigateNeedLink()
        {
            base.StartBrowser(_url);
        }

        [Test]
        public void CheckUserPermissions_WhenTryingToAddComment()
        {
            var CustomPage = new CustomArcticle(driver);
           // CustomPage.CloseAdvertisement();
            CustomPage.TakeIntoView(CustomPage.CommentsIcons[1]);
            CustomPage.CloseAdvertisement();
            CustomPage.AddComment();
            bool auth_window_opened = CustomPage.AuthorizationWindow.Displayed;
            Assert.IsTrue(auth_window_opened, "Authorization window is expected to be opened");
        }
    }
}
