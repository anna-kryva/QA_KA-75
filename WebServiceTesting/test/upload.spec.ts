import {expect} from "chai";
import {ApiRequests} from "../src/api/api.request";

export default function uploadFile (
  fileName: string,
  filePath: string,
  dropboxPath: string
) {
  describe("Upload file", () => {
    it("expect files have the same name", async () => {
      const request = new ApiRequests();
      const response = await request.uploadFile(
        fileName,
        filePath,
        dropboxPath
      );
      expect(response.name).to.equal(fileName);
    });
  });
}
