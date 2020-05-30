import checkAuth from './spec/check.auth.spec';
import { expect } from 'chai';
import Mocha from "mocha";

var mocha = new Mocha({
    reporter: 'mocha-junit-reporter',
    reporterOptions: {
        testCaseSwitchClassnameAndName: true,
        toConsole: true
    }
});

describe('Check auth token',()=>{
    it('should return true',async ()=>{
        const result = await checkAuth();
        expect(result).is.true;
        console.log("\n\tAuth token is valid \n");
        
    }).timeout(15000);
});