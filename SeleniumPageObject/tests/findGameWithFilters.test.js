const webdriver = require("selenium-webdriver");
const chai = require("chai");
const MainPage = require("../src/pages/main.page");
const FilterPage = require("../src/pages/filter.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Find games with filters", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before (async ()=>{
    mainPage = new MainPage(webdriver, driver);
    filterPage = new FilterPage(webdriver, driver);
    mainPage.maximizeWindow();
  });

  it("should click on the logo and redirect to main page", async () => {
    await mainPage.loadPage();
    await mainPage.clickRpgTag();
    await filterPage.waitPageLoad();
    await filterPage.clickOnFantasyTag();
    await filterPage.waitFantasyPageLoad();

    const expected = "The Elder Scrolls® Online";
    const actual = await filterPage.getNameTopGame();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await mainPage.quit();
  });
});
