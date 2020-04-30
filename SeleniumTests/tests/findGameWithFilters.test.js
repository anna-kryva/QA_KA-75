const { Builder, By, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/";

describe("Find games with filters", () => {
  const driver = global.driver;
  
  before(async () => {
    await driver.get(URL);
    await driver.manage().window().maximize();
  });

  it("open rpg tag", async () => {
    await (await driver.findElement(By.xpath("/html/body/div[1]/div[7]/div[4]/div[1]/div[2]/div[1]/div[2]/a[9]"))).click();
    await (await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/div[1]/div[3]/div[4]/div/div[2]/div[2]/a[2]'))).click();
    const expected = 'The Elder Scrolls® Online';
    const actual = await (await driver.findElement(By.xpath('//*[@id="search_resultsRows"]/a[1]/div[2]/div[1]/span'))).getText();

    
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
