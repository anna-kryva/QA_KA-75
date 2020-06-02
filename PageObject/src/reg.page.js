const page = require('./page')

class RegistrationPage extends page {

  REGISTRATION_URL = 'http://best.eu.org/account/registration.jsp';
  PRIVACY_POLICY_SELECTOR = `//article[@id='content']/ul/li[6]/a`;

  async loadPage() {
    await this.get(this.REGISTRATION_URL);
  }

  async clickPrivacyPolicy() {
    await this.clickByXPath(this.PRIVACY_POLICY_SELECTOR, 999);
  }
}

module.exports = RegistrationPage;
