const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const ShopPage = require("../lib/pages/shop.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Fill the form to pay", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new ShopPage(webdriver, driver);
  });

  it("should fill out form and redirect to liqpay", async () => {
    await page.loadPage();
    await page.maximizeWindow();
    await page.waitFormToLoad();

    await page.fillOutForm();
    await page.submitForm();

    await page.waitLiqpayPageLoad();

    const link = "liqpay.ua";
    const currentUrl = await page.getCurrentUrl();
    chai.expect(currentUrl).to.have.string(link);
  });

  after(async () => {
    await page.quit();
  });
});
