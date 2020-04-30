const { Builder, By, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/";

describe("Go to main page via the logo", () => {
  const driver = global.driver;

  before(async () => {
    await driver.get(URL);
  });

  it("should click on the logo and redirect to main page", async () => {
    await (await driver.findElement(By.id("logo_holder"))).click();

    const expected = "https://store.steampowered.com/";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
