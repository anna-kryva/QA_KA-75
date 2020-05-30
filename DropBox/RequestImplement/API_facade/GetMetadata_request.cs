using Newtonsoft.Json;
using RequestImplement.Builders;
using RequestImplement.DataModels;
using RequestImplement.Helpers;
using RequestImplement.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestDropboxApi.DataModels;

namespace RequestImplement.API_facade
{
    public class GetMetadata_request:Servise_request
    {
        Base get_params;
        public GetMetadata_request(Base get_params) { this.get_params = get_params; }
        
        public override ApiResponse Send_request()
        {
            var url = "files/get_metadata";
            var request_body = JsonConvert.SerializeObject(get_params);
            return request.Uri(url).Method(HttpMethod.Post).WithBody(request_body).Execute();
        }
    }
}
