const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require('selenium-webdriver/chrome');
const chromedriver = require('chromedriver');

chrome.setDefaultService(new chrome.ServiceBuilder(chromedriver.path).build());
const URL = "https://shop.sportlife.ua/ukraine2/Chain_sale?utm_source=sportlife.ua&utm_medium=header&utm_campaign=SLua-to-Shop&utm_term=top-all-pages";


(async function example() {
  let driver = await new Builder()
        .forBrowser("chrome")
        .withCapabilities(Capabilities.chrome())
        .build();
  try {
    await driver.get(URL);
    //*[@id="mfilter-content-opts-0-0"]/div/div/ul/li[4]/div[1]/a
    await driver.wait(until.elementLocated(By.id("mfilter-content-opts-0-0")), 100000);
    // const filter = await driver.findElement(By.xpath("//a[@data-id='593']"));
    // await filter.click();
    
    
  } catch (error) {
    console.log(error.message);
  } finally {
    await driver.quit();
  }
})();
