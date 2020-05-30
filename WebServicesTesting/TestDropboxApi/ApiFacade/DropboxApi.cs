using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;
using TestDropboxApi.Builders;

namespace TestDropboxApi.ApiFacade
{
    public class DropboxApi
    {
        public RequestBuilder request;
        public DropboxApi()
        {
            request = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }

        public ApiResponse GetFileMetadata(string filePath)
        {
            const string url = "files/get_metadata";
            var path = new Base();
            path.Path = filePath;
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse DeleteFile(string filePath)
        {
            const string url = "files/delete_v2";
            var path = new Base();
            path.Path = filePath;
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }
    }
}
