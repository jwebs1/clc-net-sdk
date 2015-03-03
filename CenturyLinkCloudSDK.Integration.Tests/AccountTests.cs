using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CenturyLinkCloudSDK.ServiceModels;
using System.Threading.Tasks;
using System.Linq;

namespace CenturyLinkCloudSDK.Integration.Tests
{
    [TestClass]
    public class AccountTests
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
        public async Task GetAccountTotalAssets()
        {
            var dataCenters = await client.DataCenters.GetDataCenters().ConfigureAwait(false);
            var dataCenterIds = dataCenters.Select(d => d.Id).Distinct();
            var accountTotals = await client.Account.GetAccountTotalAssets(dataCenterIds).ConfigureAwait(false);

            Assert.IsTrue(accountTotals.Servers > 0);
        }

        [TestMethod]
        public async Task GetRecentActivity()
        {
            var activity = await client.Account.GetRecentActivity().ConfigureAwait(false);
            Assert.IsTrue(activity.ToList().Count > 0);
        }
    }
}
