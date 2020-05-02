const BasePage = require("./base.page");

class PoolPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://www.sportlife.ua/uk/fitness/15966",
    waitTimeout = 20000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async clickClubsLink() {
    await this.clickWhenClickableByXPath("//p[@class='bottom-link']//a");
  }
}

module.exports = PoolPage;
