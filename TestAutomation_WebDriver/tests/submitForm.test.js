const { Builder, By, until, Capabilities } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");

const chai = require("chai");

const URL = "https://shop.sportlife.ua/index.php?route=checkout/checkout_fast&product_id=1822&city_id=556";

describe("Fill the form to pay", () => {
  const driver = global.driver;

  before(async () => {
    await driver.get(URL);
  });

  it("should redirect to liqpay", async () => {
    await driver.manage().window().maximize();

    await driver.wait(until.elementLocated(By.id("user_info")), 1000);
    
    const firstname = await driver.findElement(By.id("firstname"));
    await firstname.sendKeys("firstname");

    const lastname = await driver.findElement(By.id("lastname"));
    await lastname.sendKeys("lastname");

    const phone = await driver.findElement(By.id("phone"));
    await phone.sendKeys("+380000000000");

    const email = await driver.findElement(By.id("email"));
    await email.sendKeys("email@email.com");
    
    const button = await driver.findElement(By.xpath("//form[@id='user_info']/button"));
    await button.click();

    const link = "liqpay.ua";
    await driver.wait(until.urlContains(link), 10000);

    const currentUrl = await driver.getCurrentUrl();
    chai.expect(currentUrl).to.have.string(link);
  });

  after(async () => { await driver.quit()});
});
