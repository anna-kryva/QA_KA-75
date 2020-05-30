using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace DropBox
{
    public class DropBoxBasic
    {
        // Инкапсуляция
        private string Token { get; }
        
        protected DropBoxBasic(string token)
        {
            Token = token;
        }

        public JObject PostRequest(string url, string json)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = "Bearer " + Token;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            
            JObject result;
            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = JObject.Parse(streamReader.ReadToEnd());
            }
            result.Add("status_code", (int)response.StatusCode);

            return result;
        }
    }
    
    public class DropBoxClass : DropBoxBasic // Наследование
    {
        // Инкапсуляция
        private const string MetadataEndpoint = "https://api.dropboxapi.com/2/files/get_metadata";
        private const string DeleteEndpoint = "https://api.dropboxapi.com/2/files/delete_v2";
        private const string CopyEndpoint = "https://api.dropboxapi.com/2/files/copy_v2";
        
        public DropBoxClass(string token) : base(token)
        {
            
        }
        
        public JObject GetMetadata(string path)
        {
            var json = "{\"path\":" + "\"" + path + "\"}";
            return PostRequest(MetadataEndpoint, json);
        }

        // Полиморфизм (2 следующих метода)
        public JObject CopyFile(string fromPath, string toPath)
        {
            var json = "{" +
                       "\"from_path\":" + "\"" + fromPath + "\"," +
                       "\"to_path\":" + "\"" + toPath + "\"" +
                       "}";
            return PostRequest(CopyEndpoint, json);
        }
        
        public JObject CopyFile(string fromPath)
        {
            var strings = fromPath.Split('.');
            strings[0] += " Copy";
            var toPath = string.Join(".", strings);
            
            var json = "{" +
                       "\"from_path\":" + "\"" + fromPath + "\"," +
                       "\"to_path\":" + "\"" + toPath + "\"" +
                       "}";
            return PostRequest(CopyEndpoint, json);
        }

        public JObject DeleteFile(string path)
        {
            string json = "{\"path\":" + "\"" + path + "\"}";
            return PostRequest(DeleteEndpoint, json);
        }
    }
}