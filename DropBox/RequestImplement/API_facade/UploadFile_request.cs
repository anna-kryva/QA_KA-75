using Newtonsoft.Json;
using RequestImplement.API_facade;
using RequestImplement.Builders;
using RequestImplement.DataModels;
using RequestImplement.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestDropboxApi.DataModels;

namespace RequestImplement.Requests
{
    public class UploadFile_request:Content_request
    {
        UploadFileDto uploadDto;
        byte[] file;
        public UploadFile_request(UploadFileDto uploadDto, byte[] file)
        {
            this.uploadDto = uploadDto;
            this.file = file;
        }
        public override ApiResponse Send_request()
        {
            var url = "files/upload";
            var requestBody = JsonConvert.SerializeObject(uploadDto);
            return request.Uri(url).Method(HttpMethod.Post)
                .WithHeader("Dropbox-API-Arg", requestBody)
                .WithFile(file)
                .Execute();
        }
    }
}
