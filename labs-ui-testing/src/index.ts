import {launch} from "puppeteer"

const main = async () => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto("https://google.com")
    try {
        await page.waitForSelector("#hplogo")
    } catch (e) {
        console.log(e)
    }
    await browser.close()
}
main()
    .then(res=> process.exit())
    .catch(err => process.exit(1))
