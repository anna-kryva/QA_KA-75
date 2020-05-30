import { apiDropboxResponse } from "./responses/api.response.type";

export interface IDropBoxClient{
    
    isAuth(): Promise<boolean>;

    uploadFile(filePath: string, dropboxFilePath: string,fileName: string):
    Promise<apiDropboxResponse>;

    getMetadata(dropboxPath:string): Promise<apiDropboxResponse>;

    deleteDropboxObjectByPath(dropboxPath: string): Promise<apiDropboxResponse>;

}
