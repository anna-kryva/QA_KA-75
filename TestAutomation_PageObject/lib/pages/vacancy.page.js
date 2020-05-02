const BasePage = require("./base.page");

class VacancyPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://www.sportlife.ua/uk/about/lookingforstaff",
    waitTimeout = 60000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async clickGatnoe() {
    this.clickWhenClickableByXPath(
      "//div[contains(@class, 'jobs-list hot')]/ul/li[1]/a",
      60000
    );
  }

  async waitGatnoePageLoad() {
    await this.waitForUrlToBe(
      "https://www.sportlife.ua/uk/clubs/kiev/gatnoe/vacancy",
      60000
    );
    await this.driver.wait(
      this.webdriver.until.elementsLocated(this.webdriver.By.tagName("h3")),
      1000
    );
  }

  async getVacancies() {
    const tagElements = await this.waitForElementsByTag("h3", 60000);
    const result = [];
    for (let tag of tagElements) {
      let text = await tag.getText();
      result.push(text);
    }
    return result;
  }
}

module.exports = VacancyPage;
