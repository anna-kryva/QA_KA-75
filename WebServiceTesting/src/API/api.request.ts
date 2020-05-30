import fs from "fs";
import DropboxRequest from "./dropbox.request";
import IResponse from "./interfaces";

class ApiRequests extends DropboxRequest {
  private readonly uploadRequestURL =
    "https://content.dropboxapi.com/2/files/upload";
  private readonly getMetadataRequestURL =
    "https://api.dropboxapi.com/2/files/get_metadata";
  private readonly deleteRequestURL =
    "https://api.dropboxapi.com/2/files/delete_v2";

  constructor() {
    super();
  }

  public async uploadFile(
    fileName: string,
    filePath: string,
    dropboxPath: string
  ): Promise<IResponse> {
    // const filePathArray = filePath.split("/");
    // const fileName = filePathArray[filePathArray.length - 1];

    const parameters = {
      path: `${dropboxPath}/${fileName}`,
      mode: "add",
      autorename: true,
      mute: false,
      strict_conflict: false,
    };

    const file = fs.readFileSync(filePath);

    const originResponse = await this.request
      .post(this.uploadRequestURL)
      .set("Content-Type", "application/octet-stream")
      .set("Dropbox-API-Arg", JSON.stringify(parameters))
      .send(file);

    return this.getResponse(originResponse.body);
  }

  public async deleteFile(dropboxPath: string): Promise<IResponse> {
    const parameters = {
      path: dropboxPath,
    };

    const originResponse = await this.request
      .post(this.deleteRequestURL)
      .set("Content-Type", "application/json")
      .send(parameters);

    return this.getResponse(originResponse.body.metadata);
  }

  public async getFileMetadata(dropboxPath: string): Promise<IResponse> {
    const parameters = {
      path: dropboxPath,
      include_media_info: false,
      include_deleted: false,
      include_has_explicit_shared_members: false,
    };

    const originResponse = await this.request
      .post(this.getMetadataRequestURL)
      .set("Content-Type", "application/json")
      .send(parameters);

    return this.getResponse(originResponse.body);
  }
}

export default ApiRequests;
