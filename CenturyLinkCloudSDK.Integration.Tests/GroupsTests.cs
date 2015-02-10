using CenturyLinkCloudSDK.ServiceModels.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class GroupsTests
    {
        private AuthenticationInfo userAuthentication;

        [TestInitialize]
        public void Login()
        {
            var client = new Client("mario.mamalis", "MarioTest!");
            userAuthentication = client.AuthenticationInfo;
        }

        [TestMethod]
        public async Task GetGroupReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.Groups.GetGroup("ca1-42311");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1-42311");
        }

        [TestMethod]
        public async Task GetGroupByHyperlinkReturnValidData()
        {
            var client = new Client(userAuthentication);
            var result = await client.Groups.GetGroupByHyperLink("/v2/groups/p2o2/ca1-42311");

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(result.Id == "ca1-42311");
        }
    }
}
