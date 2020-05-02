const chromedriver = require("chromedriver");
const webdriver = require("selenium-webdriver");
const chai = require("chai");

const VacancyPage = require("../lib/pages/vacancy.page");

const driver = global.driver
  ? global.driver
  : new webdriver.Builder().forBrowser("chrome").build();

describe("Looking for staff", () => {
  process.on("unhandledRejection", (error) => {
    throw error; // promote promise warning to mocha error
  });

  let page;

  before(async () => {
    page = new VacancyPage(webdriver, driver);
  });

  it("should click on the link and get the list of vacancies", async () => {
    await page.loadPage();
    await page.clickGatnoe();
    await page.waitGatnoePageLoad();

    const expected = ['Адміністрація', 'Фітнес'];
    const actual = await page.getVacancies();
    chai.expect(actual).to.eql(expected);
  });

  after(async () => {
    await page.quit();
  });
});