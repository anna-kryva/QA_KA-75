const { Builder, By, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");

const chai = require("chai");

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());

const URL = "https://www.sportlife.ua/uk/about/trainers_partners";

describe("Choose club", () => {
  const driver = new Builder()
      .forBrowser("chrome")
      .withCapabilities(Capabilities.chrome())
      .build();

  it("the submenu should be visible", async () => {
    await driver.get(URL);
    await (await driver.findElement(By.id("advanced-select"))).click();
    
    const isDisplayed = await (await driver.findElement(By.id("trainers-clubs-menu"))).isDisplayed();
    chai.expect(isDisplayed).to.be.true;
  });

  it("should choose club", async () => {    
    const club = await driver.findElement(By.xpath("//*[@id='trainers-clubs-menu']/div/div/div[2]/div[2]/div[2]/div[5]"));
    await club.click();

    const expected = "Приозерний";
    const actual = await (await driver.findElement(By.id("advanced-select"))).getText();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
