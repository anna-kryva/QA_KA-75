"use strict"; 

const { Key } = require('selenium-webdriver');

class page {
  constructor(webdrv, drv, timeout = 9999) {
    this.timeout = timeout;
    this.drv = drv;
    this.webdrv = webdrv;
  }

  async quit() {
    await this.drv.quit();
  }

  async get(url) {
    await this.drv.get(url);
  }

  async getCurrentUrl() {
    return await this.drv.getCurrentUrl();
  }

  async wait(selector, elementName, timeout) {
    let result;
    await this.drv.wait(
      () =>
        this.drv.findElement(selector).then(
          (element) => {
            result = element;
            return true;
          },
          (err) => {
            if (err.name === "NoSuchElementError") {
              return false;
            }
            return true;
          }
        ),
      timeout,
      `Unable to find element: ${elementName}`
    );
    return result;
 }

 async elByXpath(xpath, timeout = 9999) {
    const selector = this.webdrv.By.xpath(xpath);
    const result = await this.wait(selector, xpath, timeout);
    return result;
  }

  // click when element is displayed and enable
  async click(element, timeout = 9999) {
    await this.drv.wait(
      this.webdrv.until.elementIsVisible(element),
      timeout
    );
    await this.drv.wait(
      this.webdrv.until.elementIsEnabled(element),
      timeout
    );

    await this.drv.executeScript('arguments[0].click();', element);
  }

  async clickByXPath(xpath, timeout = 9999) {
    const element = await this.elByXpath(xpath, timeout);
    await this.click(element, timeout);
  }

  async insert(element, argument, timeout = 9999) {
    await this.drv.wait(
      this.webdrv.until.elementIsVisible(element),
      timeout
    );
    await this.drv.wait(
      this.webdrv.until.elementIsEnabled(element),
      timeout
    );

    await element.sendKeys(argument);
  }

  async insertByXPath(xpath, argument, timeout = 9999) {
      const element = await this.elByXpath(xpath, timeout);
      await this.insert(element, argument, timeout);
  }

  async getVal(element) {
    return await element.getAttribute("value");
  }

  async getValByXPath(xpath) {
    const element = await this.elByXpath(xpath);
    return await this.getVal(element);
  }

  async clearInput(element) {
    await this.drv.executeScript(elt => elt.select(), element);
    await element.sendKeys(Key.BACK_SPACE);
  }

  async clearInputByXpath(xpath) {
    const element = await this.elByXpath(xpath);
    await this.clearInput(element);
  }
}

module.exports = page;
