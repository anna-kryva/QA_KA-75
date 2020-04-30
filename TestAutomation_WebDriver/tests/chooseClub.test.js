const { Builder, By } = require("selenium-webdriver");

const chai = require("chai");

const URL = "https://www.sportlife.ua/uk/";

describe("Choose the club from a list", () => {
  const driver = global.driver
        ? global.driver
        : new Builder().forBrowser('chrome').build();

  before(async () => {
    await driver.get(URL);
  });

  it("should mouse over menu tab", async () => {
    const actions = driver.actions({async: true});

    const menuTab = await driver.findElement(By.id('menu-item-clubs'));
    actions.move({origin: menuTab}).perform();    

    const isDisplayed = await (await driver.findElement(By.id("main-submenu-clubs"))).isDisplayed();
    chai.expect(isDisplayed).to.be.true;
  });

  it("should click on menu item and go to the club page", async () => {
    const subMenu = await driver.findElement(By.xpath("//*[@id='main-submenu-clubs']/div/div[1]/div[2]/div[2]/div[5]/a"));
    await subMenu.click();

    const expected = "https://www.sportlife.ua/uk/clubs/kiev/obolon";
    const actual = await driver.getCurrentUrl();
    chai.assert.equal(expected, actual);
  });

  after(async () => { await driver.quit()});
});
