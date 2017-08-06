using System;
using AriaNet;
using Xunit;

namespace AriaNetTest
{
    public class StatusTest
    {
        private AriaManager _ariaManager;
        
        public StatusTest()
        {
            _ariaManager = new AriaManager();    
        }
        
        [Fact]
        public void GlobalStatusTest()
        {
            var result = _ariaManager.GetGlobalStatus().Result;
            Assert.NotNull(result);
            Assert.True(result.ActiveTaskCount >= 0);
        }

        [Fact]
        public void SessionTest()
        {
            var result = _ariaManager.GetSessionInfo().Result;
            Assert.NotNull(result);
            Assert.True(result.SessionId.Length > 0);
        }
    }
}