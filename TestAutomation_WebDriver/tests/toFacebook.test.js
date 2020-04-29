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
      
  let fbImage;

  it("should find the icon", async () => {
    await driver.get(URL);
    fbImage = await driver.findElement(By.xpath("//div[contains(@class, 'sl-social')]//a[2]/img"));

    const expected = "https://www.sportlife.ua/sites/default/files/icons-social/icon-fb-2.jpg";
    const actual = await fbImage.getAttribute("src");
    chai.assert.equal(expected, actual);
  });

  it("should click the image and go to the facebook page", async () => {
    await fbImage.click();

    const windowTabs = await driver.getAllWindowHandles();
    await driver.switchTo().window(windowTabs[1]);
    await driver.wait(until.urlIs("https://www.facebook.com/sportlifeua"), 2000);

    const expected = "https://www.facebook.com/sportlifeua";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
