const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");

const chai = require("chai");

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());

const URL = "https://www.sportlife.ua/uk/";

describe("Redirect to Facebook", () => {
  const driver = new Builder()
      .forBrowser("chrome")
      .withCapabilities(Capabilities.chrome())
      .build();

  it("should be true", async () => {
    await driver.get(URL);
    // /html/body/div[2]/div/div[4]/div/div[2]/div[2]/a[2]/img
    await (await driver.findElement(By.xpath("//div[contains(@class, 'sl-social')]//a[2]/img"))).click();
    // await driver.wait(until.elementsLocated(By.id("u_0_0")), 20000);
    // const text = await (await driver.findElement(By.id("u_0_0"))).getText();

    // const expected = "SPORT LIFE";
    // // const actual = await driver.getCurrentUrl();
    // chai.assert.equal(expected, text);
  });

  after(async () => { await driver.quit()});
});
