using CenturyLinkCloudSDK.Runtime;
using CenturyLinkCloudSDK.ServiceModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class DataCentersTests
    {
        private static Client client;
        private static Authentication authentication;
        
        [ClassInitialize]
        public static void Login(TestContext testContext)
        {
            client = new Client("mario.mamalis", "MarioTest!");
            authentication = client.Authentication;
        }

        [TestMethod]
        public async Task GetDataCentersReturnValidData()
        {
            var result = await client.DataCenters.GetDataCenters();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetDataCenterByHyperlinkReturnValidData()
        {
            var result = await client.DataCenters.GetDataCenterByHyperMediaLink("/v2/datacenters/p2o2/ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterReturnValidData()
        {
            var result = await client.DataCenters.GetDataCenter("ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterGroupReturnValidData()
        {
            var result = await client.DataCenters.GetDataCenterGroup("ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1");
        }

        [Ignore]
        [TestMethod]
        public async Task GetDataCenterGroupByHyperlinkReturnValidData()
        {
            ////var client = new Client(userAuthentication);
            //var result = await client.DataCenters.GetDataCenterGroupByHyperMediaLink("/v2/datacenters/p2o2/ca1");

            //Assert.IsNotNull(result);
            //Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            //Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        [ExpectedException(typeof(CenturyLinkCloudServiceException))]
        public async Task GetDataCenterWithBadTokenThrowException()
        {
            var client = new Client(new Authentication() { AccountAlias = "P202", BearerToken = "QEWASDADF" });
            var result = await client.DataCenters.GetDataCenter("ca1");

        }

        [TestMethod]
        public async Task GetDataCenterRootGroupReturnValidData()
        {
            var dataCenterGroup = await client.DataCenters.GetDataCenterGroup("ca1");

            var rootGroup = await dataCenterGroup.GetRootHardwareGroup().ConfigureAwait(false);

            if (rootGroup != null)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(rootGroup.Name));
            }
        }
    }
}
