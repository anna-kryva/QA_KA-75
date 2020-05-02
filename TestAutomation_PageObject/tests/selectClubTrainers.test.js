const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const TrainersPage = require("../lib/pages/trainers.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Select club trainers", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new TrainersPage(webdriver, driver);
  });

  it("the submenu should be visible", async () => {
    await page.loadPage();
    await page.clickSelector();

    const isDisplayed = await page.isSubMenuDisplayed();
    chai.expect(isDisplayed).to.be.true;
  });

  it("should choose club", async () => {
    await page.clickClub();

    const expected = "Приозерний";
    const actual = await page.getClubName();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await page.quit();
  });
});