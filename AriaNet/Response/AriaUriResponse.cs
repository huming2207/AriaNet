using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AriaNet.Response
{
    public class AriaUriResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("result")]
        public List<AriaUri> Result { get; set; }
    }
}
