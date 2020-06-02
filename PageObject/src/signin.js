const page = require('./page');
const dotenv = require('dotenv');

class SignedIn extends page {

  LOGIN_PAGE_URL = 'http://best.eu.org/login.jsp';
  LOGIN_USERNAME_FIELD = `/html//input[@id='username']`;
  LOGIN_PASSWORD_FIELD = `/html//input[@id='password']`;
  LOGIN_BUTTON = `/html//article[@id='content']//form[@action='/doLogin.jsp']//input[@value='Login']`;

  constructor(webdriver, driver, waitTimeout = 10000) {
    super(webdriver, driver, waitTimeout);

    dotenv.config();
    this.EMAIL = process.env['BEST_EMAIL']; 
    this.PASSWORD = process.env['BEST_PASSWORD']; 
  }

  async signin() {
      await this.get(this.LOGIN_PAGE_URL);
      
      await this.insertByXPath(this.LOGIN_USERNAME_FIELD, this.EMAIL);
      await this.insertByXPath(this.LOGIN_PASSWORD_FIELD, this.PASSWORD);
      await this.clickByXPath(this.LOGIN_BUTTON);
  };
}

module.exports = SignedIn;
