using CenturyLinkCloudSDK.ServiceModels.Common;
using CenturyLinkCloudSDK.Services;
using CenturyLinkCloudSDK.Services.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        [TestMethod]
        public void LoginReturnTokenWhenValid()
        {
            var client = new Client("mario.mamalis", "MarioTest!");

            Assert.IsNotNull(client.UserInfo);
            Assert.IsTrue(!String.IsNullOrEmpty(client.UserInfo.BearerToken));
            Assert.IsTrue(!String.IsNullOrEmpty(client.UserInfo.AccountAlias));
        }

        [Ignore]
        [TestMethod]
        [ExpectedException(typeof(CenturyLinkCloudServiceException))]
        public void LoginUserNotAuthenticatedWhenInvalid()
        {
            var client = new Client("mario.mamalisss", "MarioTest!");


            //Assert.IsFalse(client.UserIsAuthenticated);
            //Assert.IsNull(client.UserInfo);
            //Assert.IsNull(client.AuthenticationInfo);
        }
    }

}
