const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const PoolPage = require("../lib/pages/pool.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Go via the pool link", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new PoolPage(webdriver, driver);
  });

  it("should click and go to the clubs page", async () => {
    await page.loadPage();
    await page.clickClubsLink();

    const expected = "https://www.sportlife.ua/uk/clubs";
    const actual = await page.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await page.quit();
  });
});
