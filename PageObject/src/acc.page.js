const SignedIn= require('./signin')

class AccountPage extends SignedIn {

  ACC_SETTINGS_URL = 'http://best.eu.org/account/profile.jsp'; 
  MOBILE_NUMBER_FIELD = `/html//input[@id='person.mobilePhone_form1']`;
  ICQ_FIELD = `/html//input[@id='person.icq_form1']`;
  EMAIL_FIELD = `/html//input[@id='person.email_form1']`;
  SAVE_BUTTON = `//div[@id='general']/form/input[@value='Save changes']`;

  async goToAccSettings() {
    this.signin();
    this.get(this.ACC_SETTINGS_URL);
  }

  async insertMobileNumber(number) {
    await this.clearInputByXpath(this.MOBILE_NUMBER_FIELD);
    await this.insertByXPath(this.MOBILE_NUMBER_FIELD, number);
  }

  async getMobileNumber() {
    return await this.getValByXPath(this.MOBILE_NUMBER_FIELD)
  }

  async insertICQ(number) {
    await this.clearInputByXpath(this.ICQ_FIELD);
    await this.insertByXPath(this.ICQ_FIELD, number);
  }

  async getICQ() {
    return await this.getValByXPath(this.ICQ_FIELD);
  }

  async insertEmail(email) {
    await this.clearInputByXpath(this.EMAIL_FIELD);
    await this.insertByXPath(this.EMAIL_FIELD, email);
  }

  async getEmail() {
    return await this.getValByXPath(this.EMAIL_FIELD);
  }

  async clickSave() {
    await this.clickByXPath(this.SAVE_BUTTON);
  }
}

module.exports = AccountPage;
