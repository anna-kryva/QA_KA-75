using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace PageObject
{
	public class Page
	{
		private IWebDriver driver_;

		public Page(IWebDriver driver)
		{
			driver_ = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[1]/input")]
		public IWebElement EmailFieldLogin;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[2]")]
		public IWebElement EmailErrorFieldLogin;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div[1]/div/form/div/div[3]/button")]
		public IWebElement LoginButton;

		[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[2]/div[1]/div/form/div/div[1]/div[1]/input")]
		public IWebElement EmailFieldForgotPassword;

		[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[2]/div[1]/div/form/div/div[2]/button")]
		public IWebElement GotNewAPasswordButton;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div[1]/div/h1")]
		public IWebElement CheckInbox;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div[1]/div/div[2]/div[2]/div[1]/a")]
		public IWebElement GoogleAuthButton;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div[1]/div[2]/div[1]/div/div[2]/div[2]/div[2]/a")]
		public IWebElement SSOAuthButton;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div[1]/div[2]/div[1]")]
		public IWebElement TryItFreeButton;

		[FindsBy(How = How.XPath, Using = "/html/body/div/div[8]/div[2]/div[1]")]
		public IWebElement SignUpPopup;

		[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[4]/div[1]/a")]
		public IWebElement DocsButton;

		[FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[4]/div[2]/a")]
		public IWebElement APIButton;

		public Page GoToUrl(string url)
		{
			driver_.Navigate().GoToUrl(url);
			return this;
		}

		public Page FillInEmailLogin(string email)
		{
			EmailFieldLogin.SendKeys(email);
			return this;
		}

		public Page FillInEmailForgotPassword(string email)
		{
			EmailFieldForgotPassword.SendKeys(email);
			return this;
		}

		public Page ClickLogin()
		{
			LoginButton.Click();
			return this;
		}

		public Page ClickGotNewPasswordButton()
		{
			GotNewAPasswordButton.Click();
			return this;
		}

		public Page ClickGoogleAuthButton()
		{
			GoogleAuthButton.Click();
			return this;
		}

		public Page ClickSSOAuthButton()
		{
			SSOAuthButton.Click();
			return this;
		}

		public Page ClickTryItFreeButton()
		{
			TryItFreeButton.Click();
			return this;
		}

		public Page ClickDocsButton()
		{
			DocsButton.Click();
			return this;
		}

		public Page ClickAPIButton()
		{
			APIButton.Click();
			return this;
		}

		public string GetCurrentUrl()
		{
			return driver_.Url;
		}

		public string GetEmailErrorMessageLogin()
		{
			return EmailErrorFieldLogin.Text;
		}

		public string GetCheckInBoxText()
		{
			return CheckInbox.Text;
		}

		public bool UrlContains(string text)
		{
			return driver_.Url.Contains(text);
		}

		public bool SingInPopUpDisplayed()
		{
			return SignUpPopup.Displayed;
		}

		public Page Wait(int timeout = 3000)
		{
			System.Threading.Thread.Sleep(timeout);
			return this;
		}

		public Page SetSnth()
		{
			return this;
		}
	}
}
