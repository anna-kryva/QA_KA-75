const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const MainPage = require("../lib/pages/main.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Redirect to Facebook", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new MainPage(webdriver, driver);
  });

  it("should click the image and go to the facebook page", async () => {
    await page.loadPage();
    await page.clickFbImage();
    await page.switchToSecondTab();
    await page.waitFbPageLoad();

    const expected = "https://www.facebook.com/sportlifeua";
    const actual = await page.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await page.quit();
  });
});
