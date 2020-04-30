const { Builder, By } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.sportlife.ua/uk/about/trainers_partners/selected/18422/0";

describe("Select a bathhouseworker tab", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();
  
  before(async () => {
    await driver.get(URL);
  });

  it("list should be empty", async () => {
    await (await driver.findElement(By.xpath("//*[@id='specialization-filter']/ul/li[10]"))).click();

    const isDisplayed = await (await driver.findElements(By.className("view-content"))).length > 0;
    chai.expect(isDisplayed).to.be.false;
  });

  after(async () => { await driver.quit()});
});
