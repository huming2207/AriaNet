using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AriaNet.Response
{
    public class AriaTorrentResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("result")]
        public List<AriaTorrent> Result { get; set; }
    }
}
