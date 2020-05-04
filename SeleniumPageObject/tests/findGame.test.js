const webdriver = require("selenium-webdriver");
const chai = require("chai");
const MainPage = require("../src/pages/main.page");
const FilterPage = require("../src/pages/filter.page");
const TesPage = require("../src/pages/tes.page");
const gameName = "skyrim";

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Find game by name", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let mainPage;

  before (async ()=>{
    mainPage = new MainPage(webdriver, driver);
    filterPage = new FilterPage(webdriver, driver);
    tesPage = new TesPage(webdriver, driver);
    await mainPage.maximizeWindow();
  });

  it("should find game by name", async () => {
    await mainPage.loadPage();
    await mainPage.searchByWord("The Elder Scrolls® Online");
    await filterPage.loadTopGamePage();
    await mainPage.skipAgeCheck();
    await tesPage.waitPageLoad();
    

    const expected = "The Elder Scrolls® Online";
    const actual = await tesPage.getTopGameName();
    chai.assert.equal(expected, actual);
  });

  after(async () => {
    await filterPage.quit();
  });
});

