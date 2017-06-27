using Newtonsoft.Json;

namespace AriaNet.Request
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
        
        [JsonProperty(PropertyName = "params", NullValueHandling = NullValueHandling.Ignore)]
        public object Parameters { get; set; }
    }
}