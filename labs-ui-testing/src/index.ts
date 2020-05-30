import {launch} from "puppeteer"

const main = async () => {
    const browser = await launch();
    console.log("Browser started")
    const page = await browser.newPage();
    await page.goto("https://google.com")
    try {
        await page.waitForSelector("#hplogo",{timeout: 30000})
        console.log("success")
    } catch (e) {
        console.log(e)
    }
    await browser.close()
}
main()
    .then(res=> process.exit())
    .catch(err => process.exit(1))
