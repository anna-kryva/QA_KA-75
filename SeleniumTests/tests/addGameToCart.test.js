const { Builder, By, Capabilities,until } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/app/489830/The_Elder_Scrolls_V_Skyrim_Special_Edition/";

describe("Add game to cart", () => {
  const driver = global.driver;

  before(async () => {
    await driver.get(URL);
  });

  it("Add to cart", async () => {    
    if(await driver.findElement(By.id('ageYear')).size!=0){
      const age = await driver.findElement(By.id('ageYear'));
      age.sendKeys('2000');
      await driver.findElement(By.xpath('//*[@id="app_agegate"]/div[1]/div[3]/a[1]/span')).click();
    }

    await driver.wait(until.urlIs('https://store.steampowered.com/app/489830/The_Elder_Scrolls_V_Skyrim_Special_Edition/'), 10000);

    const addToCart = await driver.findElement(By.xpath('//*[@id="btn_add_to_cart_110687"]'));
    await addToCart.click();

    const gameBlock =  await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[4]/div[1]/div[1]/div[1]/div/div[3]/a'));

    const expected = 'The Elder Scrolls V: Skyrim Special Edition';
    const actual = await gameBlock.getText();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
