import Mocha from "mocha";
import config from "../config.json";

let asyncForEach = async (arr:any, cb:any) => {
    for (let i = 0; i < arr.length; i++) {
      await cb(arr[i], i, arr);
    }
  };
  
  (async () => {
    await asyncForEach(config.tests, async (testCase:any) => {
  
      const mocha = new Mocha({
        timeout: testCase.timeout,
        reporter: 'mocha-junit-reporter',
        reporterOptions: {
            mochaFile: `./results/${testCase.file}.xml`
        }
      });
  
      return new Promise((resolve, reject) => {
        console.log(`Running ${testCase.file}`);
  
        mocha.addFile(`${testCase.file}`);
  
        mocha
          .run()
          .on("fail", (test) =>
            reject(new Error(`Dropbox WebApi test (${test.title}) failed.`))
          )
          .on("end", () => resolve());
      });
    });
  })();