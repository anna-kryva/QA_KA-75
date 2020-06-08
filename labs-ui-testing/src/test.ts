import { UkrNetPageObject } from "./ukr-net.page-object";

let ukrNetPage: UkrNetPageObject;
beforeEach(async () => {
  ukrNetPage = new UkrNetPageObject();
  await ukrNetPage.init();
});
afterEach(async () => {
  await ukrNetPage.deInit();
});
describe("page clicks should work as expected", () => {
  it("should procide correct query from google", async () => {
    const query = "Memes";
    const res = await ukrNetPage.search(query);
    expect(res).toBe(query);
  });
  it("should go to sinoptik and return true if result url is correct", async () => {
    expect(await ukrNetPage.goToSinoptik()).toBe(true);
  });
  it("should go to main news and return true if result url is correct", async () => {
    expect(await ukrNetPage.goToMainNews()).toBe(true);
  });
  it("should go to restore pw and return true if result url is correct", async () => {
    expect(await ukrNetPage.goToPwRestorePage()).toBe(true);
  });
  it("should go to register and return true if result url is correct", async () => {
    expect(await ukrNetPage.goToRegisterPage()).toBe(true);
  });
});
describe("page should change lang correctly", () => {
  it("should change lang to rus and return true if correct", async () => {
    expect(await ukrNetPage.switchLangToRuss()).toBe(true);
  });
});

describe("email form should work correct", () => {
  it("should get and error on page if both email and pw are empty", async () => {
    await ukrNetPage.submitEmailForm();
    expect(await ukrNetPage.isFormErrorExists()).toBe(true);
  });

  it("should get and error on page if email is empty", async () => {
    await ukrNetPage.fillPwInput("adasdasdasd");
    await ukrNetPage.submitEmailForm();
    expect(await ukrNetPage.isFormErrorExists()).toBe(true);
    await ukrNetPage.fillPwInput("");
  });

  it("should get and error on page if pw is empty", async () => {
    await ukrNetPage.fillEmailInput("adasdasdasd");
    await ukrNetPage.submitEmailForm();
    expect(await ukrNetPage.isFormErrorExists()).toBe(true);
    await ukrNetPage.fillEmailInput("");
  });
  it("should provide no errors if email and pw is not empty", async () => {
    await ukrNetPage.fillEmailInput("adasdasdasd");
    await ukrNetPage.fillPwInput("adasdasdasd");
    await ukrNetPage.submitEmailForm();
    expect(await ukrNetPage.isFormErrorExists()).toBe(false);
  });
});
