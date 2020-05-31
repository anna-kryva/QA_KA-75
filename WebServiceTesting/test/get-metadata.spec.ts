import chai from "chai";
import {ApiRequests} from "../src/api/api.request";

export default function getMetadata(fileName: string, filePath: string) {
  describe("Get file metadata", () => {
    it("expect files have the same name", async () => {
      const request = new ApiRequests();
      const response = await request.getFileMetadata(filePath);
      chai.expect(response.name).to.equal(fileName);
    });
  });
}
