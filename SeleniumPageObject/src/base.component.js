class ComponentBase {
  constructor(webdriver, driver, waitTimeout = 10000) {
    this.webdriver = webdriver;
    this.driver = driver;
    this.waitTimeout = waitTimeout;
  }

  //wait for one element
  async waitForElement(selector, elementName, waitTimeout) {
    let result;
    await this.driver.wait(
      () =>
        this.driver.findElement(selector).then(
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
      waitTimeout,
      `Unable to find element: ${elementName}`
    );
    return result;
  }

  async waitForElementByCss(cssName, waitTimeout = 10000) {
    const selector = this.webdriver.By.css(cssName);
    const result = await this.waitForElement(selector, cssName, waitTimeout);
    return result;
  }

  async waitForElementByXPath(xpath, waitTimeout = 10000) {
    const selector = this.webdriver.By.xpath(xpath);
    const result = await this.waitForElement(selector, xpath, waitTimeout);
    return result;
  }

  async waitForElementById(idName, waitTimeout = 10000) {
    const selector = this.webdriver.By.id(idName);
    const result = await this.waitForElement(selector, idName, waitTimeout);
    return result;
  }

  async waitForElementByTag(tagName, waitTimeout = 10000) {
    const selector = this.webdriver.By.tagName(tagName);
    const result = await this.waitForElement(selector, tagName, waitTimeout);
    return result;
  }

  //wait for some elements
  async waitForElements(selector, elementsName, waitTimeout) {
    let result;
    await this.driver.wait(
      () =>
        this.driver.findElements(selector).then(
          (elements) => {
            result = elements;
            return true;
          },
          (err) => {
            if (err.name === "NoSuchElementsError") {
              return false;
            }
            return true;
          }
        ),
      waitTimeout,
      `Unable to find elements: ${elementsName}`
    );
    return result;
  }

  async waitForElementsByCss(cssName, waitTimeout = 10000) {
    const selector = this.webdriver.By.css(cssName);
    const result = await this.waitForElements(selector, cssName, waitTimeout);
    return result;
  }

  async waitForElementsById(idName, waitTimeout = 10000) {
    const selector = this.webdriver.By.id(idName);
    const result = await this.waitForElements(selector, idName, waitTimeout);
    return result;
  }

  async waitForElementsByXPath(xpath, waitTimeout = 10000) {
    const selector = this.webdriver.By.xpath(xpath);
    const result = await this.waitForElements(selector, xpath, waitTimeout);
    return result;
  }

  async waitForElementsByTag(tagName, waitTimeout = 10000) {
    const selector = this.webdriver.By.tagName(tagName);
    const result = await this.waitForElements(selector, tagName, waitTimeout);
    return result;
  }

  //wait for url
  async waitForUrlToBe(url, waitTimeout = 10000) {
    await this.driver.wait(this.webdriver.until.urlIs(url), waitTimeout);
  }

  async waitForUrlToContain(subUrl, waitTimeout = 10000) {
    await this.driver.wait(
      this.webdriver.until.urlContains(subUrl),
      waitTimeout
    );
  }

  //click when element is displayed and enable
  async clickWhenClickable(element, waitTimeout = 10000) {
    await this.driver.wait(
      this.webdriver.until.elementIsVisible(element),
      waitTimeout
    );
    await this.driver.wait(
      this.webdriver.until.elementIsEnabled(element),
      waitTimeout
    );

    await element.click();
  }

  async clickWhenClickableByCss(cssName, waitTimeout = 10000) {
    const element = await this.waitForElementByCss(cssName, waitTimeout);
    await this.clickWhenClickable(element, waitTimeout);
  }

  async clickWhenClickableByXPath(xpath, waitTimeout = 10000) {
    const element = await this.waitForElementByXPath(xpath, waitTimeout);
    await this.clickWhenClickable(element, waitTimeout);
  }

  async clickWhenClickableById(idName, waitTimeout = 10000) {
    const element = await this.waitForElementById(idName, waitTimeout);
    await this.clickWhenClickable(element, waitTimeout);
  }

  //send keys when element is displayed and enable
  async sendKeysWhenEnable(element, argument, waitTimeout = 10000) {
    await this.driver.wait(
      this.webdriver.until.elementIsVisible(element),
      waitTimeout
    );
    await this.driver.wait(
      this.webdriver.until.elementIsEnabled(element),
      waitTimeout
    );

    await element.sendKeys(argument);
  }

  async sendKeysWhenEnableById(idName, argument, waitTimeout = 10000) {
      const element = await this.waitForElementById(idName, waitTimeout);
      await this.sendKeysWhenEnable(element, argument, waitTimeout);
  }

  //get attribute
  async getAttributeSrc(element) {
    return await element.getAttribute("src");
  }

  async getAttributeHref(element) {
    return await element.getAttribute("href");
  }

  async getAttributeValue(element) {
    return await element.getAttribute("value");
  }


  async getInputValueById(idName, waitTimeout = 10000) {
      const element = await this.waitForElementById(idName, waitTimeout);
      const result = await this.getAttributeValue(element);
      return result;
  }

  //true if element exists, otherwise false
  async isArrayEmpty(array) {
    if (array.length == 0) {
      return true;
    } else {
      return false;
    }
  }

  async doExistByCss(cssName, waitTimeout = 10000) {
    const elements = await this.waitForElementsByCss(cssName, waitTimeout);
    const result = !this.isArrayEmpty(elements);
    return result;
  }

  async doExistByXPath(xpath, waitTimeout = 10000) {
    const elements = await this.waitForElementsByXPath(xpath, waitTimeout);
    const result = !this.isArrayEmpty(elements);
    return result;
  }

  async doExistById(idName, waitTimeout = 10000) {
    const elements = await this.waitForElementsById(idName, waitTimeout);
    const result = !this.isArrayEmpty(elements);
    return result;
  }
}

module.exports = ComponentBase;