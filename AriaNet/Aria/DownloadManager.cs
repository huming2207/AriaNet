using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AriaNet.JsonPayload;
using AriaNet.Response;
using Newtonsoft.Json;

namespace AriaNet.Aria
{
    public class DownloadManager
    {
        private string AriaJsonRpcUri { get; set; }

        private string JsonRpcUserName { get; set; }

        private string JsonRpcPassword { get; set; }
        
        public DownloadManager(string jsonRpc = "http://localhost:6800/jsonrpc")
        {
            AriaJsonRpcUri = new Uri(jsonRpc);
        }

        public DownloadManager(string jsonRpcUrl, string jsonRpcUserName, string jsonRpcPassword)
        {
            JsonRpcUserName = jsonRpcUserName;
            JsonRpcPassword = jsonRpcPassword;
            AriaJsonRpcUri = jsonRpcUrl;
        }

        private async Task<T> SendCommand<T>(string ariaMethod, string parameterString)
        {
            // Declare payload handler
            var payloadHandler = new PayloadHandler(AriaJsonRpcUri);

            // Generate JSON-RPC request
            var ariaRequestObject = new AriaRequest()
            {
                Id = Guid.NewGuid().ToString(),
                JsonRpcVersion = "2.0",
                Method = ariaMethod,
                Parameters = parameterString
            };

            
            var ariaRequestString = JsonConvert.SerializeObject(ariaRequestObject);
            
            // Send to server (aria2 daemon)
            var queryResult = await payloadHandler.RunPost<T>(ariaRequestString);

            return queryResult;
        }

        private async Task<T> SendCommand<T>(string ariaMethod, List<object> parameterList)
        {
            // Declare payload handler
            var payloadHandler = new PayloadHandler(AriaJsonRpcUri);

            // Generate JSON-RPC request
            var ariaRequestObject = new AriaRequest()
            {
                Id = Guid.NewGuid().ToString(),
                JsonRpcVersion = "2.0",
                Method = ariaMethod,
                Parameters = parameterList
            };

            
            var ariaRequestString = JsonConvert.SerializeObject(ariaRequestObject);
            
            // Send to server (aria2 daemon)
            var queryResult = await payloadHandler.RunPost<T>(ariaRequestString);

            return queryResult;
        }
        
        public async Task<AriaCommonResponse> AddUri(string uri)
        {

        }

        public async Task<AriaCommonResponse> AddTorrent(string torrentPath)
        {

        }

        public async Task<AriaCommonResponse> AddMetalink(string metaLink)
        {

        }

        public async Task<AriaCommonResponse> RemoveTask(string taskId, bool forceRemove = false)
        {

        }

        public async Task<AriaCommonResponse> Pause(string taskId, bool forcePause = false)
        {

        }

        public async Task<bool> PauseAll(bool forcePauseAll = false)
        {

        }

        public async Task<AriaCommonResponse> Unpause(string taskId)
        {

        }

        public async Task<bool> UnpauseAll()
        {

        }

        public async Task<AriaStatusResponse> QueryTask(string taskId)
        {

        }

        public async Task<AriaStatusResponse> QueryAllTasks()
        {

        }

        public async Task<AriaStatusResponse> QueryActiveTasks()
        {

        }

        public async Task<AriaStatusResponse> QueryStoppedTasks()
        {

        }

        public async Task<AriaUriResponse> QueryUri(string taskId)
        {
            
        }

        public async Task<AriaFilesResponse> QueryFile(string taskId)
        {

        }

        public async Task<AriaTorrentResponse> QueryTorrent(string taskId)
        {

        }

        public async Task<AriaServerResponse> QueryServer(string taskId)
        {

        }

        public async Task<AriaOptionResponse> QueryOption(string taskId)
        {
            
        }

        public async Task<AriaSessionResponse> QuerySessionInfo()
        {
            
        }

        public async Task<bool> Shutdown(bool forceShutdown = false)
        {
            
        }

        public async Task<bool> SaveSession()
        {
            
        }
        
    }
}