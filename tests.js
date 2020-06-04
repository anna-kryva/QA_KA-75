const chromedriver = require("chromedriver");
const { Builder } = require("selenium-webdriver");
const config = require("./config.json");
const Mocha = require("mocha");


let asyncForEach = async (arr, cb) => {
  for (let i = 0; i < arr.length; i++) {
    await cb(arr[i], i, arr);
  }
};

(async () => {
  await asyncForEach(config.tests, async (testCase) => {
    global.driver = await new Builder()
        .forBrowser("chrome")
        .build();

    const mocha = new Mocha({
      timeout: testCase.timeout,
      reporter: 'mocha-junit-reporter',
      reporterOptions: {
          mochaFile: `./results/${testCase.fileName}.xml`
      }
    });

    return new Promise((resolve, reject) => {
      console.log(`Running ${testCase.fileName}`);

      mocha.addFile(`${testCase.filePath}`);

      mocha
        .run()
        .on("fail", (test) =>
          reject(new Error(`Selenium test (${test.title}) failed.`))
        )
        .on("end", () => resolve());
    });
  });
})();
