const webdriver = require("selenium-webdriver");
const chai = require("chai");
const TesPage = require("../src/pages/tes.page");
const CartPage = require("../src/pages/cart.page");
const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Find games with filters", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before (async ()=>{
    tesPage = new TesPage(webdriver, driver);
    cartPage = new CartPage(webdriver, driver);
    awaittesPage.maximizeWindow();
  });

  it("should click on the logo and redirect to main page", async () => {
    await tesPage.loadPage();
    await tesPage.skipAgeCheck();
    await tesPage.waitPageLoad();
    await tesPage.addToCart();
    await cartPage.waitCartPageLoad();


    const expected = "The Elder Scrolls Online Standard Edition";
    const actual = (await cartPage.getNameTopGame());
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await tesPage.quit();
  });
});
