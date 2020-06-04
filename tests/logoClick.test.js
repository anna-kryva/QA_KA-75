const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const MianPage = require("../lib/pages/main.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Go to main page by the logo clicking", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new MianPage(webdriver, driver);
  });

  it("should click on the logo and redirect to main page", async () => {
    await page.loadPage();
    await page.clickLogo();

    const expected = "https://www.olx.ua/";
    const actual = await page.getCurrentUrl();
    await chai.assert.equal(expected, actual);
  });

  // after(async () => {
  //   await page.quit();
  // });
});
