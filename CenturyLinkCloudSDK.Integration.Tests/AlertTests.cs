using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CenturyLinkCloudSDK.ServiceModels;
using System.Threading.Tasks;
using System.Linq;

namespace CenturyLinkCloudSDK.Integration.Tests
{
    [TestClass]
    public class AlertTests
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
        public async Task GetAlertPoliciesForAccountReturnValidData()
        {
            var alertPolicies = await client.Alerts.GetAlertPoliciesForAccount().ConfigureAwait(false);
            Assert.IsTrue(alertPolicies.Items.ToList().Count > 0);
        }
    }
}
