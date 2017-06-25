using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AriaNet.Response
{
    public class AriaUri
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
