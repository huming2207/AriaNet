using System.Collections.Generic;
using Newtonsoft.Json;

namespace AriaNet.Response
{
    namespace AriaNet.Response
    {
        public class AriaGlobalStatusResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("jsonrpc")]
            public string Jsonrpc { get; set; }

            [JsonProperty("result")]
            public AriaGlobalStatus Result { get; set; }
        }
    }
}