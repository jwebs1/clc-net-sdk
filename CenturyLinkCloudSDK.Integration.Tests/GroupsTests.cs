using CenturyLinkCloudSDK.ServiceModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class GroupsTests
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
        public async Task GetGroupReturnValidData()
        {
            var result = await client.Groups.GetGroup("00e3ce61918fe411877f005056882d41").ConfigureAwait(false);

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "00e3ce61918fe411877f005056882d41");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetGroupServersThrowExceptionWhenNoServers()
        {
            var result = await client.Groups.GetGroup("00e3ce61918fe411877f005056882d41").ConfigureAwait(false);
            var servers = await result.GetServers().ConfigureAwait(false);
            Assert.IsTrue(servers.ToList().Count == 0);
        }

        [TestMethod]
        public async Task GetGroupServersReturnValidData()
        {
            var result = await client.Groups.GetGroup("a726bd9f7d9be411877f005056882d41").ConfigureAwait(false);
            var servers = await result.GetServers().ConfigureAwait(false);
            Assert.IsTrue(servers.ToList().Count > 0);
        }
    }
}
