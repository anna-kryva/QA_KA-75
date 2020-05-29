import checkAuth from './spec/check.auth.spec';
import { expect } from 'chai';

describe('Check auth token',()=>{
    it('should return true',async ()=>{
        const result = await checkAuth();
        expect(result).is.true;
    }).timeout(15000);
});