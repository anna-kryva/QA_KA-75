const PageBase = require('./base.page');

const tesSearchrUrl = "https://store.steampowered.com/search/?term=skyrim";

class FilterPage extends PageBase{
    constructor(
        webdriver,
        driver,
        targetUrl = "https://store.steampowered.com/tags/en/RPG/",
        waitTimeout = 10000
      ) {
        super(webdriver, driver, targetUrl, waitTimeout);
      }
      async loadTopGamePage(){
        
        await this.clickWhenClickableByXPath('//*[@id="search_resultsRows"]/a[1]');
        
      }

      async waitPageLoad(){
        await this.waitForUrlToBe(this.targetUrl);
      }

      async clickOnFantasyTag(){
          await this.clickWhenClickableByXPath(
              "/html/body/div[1]/div[7]/div[4]/div[1]/div[3]/div[4]/div/div[2]/div[3]/a[9]"
              );
      }
      async waitFantasyPageLoad(){
        await this.waitForUrlToBe("https://store.steampowered.com/search/?tags=1684,122");
      }
      async getNameTopGame(){
        return await(await this.waitForElementByXPath('//*[@id="search_resultsRows"]/a[1]/div[2]/div[1]/span')).getText();
      }
}

module.exports = FilterPage;

