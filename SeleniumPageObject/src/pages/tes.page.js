const PageBase = require('./base.page');

class TesPage extends PageBase{
    constructor(
        webdriver,
        driver,
        targetUrl = "https://store.steampowered.com/app/306130/The_Elder_Scrolls_Online/",
        waitTimeout = 60000
      ) {
        super(webdriver, driver, targetUrl, waitTimeout);
      }
      async skipAgeCheck(){
        if(await (await this.waitForElementById('ageYear')).size!=0){
          const age = await this.waitForElementById('ageYear');
          age.sendKeys('2000');
          await this.clickWhenClickableByXPath('//*[@id="app_agegate"]/div[1]/div[3]/a[1]/span');
        }
      }
      async waitPageLoad(){
          await this.waitForUrlToBe(this.targetUrl);
      }

      async getTopGameName(){
        return await (await this.waitForElementByXPath("/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[2]/div[2]/div/div[3]")).getText();
      }

      async addToCart(){
          await this.clickWhenClickableByXPath(
              '//*[@id="game_area_purchase"]/div[1]/div/div[2]/div/div[2]'
          );
      }
}

module.exports = TesPage;