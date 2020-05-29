import { apiDropboxResponse } from "../../src/dropbox/responses/api.response.type";
import { DropBoxClient } from "../../src/dropbox/client.implementation";

const localRelativeFilePath: string = '/ml.pdf';
const dropboxFilePath: string = '';
const dropboxFileName: string = 'machine_learning.pdf';

export async function checkMetadata():
Promise<apiDropboxResponse>{
    const client: DropBoxClient = new DropBoxClient();
    const apiResponse: apiDropboxResponse = 
    await client.uploadFile(
        __dirname + localRelativeFilePath, 
        dropboxFilePath,
        dropboxFileName
        );
        
    console.log('\n\tFile uploaded succesfully!\n');
    
    return await client.getMetadata(apiResponse.path_display);
}