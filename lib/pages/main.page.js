const BasePage = require("./base.page");

class MainPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://www.olx.ua/",
    waitTimeout = 20000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async clickLogo() {
    await this.clickWhenClickableById(
      "headerLogo"
    );
    await this.waitForUrlToContain('https://www.olx.ua/');
  }

  async clickButton() {
    await this.clickWhenClickableById(
      "postNewAdLink"
    );
    await this.waitForUrlToContain('https://www.olx.ua/account/');
  }

  async sendQuery() {
    const searchQuery = "search query";
    await this.sendKeysWhenEnableById("headerSearch", searchQuery);
    await this.clickWhenClickableById(
      "submit-searchmain"
    );
    await this.waitForUrlToContain('https://www.olx.ua/list/q-');

  }

}

module.exports = MainPage;
