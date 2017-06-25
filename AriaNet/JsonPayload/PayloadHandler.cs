using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AriaNet.JsonPayload
{
    public class PayloadHandler
    {
        private Uri AriaJsonRpcUri { get; set; }

        private string JsonRpcUserName { get; set; }

        private string JsonRpcPassword { get; set; }
        
        public PayloadHandler(string jsonRpc = "http://localhost:6800/jsonrpc")
        {
            AriaJsonRpcUri = new Uri(jsonRpc);
        }

        public PayloadHandler(string jsonRpcUrl, string jsonRpcUserName, string jsonRpcPassword)
        {
            JsonRpcUserName = jsonRpcUserName;
            JsonRpcPassword = jsonRpcPassword;
            AriaJsonRpcUri = new Uri(jsonRpcUrl);
        }

        public async Task<T> RunPost<T>(string postContent)
        {
            // Declare HTTP client and POST content
            var httpClient = new HttpClient();
            var stringContent = new StringContent(postContent);
            
            // Fire the hole!
            var postResult = await httpClient.PostAsync(AriaJsonRpcUri, stringContent);
            
            // Have a look at the result...
            if (postResult.IsSuccessStatusCode)
            {
                var jsonObject = JsonConvert.DeserializeObject<T>(
                    await postResult.Content.ReadAsStringAsync());
                
                httpClient.Dispose();
                return jsonObject;
            }
            else
            {
                // Return a null value
                httpClient.Dispose();
                return default(T);
            }
        }
        
        
    }
}