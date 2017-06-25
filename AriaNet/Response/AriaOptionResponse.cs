using Newtonsoft.Json;

namespace AriaNet.Response
{
    [JsonObject]
    public class AriaOptionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("result")]
        public AriaOption Result { get; set; }
    }
}