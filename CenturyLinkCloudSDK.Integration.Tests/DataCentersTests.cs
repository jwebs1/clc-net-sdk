using CenturyLinkCloudSDK.ServiceAPI.Runtime;
using CenturyLinkCloudSDK.ServiceAPI.V2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class DataCentersTests
    {
        [TestInitialize]
        public void Login()
        {
            var authentication = new AuthenticationService();
            var result = authentication.Login("mario.mamalis", "MarioTest!").Result;
        }

        [TestMethod]
        public async Task GetDataCentersReturnValidData()
        {
            var dataCenterContext = new DataCenterService();
            var result = await dataCenterContext.GetDataCenters(Authentication.UserInfo.AccountAlias);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetDataCenterByHyperlinkReturnValidData()
        {
            var dataCenterContext = new DataCenterService();
            var result = await dataCenterContext.GetDataCenter("/v2/datacenters/p2o2/ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterReturnValidData()
        {
            var dataCenterContext = new DataCenterService();
            var result = await dataCenterContext.GetDataCenter(Authentication.UserInfo.AccountAlias, "ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterGroupReturnValidData()
        {
            var dataCenterContext = new DataCenterService();
            var result = await dataCenterContext.GetDataCenterGroup(Authentication.UserInfo.AccountAlias, "ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1");
        }

        [TestMethod]
        public async Task GetDataCenterGroupByHyperlinkReturnValidData()
        {
            var dataCenterContext = new DataCenterService();
            var result = await dataCenterContext.GetDataCenterGroup("/v2/datacenters/p2o2/ca1");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1");
        }
    }
}
