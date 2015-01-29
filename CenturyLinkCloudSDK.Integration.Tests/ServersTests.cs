using CenturyLinkCloudSDK.Services.Runtime;
using CenturyLinkCloudSDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CenturyLinkCloudSDK.ServiceModels.Common;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class ServersTests
    {
        private AuthenticationInfo userAuthentication;

        [TestInitialize]
        public void Login()
        {
            var client = new Client("mario.mamalis", "MarioTest!");
            userAuthentication = client.AuthenticationInfo;
        }

        [TestMethod]
        public async Task GetServerReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.ServerService.GetServer("CA1P2O2DF2TST01");

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.Id));
        }

        [TestMethod]
        public async Task GetServerByHyperlinkReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.ServerService.GetServerByHypermediaLink("/v2/servers/p2o2/ca1p2o2df2tst01");

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1p2o2df2tst01");
        }

        [TestMethod]
        public async Task PauseServersReturnPauseOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.ServerService.PauseServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if (string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);
                    }
                }
            }
        }

        [TestMethod]
        public async Task PowerOnServersReturnPowerOnOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.ServerService.PowerOnServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if(string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);
                    }
                }
            }
        }

        [TestMethod]
        public async Task PowerOffServersReturnPowerOffOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.ServerService.PowerOffServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if (string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);
                    }
                }
            }
        }


        [TestMethod]
        public async Task RebootServersReturnRebootOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.ServerService.RebootServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if (string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);
                    }
                }
            }
        }

        [TestMethod]
        public async Task ShutDownServersReturnShutDownOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.ServerService.ShutDownServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if (string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);
                    }
                }
            }
        }

        [TestMethod]
        public async Task ResetServersReturnResetOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var client = new Client(userAuthentication);
            var serverOperationResponse = await client.ServerService.ResetServer(serverIds);

            if (serverOperationResponse != null)
            {
                foreach (var server in serverOperationResponse)
                {
                    if (string.IsNullOrEmpty(server.ErrorMessage))
                    {
                        Assert.IsTrue(server.IsQueued);
                    }
                }
            }
        }

    }
}
