using CenturyLinkCloudSDK.Services.Runtime;
using CenturyLinkCloudSDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using CenturyLinkCloudSDK.ServiceModels.Common;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class DataCentersTests
    {
        private AuthenticationInfo userAuthentication;

        [TestInitialize]
        public void Login()
        {
            var client = new Client("mario.mamalis", "MarioTest!");
            userAuthentication = client.AuthenticationInfo;
        }

        [TestMethod]
        public async Task GetDataCentersReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.DataCenters.GetDataCenters();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetDataCenterByHyperlinkReturnValidData()
        {

            var client = new Client(userAuthentication);
            var result = await client.DataCenters.GetDataCenterByHyperMediaLink("/v2/datacenters/p2o2/ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.DataCenters.GetDataCenter("ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterGroupReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.DataCenters.GetDataCenterGroup("ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterGroupByHyperlinkReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.DataCenters.GetDataCenterGroupByHyperMediaLink("/v2/datacenters/p2o2/ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1");
        }
    }
}
