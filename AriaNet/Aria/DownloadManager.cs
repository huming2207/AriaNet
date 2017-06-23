using System;
using System.Threading.Tasks;
using AriaNet.Response;

namespace AriaNet.Aria
{
    public class DownloadManager
    {
        private Uri AriaJsonRpcUri { get; set; }
        
        public DownloadManager(string jsonRpc = "http://localhost:6800/jsonrpc")
        {
            AriaJsonRpcUri = new Uri(jsonRpc);
        }

        public async Task<CommonResponse> AddUri(string uri)
        {
            
        }
    }
}