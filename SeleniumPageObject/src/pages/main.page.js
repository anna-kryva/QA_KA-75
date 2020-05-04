const PageBase = require('./base.page');

class MainPage extends PageBase{
    constructor(
        webdriver,
        driver,
        targetUrl = "https://store.steampowered.com",
        waitTimeout = 30000
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
    async searchByWord(word){
        let search = await this.waitForElementById('store_nav_search_term');
        await search.sendKeys(word);
        await this.clickWhenClickableByXPath('//*[@id="store_search_link"]/img');
    }

    async clickOnLogo() {
    await this.clickWhenClickableByXPath('/html/body/div[1]/div[7]/div[1]/div/div[1]/span/a/img');
    }
    async clickOnFbLogo() {
    await this.clickWhenClickableByXPath(
        '//*[@id="footer"]/div/div[7]/a[6]'
    );
    }

    async waitFbLogo(){
    return await this.waitForElementByXPath(
        '//*[@id="footer"]/div/div[7]/a[6]'
    );
    }

    async switchToSecondTab() {
    const windowTabs = await this.driver.getAllWindowHandles();
    await this.driver.switchTo().window(windowTabs[1]);
    }

    async waitFbPageLoad() {
    await this.waitForUrlToBe("https://www.facebook.com/Steam");
    }

    async waitPageLoad() {
    await this.waitForUrlToBe("https://store.steampowered.com/");
    }

    async clickRpgTag(){
        await this.clickWhenClickableByXPath(
            "/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[1]/div[2]/a[9]"
        );
    }
}

module.exports = MainPage;