const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/";

describe("Redirect to Facebook", () => {
  const driver = global.driver;
      
  let fbImage;

  before(async () => {
    await driver.get(URL);
  });

  it("should find the icon", async () => {
    fbImage = await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/div[4]/div/div[7]/a[6]/img'));

    const expected = "https://steamstore-a.akamaihd.net/public/images/ico/ico_facebook.gif";
    const actual = await fbImage.getAttribute("src");
    chai.assert.equal(expected, actual);
  });

  it("should click the image and go to the facebook page", async () => {
    await fbImage.click();

    const windowTabs = await driver.getAllWindowHandles();
    await driver.switchTo().window(windowTabs[1]);
    await driver.wait(until.urlIs("https://www.facebook.com/Steam"), 2000);

    const expected = "https://www.facebook.com/Steam";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);

  });

  after(async () => { await driver.quit()});
});
