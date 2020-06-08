import {
  ChromiumBrowser,
  chromium,
  Page,
  ChromiumBrowserContext,
} from "playwright";

export class UkrNetPageObject {
  private browser: ChromiumBrowser;
  private context: ChromiumBrowserContext;
  private page: Page;
  private ukrNetUrl: string;
  constructor() {
    this.ukrNetUrl = "https://www.ukr.net/";
  }
  async init() {
    if (!this.browser)
      this.browser = await chromium.launch({
        headless: true,
      });
    if (!this.context) this.context = await this.browser.newContext();
    if (!this.page) this.page = await this.context.newPage();
    await this.page.goto(this.ukrNetUrl);
    try {
      await this.page.waitForSelector("#search-input");
    } catch (e) {
      throw new Error("Cant load page");
    }
  }
  async deInit() {
    await this.browser.close();
  }
  private async wait(timeMs: number) {
    await new Promise((res) => setTimeout(res, timeMs));
  }

  async search(query: string): Promise<string> {
    await this.page.goto(this.ukrNetUrl);
    await this.page.fill("#search-input", query);
    await this.page.keyboard.press("Enter");
    await this.wait(3000);
    const newPage = this.context.pages()[this.context.pages().length - 1];
    const googleResult = await newPage.$eval(
      'input[class="gLFyf gsfi"]',
      (el) => el.getAttribute("value")
    );
    await newPage.close();
    return googleResult;
  }

  async switchLangToRuss(): Promise<boolean> {
    await (await this.page.$("#act-lang")).click();
    await (await this.page.$(".dropdown > a")).click();
    await this.wait(3000);
    const elText = await (await this.page.$("a[lc='229']")).innerText();
    return elText === "Главное";
  }

  async goToSinoptik() {
    await (await this.page.$("a[lc='596']")).click();
    await this.wait(3000);
    const newPage = this.context.pages()[this.context.pages().length - 1];

    const result = newPage.url().includes("sinoptik.ua");
    await newPage.close();
    return result;
  }

  async fillEmailInput(email: string) {
    const frame = this.page.frames().find((f) => f.name() === "mail widget");
    await frame.fill("#id-input-login", email);
  }

  async fillPwInput(pw: string) {
    const frame = this.page.frames().find((f) => f.name() === "mail widget");
    await frame.fill("#id-input-password", pw);
  }

  async submitEmailForm() {
    const frame = this.page.frames().find((f) => f.name() === "mail widget");
    await frame.click(".form__submit");
  }

  async isFormErrorExists(): Promise<boolean> {
    const frame = this.page.frames().find((f) => f.name() === "mail widget");

    if (await frame.$(".form__error_visible")) return true;

    return false;
  }

  async goToMainNews() {
    await (await this.page.$("a[lc='229']")).click();
    await this.page.waitForSelector("#main > div > h2");
    return (
      (await (await this.page.$("#main > div > h2")).innerText()) ===
      "Головні події України та світу"
    );
  }

  async goToPwRestorePage() {
    const frame = this.page.frames().find((f) => f.name() === "mail widget");
    await frame.click(".form__link");

    const newPage = this.context.pages()[this.context.pages().length - 1];
    const result = newPage.url().includes("accounts.ukr.net/recovery");
    await newPage.close();
    return result;
  }
  async goToRegisterPage() {
    const frame = this.page.frames().find((f) => f.name() === "mail widget");

    await frame.click("div.form__navigation > div > a:nth-child(2)");

    const newPage = this.context.pages()[this.context.pages().length - 1];
    const result = newPage.url().includes("accounts.ukr.net/registration");
    await newPage.close();
    return result;
  }
}
