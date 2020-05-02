const BasePage = require("./base.page");

class ClubPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://www.sportlife.ua/uk/clubs",
    waitTimeout = 20000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async clickLogo() {
    await this.clickWhenClickableByXPath("//b[@class='b-logo']/a");
  }
}

module.exports = ClubPage;
