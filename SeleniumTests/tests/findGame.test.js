const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/";
const gameName = "skyrim";


describe("Find game by name", () => {
  const driver = global.driver;

  before(async () => {
    await driver.get(URL);
  });

  it("should find game by name", async () => {
    // await driver.manage().window().maximize();
    const search = await driver.findElement(By.id('store_nav_search_term'));
    search.sendKeys(gameName);
    const searchForm = await driver.findElement(By.xpath('//*[@id="store_search_link"]/img'));
    await searchForm.click();

    const gameBlock = await driver.findElement(By.xpath('//*[@id="search_resultsRows"]/a[1]'))
    await gameBlock.click();

    if(await driver.findElement(By.id('ageYear')).size!=0){
      const age = await driver.findElement(By.id('ageYear'));
      age.sendKeys('2000');
      await driver.findElement(By.xpath('//*[@id="app_agegate"]/div[1]/div[3]/a[1]/span')).click();
    }

    await driver.wait(until.urlIs('https://store.steampowered.com/app/489830/The_Elder_Scrolls_V_Skyrim_Special_Edition/'), 5000);
    
    const findedGameName = await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[2]/div[2]/div/div[3]'));
    const expected = 'The Elder Scrolls V: Skyrim Special Edition';
    const actual = await findedGameName.getText();

    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
