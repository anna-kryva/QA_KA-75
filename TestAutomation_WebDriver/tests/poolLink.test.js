const { Builder, By } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.sportlife.ua/uk/fitness/15966";

describe("Go via the pool link", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  let clubsLink;

  before(async () => {
    await driver.get(URL);
  });

  it("should be link at the bottom", async () => {
    clubsLink = await driver.findElement(By.xpath("//p[@class='bottom-link']//a"));

    const expected = "Плавай";
    const actual = await clubsLink.getText();
    chai.assert.equal(expected, actual);
  });

  it("should click and go to the clubs page", async () => {
    await clubsLink.click();

    const expected = "https://www.sportlife.ua/uk/clubs";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
