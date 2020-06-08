import { UkrNetPageObject } from "./ukr-net.page-object";

const main = async () => {
  const page = new UkrNetPageObject();
  await page.init();
  console.log(await page.goToRegisterPage());
};
main();
