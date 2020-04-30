const { Builder, By } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.sportlife.ua/uk/clubs";

describe("Go to main page via the logo", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  before(async () => {
    await driver.get(URL);
  });

  it("should click on the logo and redirect to main page", async () => {
    await (await driver.findElement(By.className("b-logo"))).click();

    const expected = "https://www.sportlife.ua/uk";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
