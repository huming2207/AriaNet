using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AriaNet.Response
{
    public class AriaStatusResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("result")]
        public AriaStatus Result { get; set; }
    }
}
