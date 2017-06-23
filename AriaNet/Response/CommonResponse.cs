using Newtonsoft.Json;

namespace AriaNet.Response
{
    [JsonObject]
    public class CommonResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("jsonrpc")]
        public string JsonRpcVersion { get; set; }
        
        [JsonProperty("result")]
        public string TaskId { get; set; }
    }
}