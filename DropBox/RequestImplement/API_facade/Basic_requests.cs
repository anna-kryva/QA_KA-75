using System;
using System.Collections.Generic;
using System.Text;
using RequestImplement.Builders;
using RequestImplement.DataModels;
using RequestImplement.Helpers;

namespace RequestImplement.Requests
{
    public abstract class Basic_requests
    {
        protected RequestBuilder request;
        public Basic_requests(string host)
        {
            request = new RequestBuilder(host);
        }
        public abstract ApiResponse Send_request();
    }
    public abstract class Content_request : Basic_requests
    {
        public Content_request() : base(ConfigParams.contentServiceUrl) { }
    }
    public abstract class Servise_request : Basic_requests
    {
        public Servise_request() : base(ConfigParams.serviceUrl) { }

    }
}
