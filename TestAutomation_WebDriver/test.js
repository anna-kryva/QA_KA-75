const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require('selenium-webdriver/chrome');
const chromedriver = require('chromedriver');

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());
const URL = "https://www.sportlife.ua/uk/";


(async function example() {
  let driver = await new Builder()
        .forBrowser("chrome")
        .withCapabilities(Capabilities.chrome())
        .build();
  try {
    await driver.get(URL);
    const icon = await driver.findElement(By.xpath("//div[contains(@class, 'sl-social')]/a[2]"));
    await icon.click();
    await driver.wait(until.elementsLocated(By.id("u_0_0")), 10000);
    
    
  } catch (error) {
    console.log(error.message);
  } finally {
    await driver.quit();
  }
})();
