import * as dotenv from "dotenv";
import * as request from "superagent";
import * as fs from "fs";
import { IDropBoxClient } from "./client.interface";
import { apiDropboxResponse } from "./responses/api.response.type";


export class DropBoxClient implements IDropBoxClient{
    private client: request.SuperAgentStatic;
    private readonly checkAuthUrl: string = 
    "https://api.dropboxapi.com/2/users/get_current_account";

    private readonly uploadFileUrl: string = 
    "https://content.dropboxapi.com/2/files/upload";

    private readonly getMeatdataUrl: string = 
    "https://api.dropboxapi.com/2/files/get_metadata";

    private readonly deleteObjectUrl: string = 
    "https://api.dropboxapi.com/2/files/delete_v2";

    //overloading as polymorphism
    constructor();
    constructor(token?:string){
        dotenv.config();
        const dropboxAuthToken: string = 
        String(token||process.env.DROPBOX_AUTH_TOKEN);
        console.log(dropboxAuthToken);
        
        
        this.client = request.agent()
        .auth(dropboxAuthToken, { type: "bearer" });
    }

    public async isAuth(): Promise<boolean> {
        const response = await this.client
        .post(this.checkAuthUrl);

        if (response.status >= 400){
            throw new Error("\nThis is trouble!\n");
        } 
        return true;
    }

    public async uploadFile(filePath: string, dropboxFilePath: string,fileName: string) 
    : Promise<apiDropboxResponse>{
        const dropboxPath: string = `${dropboxFilePath}/${fileName}`;

        const dropboxSpecHeaders = {
            "path": dropboxPath,
            "mode": "add",
            "autorename": true,
            "mute": false,
            "strict_conflict": false,
        };
        const file = fs.readFileSync(filePath);
        const response = await this.client
        .post(this.uploadFileUrl)
        .set("Dropbox-API-Arg", JSON.stringify(dropboxSpecHeaders))
        .set('Content-Type', "application/octet-stream")
        .send(file);
        
        return { 
            id: response.body.id,
            path_display: response.body.path_display,
            name: response.body.name
        };
    }

    public async getMetadata(dropboxPath:string): Promise<apiDropboxResponse>{
        const dropboxSpecData = {
            "path": dropboxPath,
            "include_media_info": false,
            "include_deleted": false,
            "include_has_explicit_shared_members": false
        };

        const response = await this.client
        .post(this.getMeatdataUrl)
        .set("Content-Type", "application/json")
        .send(dropboxSpecData);
    
        return { 
            id: response.body.id,
            path_display: response.body.path_display,
            name: response.body.name
        };
    }

    public async deleteDropboxObjectByPath(dropboxPath: string): 
    Promise<apiDropboxResponse>{
        const response = await this.client
        .post(this.deleteObjectUrl)
        .set("Content-Type", "application/json")
        .send({ "path": dropboxPath });
        
        return {
            id: response.body.metadata.id,
            path_display: response.body.metadata.path_display,
            name: response.body.metadata.name
        }
    }
    
}