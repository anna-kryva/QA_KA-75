const BasePage = require("./base.page");

class TrainersPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://www.sportlife.ua/uk/about/trainers_partners",
    waitTimeout = 20000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async clickSelector() {
    await this.clickWhenClickableById("advanced-select");
  }

  async isSubMenuDisplayed() {
    const element = await this.waitForElementById("trainers-clubs-menu");
    const result = await element.isDisplayed();
    return result;
  }

  async clickClub() {
    await this.clickWhenClickableByXPath(
      "//*[@id='trainers-clubs-menu']/div/div/div[2]/div[2]/div[2]/div[5]"
    );
  }

  async getClubName() {
    const element = await this.waitForElementById("advanced-select");
    const result = await element.getText();
    return result;
  }

  async clickFilterItem() {
    await this.clickWhenClickableByXPath(
        "//*[@id='specialization-filter']/ul/li[10]"
      );
  }

  async isListEmpty() {
      const result = await this.doExistByCss("view-content");
      return result;
  }
}

module.exports = TrainersPage;
