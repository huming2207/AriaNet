using Newtonsoft.Json;

namespace AriaNet.Response
{
    public class AriaVersionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("result")]
        public AriaVersionInfo Result { get; set; }
    }
}