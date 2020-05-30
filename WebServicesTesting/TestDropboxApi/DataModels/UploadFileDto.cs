using Newtonsoft.Json;

namespace TestDropboxApi.DataModels // Наследование
{
    public class UploadFileDto : Base
    {
        [JsonProperty("mode")]
        public string Mode { get; set; } = "add";
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; } = true;
        [JsonProperty("mute")]
        public bool Mute { get; set; } = false;
    }
}
