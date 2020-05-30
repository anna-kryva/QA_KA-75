import deleleDropboxObject from './spec/delete.object.spec';
import { expect } from 'chai';
import { apiDropboxResponse } from '../src/dropbox/responses/api.response.type';
import Mocha from 'mocha';

var mocha = new Mocha({
    reporter: 'mocha-junit-reporter',
    reporterOptions: {
        testCaseSwitchClassnameAndName: true,
        toConsole: true
    }
});

const dropboxFileName:string = 'machine_learning.pdf';

describe('Delete file',()=>{
    it('should return metadata',async ()=>{
        const result: apiDropboxResponse = await deleleDropboxObject();
        expect(result.name).is.equal(dropboxFileName);
        console.log('\n\tFile deleted!\n');
        
    }).timeout(15000);
});