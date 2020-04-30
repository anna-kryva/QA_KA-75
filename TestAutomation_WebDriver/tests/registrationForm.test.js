const { Builder, By, Capabilities,until } = require("selenium-webdriver");
const chrome = require("selenium-webdriver/chrome");
const chromedriver = require("chromedriver");
const chai = require("chai");

const URL = "https://store.steampowered.com/login/?redir=&redir_ssl=1";

describe("Join to steam (Test capcha)))", () => {
  const driver = global.driver;

  before(async () => {
    await driver.get(URL);
    await driver.manage().window().maximize();
  });

  it("Enter email", async () => {
    const join = await driver.findElement(By.xpath('/html/body/div[1]/div[7]/div[4]/div[2]/div[2]/div/div/div[3]/a'));
    await join.click();

    await driver.wait(until.urlContains('join'),10000);

    const email = await driver.findElement(By.id('email'));
    email.sendKeys('babubay@gmail.com');
    const reemail = await driver.findElement(By.id('reenter_email'));
    reemail.sendKeys('babubay@gmail.com');
    const agree  = await driver.findElement(By.id('i_agree_check'));
    agree.click();
    
    await driver.wait(()=>{return true;},1000);
    // const capcha = await driver.findElement(By.xpath('//*[@id="recaptcha-anchor"]'));
    // capcha.click();
    chai.assert.equal(0,0);
  });

  after(async () => { await driver.quit()});
});
