const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const MainPage = require("../lib/pages/main.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Go registration via add advertisment button", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new MainPage(webdriver, driver);
  });

  it("go to registration", async () => {
    await page.loadPage();
    await page.clickButton();
    const link = "https://www.olx.ua/account/";
    const currentUrl = await page.getCurrentUrl();
    chai.expect(currentUrl).to.have.string(link);

  });

  // after(async () => {
  //   await page.quit();
  // });
});
