const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const ClubsPage = require("../lib/pages/clubs.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Go to main page via the logo", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new ClubsPage(webdriver, driver);
  });

  it("should click on the logo and redirect to main page", async () => {
    await page.loadPage();
    await page.clickLogo();

    const expected = "https://www.sportlife.ua/uk";
    const actual = await page.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await page.quit();
  });
});
