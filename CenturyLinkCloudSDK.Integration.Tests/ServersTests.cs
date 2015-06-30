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
        public async Task GetServerCredentialsReturnValidData()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var result = await server.GetCredentials();

            Assert.IsNotNull(result);
            Assert.IsTrue(!String.IsNullOrEmpty(result.UserName));
            Assert.IsTrue(!String.IsNullOrEmpty(result.Password));
        }

        [TestMethod]
        public async Task GetServerStatisticsReturnValidData()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var result = await server.GetStatistics();

            Assert.IsNotNull(result);
        }
        
        [Ignore]
        [TestMethod]
        public async Task PauseServersReturnOperationIsQueuedIfValidState()
        {            
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.Pause();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task PowerOnServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.PowerOn();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task PowerOffServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.PowerOff();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task RebootServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.Reboot();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task ResetServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.Reset();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task ShutDownServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.ShutDown();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task StartMaintenanceServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.StartMaintenance();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        [Ignore]
        [TestMethod]
        public async Task StopMaintenaceServersReturnOperationIsQueuedIfValidState()
        {
            var server = await client.Servers.GetServer("CA1P2O2DF2TST01");
            var response = await server.StopMaintenance();

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                Assert.IsTrue(response.IsQueued);
            }
        }

        /*
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
         */
    }
}
