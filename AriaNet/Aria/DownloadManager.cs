using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AriaNet.JsonPayload;
using AriaNet.Response;
using AriaNet.Request;
using AriaNet.Response.AriaNet.Response;
using Newtonsoft.Json;

namespace AriaNet.Aria
{
    // For more details please refer to: 
    //     https://aria2.github.io/manual/en/html/aria2c.html#rpc-interface
    // 
    // Since "gid" in Aria2 may be confused with GUID, so in this project I call them as "Task ID".
    public class DownloadManager
    {
        private string AriaJsonRpcUri { get; set; }

        private string JsonRpcUserName { get; set; }

        private string JsonRpcPassword { get; set; }
        
        public DownloadManager(string jsonRpc = "http://localhost:6800/jsonrpc")
        {
            AriaJsonRpcUri = jsonRpc;
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

        private async Task<T> SendCommand<T>(string ariaMethod, object parameterList)
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

        private async Task<T> SendCommand<T> (string ariaMethod)
        {
            // Declare payload handler
            var payloadHandler = new PayloadHandler(AriaJsonRpcUri);

            // Generate JSON-RPC request
            var ariaRequestObject = new AriaRequest()
            {
                Id = Guid.NewGuid().ToString(),
                JsonRpcVersion = "2.0",
                Method = ariaMethod,
                Parameters = null
            };


            var ariaRequestString = JsonConvert.SerializeObject(ariaRequestObject);

            // Send to server (aria2 daemon)
            var queryResult = await payloadHandler.RunPost<T>(ariaRequestString);

            return queryResult;
        }
        
        public async Task<AriaCommonResponse> AddUri(string uri)
        {
            var result = await SendCommand<AriaCommonResponse>("aria2.addUri", uri);
            return result;
        }

        public async Task<AriaCommonResponse> AddTorrent(string torrentPath)
        {
            var torrentBase64 = Convert.ToBase64String(File.ReadAllBytes(torrentPath));
            var result = await SendCommand<AriaCommonResponse>("aria2.addTorrent", torrentBase64);
            return result;
        }

        public async Task<AriaCommonResponse> AddMetalink(string metalinkPath)
        {
            var metalinkBase64 = Convert.ToBase64String(File.ReadAllBytes(metalinkPath));
            var result = await SendCommand<AriaCommonResponse>("aria2.addMetalink", metalinkBase64);
            return result;
        }

        public async Task<AriaCommonResponse> RemoveTask(string taskId, bool forceRemove = false)
        {
            if (forceRemove)
            {
                var result = await SendCommand<AriaCommonResponse>("aria2.forceRemove", taskId);
                return result;
            }
            else
            {
                var result = await SendCommand<AriaCommonResponse>("aria2.remove", taskId);
                return result;
            }
        }

        public async Task<AriaCommonResponse> Pause(string taskId, bool forcePause = false)
        {
            if (forcePause)
            {
                var result = await SendCommand<AriaCommonResponse>("aria2.forcePause", taskId);
                return result;
            }
            else
            {
                var result = await SendCommand<AriaCommonResponse>("aria2.pause", taskId);
                return result;
            }
        }

        public async Task<bool> PauseAll(bool forcePauseAll = false)
        {
            if (forcePauseAll)
            {
                var result = await SendCommand<string>("aria2.forcePauseAll");
                return result.Contains("OK");
            }
            else
            {
                var result = await SendCommand<string>("aria2.pauseAll");
                return result.Contains("OK");
            }
        }

        public async Task<AriaCommonResponse> Unpause(string taskId)
        {
            var result = await SendCommand<AriaCommonResponse>("aria2.unpause", taskId);
            return result;
        }

        public async Task<bool> UnpauseAll()
        {
            var result = await SendCommand<string>("aria2.unpauseAll");
            return result.Contains("OK");
        }

        public async Task<AriaStatusResponse> QueryTask(string taskId)
        {
            var result = await SendCommand<AriaStatusResponse>("aria2.tellStatus", taskId);
            return result;
        }

        public async Task<AriaStatusResponse> QueryActiveTasks()
        {
            var result = await SendCommand<AriaStatusResponse>("aria2.tellActive");
            return result;
        }

        public async Task<AriaStatusResponse> QueryStoppedTasks()
        {
            var result = await SendCommand<AriaStatusResponse>("aria2.tellStopped");
            return result;
        }

        public async Task<AriaUriResponse> QueryUri(string taskId)
        {
            var result = await SendCommand<AriaUriResponse>("aria2.getUri", taskId);
            return result;
        }

        public async Task<AriaFilesResponse> QueryFile(string taskId)
        {
            var result = await SendCommand<AriaFilesResponse>("aria2.getFiles", taskId);
            return result;
        }

        public async Task<AriaTorrentResponse> QueryTorrent(string taskId)
        {
            var result = await SendCommand<AriaTorrentResponse>("aria2.getPeers", taskId);
            return result;
        }

        public async Task<AriaServerResponse> QueryServer(string taskId)
        {
            var result = await SendCommand<AriaServerResponse>("aria2.getServers", taskId);
            return result;
        }

        public async Task<AriaOptionResponse> QueryOption(string taskId)
        {
            var result = await SendCommand<AriaOptionResponse>("aria2.getOption", taskId);
            return result;
        }

        public async Task<bool> ChangeOption(string taskId, AriaOption ariaOption)
        {
            // Not sure if it works lol...
            var parameterList = new List<object> {taskId, ariaOption};
            var result = await SendCommand<string>("aria2.changeOption", parameterList);
            return result.Contains("OK");
        }
        
        public async Task<AriaOptionResponse> QueryGlobalOption()
        {
            var result = await SendCommand<AriaOptionResponse>("aria2.getGlobalOption");
            return result;
        }

        public async Task<bool> ChangeGlobalOption(AriaOption ariaOption)
        {
            // Not sure if it works lol...
            var result = await SendCommand<string>("aria2.changeGlobalOption", ariaOption);
            return result.Contains("OK");
        }

        public async Task<AriaGlobalStatusResponse> QueryGlobalStatus()
        {
            var result = await SendCommand<AriaGlobalStatusResponse>("aria2.getGlobalStat");
            return result;
        }

        public async Task<bool> PurgeDownloadResult()
        {
            var result = await SendCommand<string>("aria2.purgeDownloadResult");
            return result.Contains("OK");
        }
        
        public async Task<bool> RemoveDownloadResult(string taskId)
        {
            var result = await SendCommand<string>("aria2.removeDownloadResult", taskId);
            return result.Contains("OK");
        }
        

        public async Task<AriaVersionResponse> QueryAriaVersion()
        {
            var result = await SendCommand<AriaVersionResponse>("aria2.getVersion");
            return result;
        }
            
        
        public async Task<AriaSessionResponse> QuerySessionInfo()
        {
            var result = await SendCommand<AriaSessionResponse>("aria2.getSessionInfo");
            return result;
        }

        public async Task<bool> Shutdown(bool forceShutdown = false)
        {
            if (forceShutdown)
            {
                var result = await SendCommand<string>("aria2.forceShutdown");
                return result.Contains("OK");
            }
            else
            {
                var result = await SendCommand<string>("aria2.shutdown");
                return result.Contains("OK");
            }
        }

        public async Task<bool> SaveSession()
        {
            var result = await SendCommand<string>("aria2.saveSession");
            return result.Contains("OK");
        }
        
    }
}