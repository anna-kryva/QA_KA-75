import * as dotenv from "dotenv";
import * as request from "superagent";
import { IDropBoxClient } from "./client.interface";
import { env } from 'process';
import { shortDropboxResponse } from "../api.response.type";
import { readFile } from "fs/promises";

export class DropBoxClient implements IDropBoxClient{
    private client: request.SuperAgentStatic;
    private readonly checkAuthUrl: string = "https://api.dropboxapi.com/2/users/get_current_account";
    private readonly uploadFileUrl: string = "https://content.dropboxapi.com/2/files/upload";

    constructor(){
        dotenv.config();
        const dropboxAuthToken: string = String(env.DROPBOX_AUTH_TOKEN);
        
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

    public async uploadFile(fileName: string, filePath: string) 
    : Promise<shortDropboxResponse>{
        const dropboxSpecHeaders = {
            "path": fileName,
            "mode": "add",
            "autorename": true,
            "mute": false,
            "strict_conflict": false,
        };
        const file = await readFile(filePath);
        const response = await this.client
        .post(this.uploadFileUrl)
        .set("Content-Type","application/octet-stream")
        .set("Dropbox-API-Agr",String(dropboxSpecHeaders))
        .send(file);
        
        return { id:response.body.id };
    }
}