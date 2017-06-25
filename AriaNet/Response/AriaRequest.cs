using Newtonsoft.Json;

namespace AriaNet.Response
{
    [JsonObject]
    public class AriaRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("jsonrpc")]
        public string JsonRpcVersion { get; set; }
        
        [JsonProperty("method")]
        public string Method { get; set; }
        
        [JsonProperty("params")]
        public object Parameters { get; set; }
    }
}