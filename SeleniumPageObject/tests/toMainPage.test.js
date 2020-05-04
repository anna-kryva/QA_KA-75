const webdriver = require("selenium-webdriver");
const chai = require("chai");
const MainPage = require("../src/pages/main.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Go to main page via the logo", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before (async ()=>{
    page = new MainPage(webdriver, driver);
    await page.maximizeWindow();
  });

  it("should click on the logo and redirect to main page", async () => {
    await page.loadPage();
    await page.clickOnLogo();
    await page.waitPageLoad();

    const expected = "https://store.steampowered.com/";
    const actual = await page.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await page.quit();
  });
});