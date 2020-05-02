const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const MainPage = require("../lib/pages/main.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Choose the club from a list", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new MainPage(webdriver, driver);
  });

  it("should mouse over menu tab", async () => {
    await page.loadPage();
    await page.moveToMenuTab();

    const isDisplayed = await page.isMenuDisplayed();
    chai.expect(isDisplayed).to.be.true;
  });

  it("should click on menu item and go to the club page", async () => {
    await page.clickSubMenuItem();

    const expected = "https://www.sportlife.ua/uk/clubs/kiev/obolon";
    const actual = await page.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await page.quit();
  });
});