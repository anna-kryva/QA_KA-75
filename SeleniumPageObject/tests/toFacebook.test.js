const webdriver = require("selenium-webdriver");
const chai = require("chai");
const MainPage = require("../src/pages/main.page");

const URL = "https://store.steampowered.com/";

const driver = global.driver ? global.driver : new webdriver.Builder().forBrowser("chrome").build();

describe("Redirect to Facebook", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before (async ()=>{
    page = new MainPage(webdriver, driver);
    page.maximizeWindow();
  });

  // it("should find the icon", async () => {
  //   page.

  //   const expected = "https://steamstore-a.akamaihd.net/public/images/ico/ico_facebook.gif";
  //   const actual = await fbImage.getAttribute("src");
  //   chai.assert.equal(expected, actual);
  // });

  it("should click to the fb logo and redirect to fb page of steam", async()=>{
    await page.loadPage();
    await page.waitFbLogo();
    await page.clickOnFbLogo();
    await page.switchToSecondTab();
    await page.waitFbPageLoad();

    const expected = "https://www.facebook.com/Steam";
    const actual = await page.getCurrentUrl();
    chai.assert.equal(expected, actual);
  })

  after(async () => { await driver.quit()});
});
