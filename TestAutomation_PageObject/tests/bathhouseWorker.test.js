const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const TrainersPage = require("../lib/pages/trainers.page");

const URL =
  "https://www.sportlife.ua/uk/about/trainers_partners/selected/18422/0";

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Select a bathhouseworker tab", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new TrainersPage(webdriver, driver, URL);
  });

  it("list should be empty", async () => {
    await page.loadPage();
    await page.clickFilterItem();

    const isListEmpty = await page.isListEmpty();
    chai.expect(isListEmpty).to.be.false;
  });

  after(async () => {
    await page.quit();
  });
});
