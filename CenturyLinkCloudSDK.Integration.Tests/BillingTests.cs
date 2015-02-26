using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CenturyLinkCloudSDK.ServiceModels;

namespace CenturyLinkCloudSDK.Integration.Tests
{
    [TestClass]
    public class BillingTests
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
        public async Task GetGroupBillingDetailsReturnValidData()
        {
            var result = await client.Billing.GetGroupBillingDetails("ca1-42311").ConfigureAwait(false);
            Assert.IsTrue(result.Groups.Count > 0);
        }

        [TestMethod]
        public async Task GetAccountBillingDetailsReturnValidData()
        {
            var result = await client.Billing.GetAccountBillingDetails().ConfigureAwait(false);
            Assert.IsTrue(result.Total.MonthlyEstimate > 0);
        }
    }
}
