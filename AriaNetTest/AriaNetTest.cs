using System;
using System.Threading.Tasks;
using Xunit;
using AriaNet.Aria;
using AriaNet.Response;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace AriaNetTest
{
    public class AriaNetTest
    {
        private DownloadManager _downloadManager;
        
        public AriaNetTest()
        {
            _downloadManager = new DownloadManager();
        }
        
        [Fact]
        public async Task GetInfo()
        {
            var result = await _downloadManager.QueryGlobalStatus();
            Assert.NotNull(result);
        }
        
        
    }
}