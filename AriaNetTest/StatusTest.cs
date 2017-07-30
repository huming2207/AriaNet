using System;
using AriaNet;
using Xunit;

namespace AriaNetTest
{
    public class StatusTest
    {
        private DownloadManager _downloadManager;
        
        public StatusTest()
        {
            _downloadManager = new DownloadManager();    
        }
        
        [Fact]
        public void GlobalStatusTest()
        {
            var result = _downloadManager.GetGlobalStatus().Result;
            Assert.NotNull(result);
            Assert.True(result.ActiveTaskCount >= 0);
        }

        [Fact]
        public void SessionTest()
        {
            var result = _downloadManager.GetSessionInfo().Result;
            Assert.NotNull(result);
            Assert.True(result.SessionId.Length > 0);
        }
    }
}