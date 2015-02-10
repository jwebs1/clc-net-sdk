using CenturyLinkCloudSDK.ServiceModels.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class QueueTests
    {
        private AuthenticationInfo userAuthentication;

        [TestInitialize]
        public void Login()
        {
            var client = new Client("mario.mamalis", "MarioTest!");
            userAuthentication = client.AuthenticationInfo;
        }

        [TestMethod]
        public async Task GetQueueStatusReturnValidData()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.Servers.ResetServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if (string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);

                        var status = server.Links.Where(l => l.Rel == "status").FirstOrDefault();

                        if (status != null)
                        {
                            var statusId = status.Id;
                            var queue = await client.Queues.GetStatus(statusId);

                            Assert.IsTrue(!String.IsNullOrEmpty(queue.Status));
                        }
                    }
                }
            }
        }
    }
}
