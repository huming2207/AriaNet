using Newtonsoft.Json;

namespace AriaNet.Response
{
    [JsonObject]
    public class AriaSession
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}