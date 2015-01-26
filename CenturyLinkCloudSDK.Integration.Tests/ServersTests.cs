using CenturyLinkCloudSDK.ServiceAPI.Runtime;
using CenturyLinkCloudSDK.ServiceAPI.V2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class ServersTests
    {
        [TestInitialize]
        public void Login()
        {
            var authentication = new AuthenticationService();
            var result = authentication.Login("mario.mamalis", "MarioTest!").Result;
        }

        [TestMethod]
        public async Task GetServerReturnValidData()
        {
            var serverContext = new ServerService();
            var result = await serverContext.GetServer(Authentication.UserInfo.AccountAlias, "CA1P2O2DF2TST01");

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.Id));
        }

        [TestMethod]
        public async Task GetServerByHyperlinkReturnValidData()
        {
            var serverContext = new ServerService();
            var result = await serverContext.GetServer("/v2/servers/p2o2/ca1p2o2df2tst01");

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1p2o2df2tst01");
        }

        [TestMethod]
        public async Task PauseServersReturnPauseOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var serverContext = new ServerService();
            var serverOperationResponse = await serverContext.PauseServer(Authentication.UserInfo.AccountAlias, serverIds);

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

            var serverContext = new ServerService();
            var serverOperationResponse = await serverContext.PowerOnServer(Authentication.UserInfo.AccountAlias, serverIds);

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

            var serverContext = new ServerService();
            var serverOperationResponse = await serverContext.PowerOffServer(Authentication.UserInfo.AccountAlias, serverIds);

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

            var serverContext = new ServerService();
            var serverOperationResponse = await serverContext.RebootServer(Authentication.UserInfo.AccountAlias, serverIds);

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

            var serverContext = new ServerService();
            var serverOperationResponse = await serverContext.ShutDownServer(Authentication.UserInfo.AccountAlias, serverIds);

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

            var serverContext = new ServerService();
            var serverOperationResponse = await serverContext.ResetServer(Authentication.UserInfo.AccountAlias, serverIds);

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
