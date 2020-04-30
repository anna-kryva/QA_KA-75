const { Builder, By, until } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.sportlife.ua/uk/about/lookingforstaff";

describe("Looking for staff", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  let anchor;

  before(async () => {
    await driver.get(URL);
  });

  it("should get the link", async () => {
    anchor = await driver.findElement(
      By.xpath("//div[contains(@class, 'jobs-list hot')]/ul/li[1]/a")
    );

    const expected = "https://www.sportlife.ua/uk/clubs/kiev/gatnoe/vacancy";
    const actual = await anchor.getAttribute("href");
    chai.assert.equal(expected, actual);
  });

  it("should click and get the list of vacancies", async () => {
    await anchor.click();

    await driver.wait(
      until.urlIs("https://www.sportlife.ua/uk/clubs/kiev/gatnoe/vacancy"),
      1000
    );
    await driver.wait(
      until.elementsLocated(By.tagName("h3")),
      1000
    );

    const tagArray = await driver.findElements(By.tagName("h3"));
    const actual = [];
    for (let tag of tagArray) {
      let text = await tag.getText();
      actual.push(text);
    }

    const expected = ['Адміністрація', 'Фітнес'];

    chai.expect(actual).to.eql(expected);
  });

  after(async () => {
    await driver.quit();
  });
});
