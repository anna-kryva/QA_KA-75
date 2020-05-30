import uploadFile from "./upload.spec";
import getMetadata from "./get-metadata.spec";
import deleteFile from "./delete.spec";

describe('Dropbox API', () => {
    uploadFile('file.txt', 'uploads/file.txt', '');
    getMetadata('file.txt', '/file.txt');
    deleteFile('file.txt', '/file.txt');
});