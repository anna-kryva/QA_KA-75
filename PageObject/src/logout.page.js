
const SignedIn = require('./signin')

class LogoutPage extends SignedIn {
    URL = 'http://best.eu.org/';
    LOGOUT_URL = 'http://best.eu.org/logout.jsp';

    async loadPage() {
        await this.get(this.URL);
    }

    async logout() {
        await this.get(this.LOGOUT_URL);
    }

}

module.exports = LogoutPage;
