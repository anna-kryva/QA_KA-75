import {expect} from 'chai';
import { checkMetadata } from './spec/check.metadata.spec';
import { apiDropboxResponse } from '../src/dropbox/responses/api.response.type';
import Mocha from 'mocha';

var mocha = new Mocha({
    reporter: 'mocha-junit-reporter',
    reporterOptions: {
        testCaseSwitchClassnameAndName: true,
        toConsole: true
    }
});

describe('Upload file and check metadata',()=>{
    it('should return name "machine_learning.pdf"',async ()=>{
        const result: apiDropboxResponse = await checkMetadata()
        const expected: string = 'machine_learning.pdf';
        expect(result.name).is.equal(expected);
    }).timeout(30000).isPending();
});