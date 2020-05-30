import ApiRequests from "./API/api.request";

(async function () {
    try {
    const request = new ApiRequests();
    const res = await request.uploadFile('file.txt', 'uploads/file.txt', '/');
    console.log(res);
    } catch (error) {
        console.log(error);
    }
})();
