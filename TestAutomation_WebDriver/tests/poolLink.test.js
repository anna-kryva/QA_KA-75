const { Builder, By, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");

const chai = require("chai");

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());

const URL = "https://www.sportlife.ua/uk/fitness/15966";

describe("Go via the pool link", () => {
  const driver = new Builder()
      .forBrowser("chrome")
      .withCapabilities(Capabilities.chrome())
      .build();

  let clubsLink;
  it("should be link at the bottom", async () => {
    await driver.get(URL);
    clubsLink = await driver.findElement(By.xpath("//p[@class='bottom-link']//a"));

    const expected = "Плавай";
    const actual = await clubsLink.getText();
    chai.assert.equal(expected, actual);
  });

  it("should click and go to the clubs page", async () => {
    await clubsLink.click();

    const expected = "https://www.sportlife.ua/uk/clubs";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
