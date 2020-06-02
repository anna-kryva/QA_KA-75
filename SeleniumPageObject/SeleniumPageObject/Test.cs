using NUnit.Framework;
using PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
	[TestFixture]
	public class Tests
	{
		private IWebDriver driver;
		private Page page;

		[SetUp]
		public void StartBrowser()
		{
			var options = new ChromeOptions();
			options.AddArgument("start-maximized");
			driver = new ChromeDriver(options);
			page = new Page(driver);
		}

		[TearDown]
		public void close_Browser()
		{
			driver.Quit();
		}

		[TestCase("examplemail.com")]
		public void InvalidEmail(string email)
		{
			page.GoToUrl("https://app.pipedrive.com/auth/login")
				.FillInEmailLogin(email)
				.ClickLogin()
				.Wait(1000)
				;
			Assert.AreEqual("Please add a valid email address", page.GetEmailErrorMessageLogin());
		}

		[TestCase("@email.com")]
		[TestCase("email.com@")]
		public void InvalidEmailAdvanced(string email)
		{
			page.GoToUrl("https://app.pipedrive.com/auth/login").FillInEmailLogin(email).ClickLogin().Wait(1000);
			Assert.AreEqual("Please add a valid email address", page.GetEmailErrorMessageLogin());
		}

		[TestCase("qwe@emailcom")]
		public void UnregisteredEmail(string email)
		{
			page.GoToUrl("https://app.pipedrive.com/auth/login/forgot_password")
				.FillInEmailForgotPassword(email)
				.ClickGotNewPasswordButton()
				.Wait(1000)
				;
			Assert.AreNotEqual("Check your inbox", page.GetCheckInBoxText());
		}

		[Test]
		public void GoogleAuth()
		{
			page.GoToUrl("https://app.pipedrive.com/auth/login")
				.ClickGoogleAuthButton()
				.Wait(1000)
				;
			Assert.IsTrue(page.UrlContains("https://accounts.google.com/signin/oauth"));
		}

		[Test]
		public void SSOAuth()
		{
			page.GoToUrl("https://app.pipedrive.com/auth/login")
				.ClickSSOAuthButton()
				.Wait(1000)
				;
			Assert.IsTrue(page.UrlContains("https://app.pipedrive.com/auth/sso"));
		}

		[Test]
		public void TryItFreeButton()
		{
			page.GoToUrl("https://www.pipedrive.com/")
				.ClickTryItFreeButton()
				.Wait(1000)
				;
			Assert.IsTrue(page.SingInPopUpDisplayed());
		}

		[Test]
		public void DocumentationButton()
		{
			page.GoToUrl("https://www.pipedrive.com/")
				.ClickDocsButton()
				.Wait(1000)
				;
			
			Assert.IsTrue(page.UrlContains("https://pipedrive.readme.io/docs"));
		}

		[Test]
		public void APIButton()
		{
			page.GoToUrl("https://www.pipedrive.com/")
				.ClickAPIButton()
				.Wait(1000)
				;

			Assert.IsTrue(page.UrlContains("https://developers.pipedrive.com/docs/api/"));
		
		}
	}
}