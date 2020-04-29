const { Builder, By, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");

const chai = require("chai");

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());

const URL = "https://www.sportlife.ua/uk/beauty_health/spa";

describe("Go to massage salon page", () => {
  const driver = new Builder()
      .forBrowser("chrome")
      .withCapabilities(Capabilities.chrome())
      .build();

  it("should go to massage salon page", async () => {
    await driver.get(URL);
    await (await driver.findElement(By.xpath("//div[@class='b-side-menu']/ul/li[5]/div"))).click();

    const expected = "https://www.sportlife.ua/uk/beauty_health/massage_salon";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
