using CenturyLinkCloudSDK.ServiceModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

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
            var alertPolicies = await client.Alerts.GetAlertPolicies().ConfigureAwait(false);
            Assert.IsTrue(alertPolicies.Items.ToList().Count > 0);
        }

        [TestMethod]
        public async Task GetServerAlerts()
        {
            var alerts = await client.Alerts.GetServerAlerts().ConfigureAwait(false);
            Assert.IsTrue(alerts.ToList().Count > 0);
        }
    }
}
