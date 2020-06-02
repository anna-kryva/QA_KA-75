const page = require('./page')

class NewsPage extends page {
    WELCOME_URL = 'http://best.eu.org/career/welcome.jsp';
    RSS_XPATH = `//article[@id='content']//a[@href='/news/newsFeed.jsp?location=Public:+career&target=career']`;

    async loadPage() {
        await this.get(this.WELCOME_URL);
    }

    async clickRSS() {
        await this.clickByXPath(this.RSS_XPATH);
    }
}

module.exports = NewsPage;
