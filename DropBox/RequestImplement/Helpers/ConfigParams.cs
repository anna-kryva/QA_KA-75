using System;
using System.Collections.Generic;
using System.Text;

namespace RequestImplement.DataModels
{
    public class ConfigParams
    {
        public static string serviceUrl { get; set; }
        public static string contentServiceUrl { get; set; }
        public static string defaultFilePath { get; set; }
        public static string token { get; set; }
        static ConfigParams()
        {
            serviceUrl = "https://api.dropboxapi.com/2";
            contentServiceUrl = "https://content.dropboxapi.com/2";
            defaultFilePath = "../../../TestData";
            token = Environment.GetEnvironmentVariable("token");
        }
    }
}
