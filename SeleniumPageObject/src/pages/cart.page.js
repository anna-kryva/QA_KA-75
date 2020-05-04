const PageBase = require('./base.page');

class CartPage extends PageBase{
    constructor(
        webdriver,
        driver,
        targetUrl = "https://store.steampowered.com/cart/",
        waitTimeout = 30000
      ) {
        super(webdriver, driver, targetUrl, waitTimeout);
      }

      async waitCartPageLoad(){
          await this.waitForUrlToBe(this.targetUrl);
      }

      async getNameTopGame(){
          return await (await this.waitForElementByXPath(
              '/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[4]/div[1]/div[1]/div/div/div[3]/a'
              )).getText();
      }
}

module.exports = CartPage;