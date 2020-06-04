const { Builder, By, until } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.olx.ua/";

describe("Input the search", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  before(async () => {
    await driver.get(URL);
  });

  it("should redirect to search page", async () => {
    const search = await driver.findElement(By.id("headerSearch"));
    await search.sendKeys("search query");
    const button = await driver.findElement(By.id("submit-searchmain"));
    await button.click();
    const link = "https://www.olx.ua/list/q-";
    await driver.wait(until.urlContains(link), 10000);
    const currentUrl = await driver.getCurrentUrl();
    chai.expect(currentUrl).to.have.string(link);
  });


});
