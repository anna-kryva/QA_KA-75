const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/search";

function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

describe("Find game with tags and filters", () => {
  const driver = global.driver;

  before(async () => {
    await driver.get(URL);
    await driver.manage().window().maximize();
  });
  it('should find game by tags', async () =>{
    await sleep(2000);
    const adTag = await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/form/div[1]/div/div[2]/div[2]/div[2]/div/div[3]/span[1]'));
    await adTag.click();
    await  sleep(2000);
    const rpgTag = await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/form/div[1]/div/div[2]/div[2]/div[2]/div/div[5]'));
    await rpgTag.click();
    await  sleep(2000);
    const expected = 'The Elder Scrolls® Online';
    const actual = await( await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/form/div[1]/div/div[1]/div[3]/div/div[3]/a[1]/div[2]/div[1]/span'))).getText();
    chai.assert.equal(expected, actual);
  });

  // it('should find game by tag', async () => {
  //   const topTag = await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[1]/div[1]/div[8]/a[1]'));
  //   await topTag.click();
  //   await  sleep(2000);
  //   await driver.wait(until.elementLocated(By.xpath('/html/body/div[1]/div[7]/div[4]/form/div[1]/div/div[1]/div[3]/div/div[3]/a[2]/div[2]/div[1]/span')),10000);
  //   const expected = 'Borledlands 3';
  //   const actual = await( await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/form/div[1]/div/div[1]/div[3]/div/div[3]/a[2]/div[2]/div[1]/span'))).getText();

  //   chai.assert.equal(expected, actual);
  // });

  

  after(async () => { await driver.quit()});
});