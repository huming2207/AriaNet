using Newtonsoft.Json;

namespace AriaNet.Response
{
    [JsonObject]
    public class AriaSessionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("result")]
        public AriaSession Result { get; set; }
    }
}