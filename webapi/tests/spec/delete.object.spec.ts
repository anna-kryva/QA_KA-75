import { apiDropboxResponse } from "../../src/dropbox/responses/api.response.type";
import { DropBoxClient } from "../../src/dropbox/client.implementation";

const dropboxFileName: string = 'machine_learning.pdf';

export async function deleteDropboxObject():
Promise<apiDropboxResponse>{
    const client: DropBoxClient = new DropBoxClient();
    return await client.deleteDropboxObjectByPath(`/${dropboxFileName}`);  
}

export default deleteDropboxObject;