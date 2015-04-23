﻿using CenturyLinkCloudSDK.ServiceModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class ServersTests
    {
        private static Client client;
        private static Authentication userAuthentication;

        [ClassInitialize]
        public static void Login(TestContext testContext)
        {
            client = new Client("mario.mamalis", "MarioTest!");
            userAuthentication = client.Authentication;
        }

        [TestMethod]
        public async Task GetServerReturnValidData()
        {
            var result = await client.Servers.GetServer("ca1p2o2server01");

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.Id));
        }

        [TestMethod]
        public async Task PauseServersReturnPauseOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var serverOperationResponse = await client.Servers.PauseServer(serverIds);

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

            var serverOperationResponse = await client.Servers.PowerOnServer(serverIds);

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

            var serverOperationResponse = await client.Servers.PowerOffServer(serverIds);

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

            var serverOperationResponse = await client.Servers.RebootServer(serverIds);

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

            var serverOperationResponse = await client.Servers.ShutDownServer(serverIds);

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

            var serverOperationResponse = await client.Servers.ResetServer(serverIds);

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
        public async Task StartMaintenanceReturnOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var serverOperationResponse = await client.Servers.StartMaintenance(serverIds);

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
        public async Task StopMaintenanceReturnOperationIsQueuedIfValidState()
        {
            var serverIds = new List<string>() { "CA1P2O2DF2TST01", "CA1P2O2TEST01" };

            var serverOperationResponse = await client.Servers.StopMaintenance(serverIds);

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
        public async Task GetServerCredentialsReturnValidData()
        {
            var result = await client.Servers.GetServerCredentials("CA1P2O2DF2TST01");

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.UserName));
            Assert.IsTrue(!String.IsNullOrEmpty(result.Password));
        }

        [TestMethod]
        public async Task GetServerStatisticsReturnValidData()
        {
            var result = await client.Servers.GetServerStatistics("CA1P2O2DF2TST01");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetServerRecentActivityReturnValidData()
        {
            var referenceIds = new List<string>();
            referenceIds.Add("CA1P2O2SERVER01");

            var result = await client.Servers.GetRecentActivity(referenceIds);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetPublicIpAddress()
        {
            var result = await client.Servers.GetPublicIpAddress("ca1p2o2df2tst01", "65.39.180.64");
            Assert.IsNotNull(result);           
        }

        [TestMethod]
        public async Task SetCpuAndMemory()
        {
            var operations = new List<CpuMemoryPatchOperation>();
            
            var patchCpuOperation = new CpuMemoryPatchOperation()
            {
                Op = "set",
                Member = "cpu",
                Value = 1
            };

            var patchMemoryOperation = new CpuMemoryPatchOperation()
            {
                Op = "set",
                Member = "memory",
                Value = 2
            };

            operations.Add(patchCpuOperation);
            operations.Add(patchMemoryOperation);

            var result = await client.Servers.SetCpuAndMemory("ca1p2o2df2tst01", operations);

            Assert.IsNotNull(result);
        }
    }
}
