'use strict';

const webdriver = require("selenium-webdriver");

const AccountPage = require('./src/acc.page');
const RegistrationPage = require('./src/reg.page');
const NewsPage = require('./src/news.page');
const SymposiaPage = require('./src/symposia.page');
const LogoutPage = require('./src/logout.page');

const getDriver = () => new webdriver.Builder().forBrowser("chrome").build();

const main = () => {
    test('Invalid Privacy policy link', async () => {
        const driver = getDriver();
        const page = new RegistrationPage(webdriver, driver);
        
        await page.loadPage();
        await page.clickPrivacyPolicy();

        await expect(page.getCurrentUrl())
            .resolves.toBe(page.REGISTRATION_URL);

        await page.quit();
    });

    test('Saving wrong number', async () => {
        const MOBILE_NUMBER = '+3801212121212121';

        const driver = getDriver();
        const page = new AccountPage(webdriver, driver);
        await page.goToAccSettings();

        await page.insertMobileNumber(MOBILE_NUMBER);
        await page.clickSave();

        await expect(page.getCurrentUrl())
            .resolves.toBe(page.ACC_SETTINGS_URL);
        await expect(page.getMobileNumber())
            .resolves.toBe(MOBILE_NUMBER);
        
        await page.quit();
    });

    test('Saving wrong email', async () => {
        const EMAIL = 'some_random_@mail.com';

        const driver = getDriver();
        const page = new AccountPage(webdriver, driver);
        await page.goToAccSettings();

        await page.insertEmail(EMAIL);
        await page.clickSave();

        await expect(page.getCurrentUrl())
            .resolves.toBe(page.ACC_SETTINGS_URL);
        await expect(page.getEmail())
            .resolves.toBe(EMAIL);
        
        await page.quit();
    });

    test('Saving wrong ICQ', async () => {
        const ICQ = '0';

        const driver = getDriver();
        const page = new AccountPage(webdriver, driver);
        await page.goToAccSettings();

        await page.insertICQ(ICQ);
        await page.clickSave();

        await expect(page.getCurrentUrl())
            .resolves.toBe(page.ACC_SETTINGS_URL);
        await expect(page.getICQ())
            .resolves.toBe(ICQ);
        
        await page.quit();
    });

    test('Saving email containing not allowed symbol', async () => {
        // when passing in emojii it throws SQL error directly
        // on the site, but currently selenium has no support 
        // for emojii, so let's put here just an unexpected
        // (for email field) `-` symbol, it will save it

        const EMAIL = '-@-.-';
        // const ERROR_XPATH = `//*[@id="header"]/h1`;
        // const ERROR_MSG =  'SQL Internal Makumba error';

        const driver = getDriver();
        const page = new AccountPage(webdriver, driver);
        await page.goToAccSettings();

        await page.insertEmail(EMAIL);
        await page.clickSave();

        await expect(page.getCurrentUrl())
            .resolves.toBe(page.ACC_SETTINGS_URL);
        await expect(page.getEmail())
            .resolves.toBe(EMAIL);
        
        await page.quit();
    });


    test('Checking RSS feed link to XML file', async () => {
        const URL = 'http://best.eu.org/news/newsFeed.jsp?location=Public:+career&target=career';

        const driver = getDriver();
        const page = new NewsPage(webdriver, driver);
        
        await page.loadPage();
        await page.clickRSS();
        await expect(page.getCurrentUrl())
            .resolves.toBe(URL);
        
        await page.quit();
    });

    test('No info about past events', async () => {
        const OLDEST_XPATH = `//*[@id="sidebar"]/section[1]/div[2]/div/ul/li[86]/a`;

        const driver = getDriver();
        const page = new SymposiaPage(webdriver, driver);
        
        await page.loadPage();
        await page.selectSeason(OLDEST_XPATH);
        await expect(page.getActivityList())
            .resolves.toBe('');
        
        await page.quit();
    });

    test('Logging out', async () => {
        const INDEX_URL = 'http://best.eu.org/index.jsp';

        const driver = getDriver();
        const page = new LogoutPage(webdriver, driver);
        
        await page.signin();
        await page.loadPage();
        await page.logout();

        await expect(page.getCurrentUrl())
            .resolves.toBe(INDEX_URL);
        
        await page.quit();
    });
}

main();
