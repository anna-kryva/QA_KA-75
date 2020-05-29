import {compareVersions} from "./compare-versions";

describe("compareVersions func should work as expected", ()=>{

    test("should return -1", ()=>{
        expect(compareVersions("1.2.3", "4.5.6" )).toBe(-1)
    })
    test("should return 0",()=>{
        expect(compareVersions("1", "1.0" )).toBe(0)
    })
    test("should return 1", ()=>{
        expect(compareVersions("1.1.0", "1.0.1" )).toBe(1)
    })

})
