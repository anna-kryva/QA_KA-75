const { Builder, By } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.olx.ua/";

describe("Go to main page via the logo", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  before(async () => {
    await driver.get(URL);
  });

  it("click to logo and go to main page", async () => {
    await (await driver.findElement(By.id("headerLogo"))).click();

    const expected = "https://www.olx.ua/";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

after(async () => { await driver.quit()});    
});
