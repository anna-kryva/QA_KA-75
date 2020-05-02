const BasePage = require("./base.page");

class MainPage extends BasePage {
  constructor(
    webdriver,
    driver,
    targetUrl = "https://www.sportlife.ua/uk/",
    waitTimeout = 20000
  ) {
    super(webdriver, driver, targetUrl, waitTimeout);
  }

  async clickFbImage() {
    await this.clickWhenClickableByXPath(
      "//div[contains(@class, 'sl-social')]//a[2]/img"
    );
  }

  async switchToSecondTab() {
    const windowTabs = await this.driver.getAllWindowHandles();
    await this.driver.switchTo().window(windowTabs[1]);
  }

  async waitFbPageLoad() {
    await this.waitForUrlToBe("https://www.facebook.com/sportlifeua");
  }

  async moveToMenuTab() {
    const _menuTab = await this.waitForElementById("menu-item-clubs");
    const actions = this.driver.actions({ async: true });
    actions.move({ origin: _menuTab }).perform();
  }

  async isMenuDisplayed() {
    const result = await (await this.waitForElementById("main-submenu-clubs")).isDisplayed();
    return result;
  }

  async clickSubMenuItem() {
    await this.clickWhenClickableByXPath(
      "//*[@id='main-submenu-clubs']/div/div[1]/div[2]/div[2]/div[5]/a"
    );
  }
}

module.exports = MainPage;
