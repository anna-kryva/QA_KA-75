import ApiRequests from "./api/api.request";

(async function () {
    try {
    const request = new ApiRequests();
    const uploadResult = await request.uploadFile('file.txt', 'uploads/file.txt', '');
    const getMetadataResult = await request.getFileMetadata('/file.txt');
    const deleteMetadataResult = await request.deleteFile('/file.txt');

    console.log('-------Upload------');
    console.log(uploadResult);
    console.log('\n-------Get Metadata------');
    console.log(getMetadataResult);
    console.log('\n-------Delete------');
    console.log(deleteMetadataResult);
    } catch (error) {
        console.log(error);
    }
})();
