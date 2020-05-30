using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDropboxApi.Helpers
{
    public class ConfigurationHelper
    {
        public static string ServiceUrl => ConfigurationManager.AppSettings["serviceUrl"];
        public static string ContentServiceUrl => ConfigurationManager.AppSettings["contentServiceUrl"];
        public static string AuthorizationToken()
        {
            var fPart = "sl.AbB25EfsdMwiDUAC0a0Wm5ZSNEVzf_";
            var sPart = "y8lEFnWx_mdi7vgthX_4GrBETGS08Kaz - qoNN - ";
            var tPart = "_nqM14wcLPcftNpwOLqETzAnViWi6XjSi_ - ";
            var lPart = "MOMoOLvi31nFChjUtpaAUYd7YNmG3PTmN";
            return fPart + sPart + tPart + lPart;
        }
        public static string DefaultFilePath => ConfigurationManager.AppSettings["defaultFilePath"];

    }
}
