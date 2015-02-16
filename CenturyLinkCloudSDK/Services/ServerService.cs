﻿using CenturyLinkCloudSDK.Runtime;
using CenturyLinkCloudSDK.ServiceModels;
using CenturyLinkCloudSDK.ServiceModels.Responses.Servers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Services
{
    /// <summary>
    /// This class contains operations associated with servers.
    /// </summary>
    public class ServerService : ServiceBase
    {
        internal ServerService(Authentication authentication)
            : base(authentication)
        {

        }

        /// <summary>
        /// Gets the details for a individual server.
        /// Use this operation when you want to find out all the details for a server. 
        /// It can be used to look for changes, its status, or to retrieve links to associated resources.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public async Task<Server> GetServer(string serverId)
        {
            return await GetServer(serverId, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details for a individual server.
        /// Use this operation when you want to find out all the details for a server. 
        /// It can be used to look for changes, its status, or to retrieve links to associated resources.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Server> GetServer(string serverId, CancellationToken cancellationToken)
        {
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Get, string.Format(Constants.ServiceUris.Server.GetServer, Configuration.BaseUri, authentication.AccountAlias, serverId), string.Empty);
            var result = await ServiceInvoker.Invoke<GetServerResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the pause operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to pause a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the pause command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> PauseServer(List<string> serverIds)
        {
            return await PauseServer(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the pause operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to pause a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the pause command.
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> PauseServer(List<string> serverIds, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(serverIds.ToArray());
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Server.PauseServer, Configuration.BaseUri, authentication.AccountAlias), content);
            var result = await ServiceInvoker.Invoke<ServerPowerOpsResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the power on operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to power on a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the power on command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> PowerOnServer(List<string> serverIds)
        {
            return await PowerOnServer(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the power on operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to power on a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the power on command. 
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> PowerOnServer(List<string> serverIds, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(serverIds.ToArray());
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Server.PowerOnServer, Configuration.BaseUri, authentication.AccountAlias), content);
            var result = await ServiceInvoker.Invoke<ServerPowerOpsResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the power off operation to a list of servers and adds operation to queue. 
        /// Use this operation when you want to power off a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the power off command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IReadOnlyList<ServerOperation>> PowerOffServer(List<string> serverIds)
        {
            return await PowerOffServer(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the power off operation to a list of servers and adds operation to queue. 
        /// Use this operation when you want to power off a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the power off command.
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> PowerOffServer(List<string> serverIds, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(serverIds.ToArray());
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Server.PowerOffServer, Configuration.BaseUri, authentication.AccountAlias), content);
            var result = await ServiceInvoker.Invoke<ServerPowerOpsResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the reboot operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to reboot a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the reboot command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> RebootServer(List<string> serverIds)
        {
            return await RebootServer(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the reboot operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to reboot a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the reboot command. 
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> RebootServer(List<string> serverIds, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(serverIds.ToArray());
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Server.RebootServer, Configuration.BaseUri, authentication.AccountAlias), content);
            var result = await ServiceInvoker.Invoke<ServerPowerOpsResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the shut down operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to shut down a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the shut down command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> ShutDownServer(List<string> serverIds)
        {
            return await ShutDownServer(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the shut down operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to shut down a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the shut down command.
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> ShutDownServer(List<string> serverIds, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(serverIds.ToArray());
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Server.ShutDownServer, Configuration.BaseUri, authentication.AccountAlias), content);
            var result = await ServiceInvoker.Invoke<ServerPowerOpsResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the reset operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to reset a single server or group of servers. 
        /// It should be used in conjunction with the  Queue GetStatus operation to check the result of the reset command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IReadOnlyList<ServerOperation>> ResetServer(List<string> serverIds)
        {
            return await ResetServer(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the reset operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to reset a single server or group of servers. 
        /// It should be used in conjunction with the  Queue GetStatus operation to check the result of the reset command. 
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<ServerOperation>> ResetServer(List<string> serverIds, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(serverIds.ToArray());
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Server.ResetServer, Configuration.BaseUri, authentication.AccountAlias), content);
            var result = await ServiceInvoker.Invoke<ServerPowerOpsResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the details for a individual server by hypermedia link.
        /// Use this operation when you want to find out all the details for a server. 
        /// It can be used to look for changes, its status, or to retrieve links to associated resources. 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        internal async Task<Server> GetServerByLink(string uri)
        {
            return await GetServerByLink(uri, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details for a individual server by hypermedia link.
        /// Use this operation when you want to find out all the details for a server. 
        /// It can be used to look for changes, its status, or to retrieve links to associated resources. 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<Server> GetServerByLink(string uri, CancellationToken cancellationToken)
        {
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Get, uri, string.Empty);
            var result = await ServiceInvoker.Invoke<GetServerResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }
    }
}
