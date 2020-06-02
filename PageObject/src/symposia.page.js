
const page = require('./page')

class SymposiaPage extends page {
    URL = 'http://best.eu.org/educationalInvolvement/BESTSymposiaOnEducation.jsp';
    SEASONS_BUTTON = `//*[@id="other-seasons"]`;
    ACTIVITIES_XPATH = `//*[@id="content"]/table/tbody`;

    async loadPage() {
        await this.get(this.URL);
    }

    async selectSeason(xpath) {
        await this.clickByXPath(this.SEASONS_BUTTON);
        await this.clickByXPath(xpath);
    }

    async getActivityList() {
        const element = await this.elByXpath(this.ACTIVITIES_XPATH);
        const val =  await element.getAttribute('innerHTML');
        return val.replace(/^\s+|\s+$/g, '');
    }
}

module.exports = SymposiaPage;
