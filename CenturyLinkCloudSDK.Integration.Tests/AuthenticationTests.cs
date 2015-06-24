using CenturyLinkCloudSDK.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CenturyLinkCloudSDK.Unit.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        [TestMethod]
        public void LoginReturnTokenWhenValid()
        {
            var client = new Client("mario.mamalis", "MarioTest!");

            Assert.IsNotNull(client.Authentication);
            Assert.IsTrue(client.UserIsAuthenticated);
            Assert.IsTrue(!String.IsNullOrEmpty(client.Authentication.BearerToken));
            Assert.IsTrue(!String.IsNullOrEmpty(client.Authentication.AccountAlias));
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void LoginUserNotAuthenticatedWhenInvalid()
        {
            var client = new Client("mario.mamalisss", "MarioTest!");
        }
    }

}
