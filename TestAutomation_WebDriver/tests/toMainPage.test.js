const { Builder, By, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");

const chai = require("chai");

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());

const URL = "https://www.sportlife.ua/uk/clubs";

describe("Go to main page via the logo", () => {
  const driver = new Builder()
      .forBrowser("chrome")
      .withCapabilities(Capabilities.chrome())
      .build();

  it("should be true", async () => {
    await driver.get(URL);
    await (await driver.findElement(By.className("b-logo"))).click();

    const expected = "https://www.sportlife.ua/uk";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
