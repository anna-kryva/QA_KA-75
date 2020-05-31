import chai from "chai";
// import {ApiRequests} from "../src/api/api.request";
const {ApiRequests} = require('../src/api/api.request');

export default function deleteFile(fileName: string, filePath: string) {
  describe("Delete file", () => {
    it("expect files have the same name", async () => {
      const request = new ApiRequests();
      const response = await request.deleteFile(filePath);
      chai.expect(response.name).to.equal(fileName);
    });
  });
}
