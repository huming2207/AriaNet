using System;
using System.Threading.Tasks;
using AriaNet.Response;

namespace AriaNet.Aria
{
    public class DownloadManager
    {
        private Uri AriaJsonRpcUri { get; set; }

        private string userName { get; set; }

        private string password { get; set; }
        
        public DownloadManager(string jsonRpc = "http://localhost:6800/jsonrpc")
        {
            AriaJsonRpcUri = new Uri(jsonRpc);
        }

        public DownloadManager(string jsonRpc, string userName, string password)
        {

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
    }
}