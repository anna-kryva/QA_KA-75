const { Builder, By, until } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.olx.ua/";

describe("Go registration via add advertisment button", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  before(async () => {
    await driver.get(URL);
  });

  it("go to registration", async () => {
    const button = await driver.findElement(By.id("postNewAdLink" ));
    await button.click();
    const link = "https://www.olx.ua/account/";
    await driver.wait(until.urlContains(link), 20000);

    const currentUrl = await driver.getCurrentUrl();
    chai.expect(currentUrl).to.have.string(link);

  });
  

});
