const ComponentBase = require('../base.component');

class PageBase extends ComponentBase{
    constructor(webdriver, driver, targetUrl, waitTimeout = 10000){
        super(webdriver, driver, waitTimeout);
        this.targetUrl = targetUrl;
    }

    async loadPage(){
        await this.driver.get(this.targetUrl); 
    }

    async quit(){
        await this.driver.quit();
    }

    async getCurrentUrl(){
        return await this.driver.getCurrentUrl();
    }

    async maximizeWindow(){
        await this.driver.manage().window().maximize();
    }

} 
module.exports = PageBase;