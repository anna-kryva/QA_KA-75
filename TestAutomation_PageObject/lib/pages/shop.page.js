const BasePage = require("./base.page");
const chai = require("chai");

class ShopPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://shop.sportlife.ua/index.php?route=checkout/checkout_fast&product_id=1822&city_id=556",
    waitTimeout = 20000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async waitFormToLoad() {
    await this.waitForElementById("user_info");
  }

  async fillOutForm() {
    const firstnameTest = "firstname";
    const lastnameTest = "lastname";
    const phoneTest = "380000000000";
    const emailTest = "email@email.com";

    // fill out form
    await this.sendKeysWhenEnableById("firstname", firstnameTest);
    await this.sendKeysWhenEnableById("lastname", lastnameTest);
    await this.sendKeysWhenEnableById("phone", phoneTest);
    await this.sendKeysWhenEnableById("email", emailTest);

    // verify form filled out
    chai.assert.equal(
      await this.getInputValueById("firstname"),
      firstnameTest,
      "First name is not correct"
    );
    chai.assert.equal(
      await this.getInputValueById("lastname"),
      lastnameTest,
      "Last name is not correct"
    );
    chai.assert.equal(
      await this.getInputValueById("email"),
      emailTest,
      "Email is not correct"
    );
  }

  async submitForm() {
      await this.clickWhenClickableByXPath("//form[@id='user_info']/button");
  }

  async waitLiqpayPageLoad() {
    await this.waitForUrlToContain("liqpay.ua", 60000);
  }
}

module.exports = ShopPage;
