﻿using CenturyLinkCloudSDK.ServiceAPI.Runtime;
using CenturyLinkCloudSDK.ServiceModels.V2.Server.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.ServiceAPI.V2
{
    public class Server: ServiceAPIBase
    {
        public async Task<GetServerResponse> GetServer(string accountAlias, string serverId)
        {
            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = "https://api.tier3.com/",
                ServiceUri = string.Format("https://api.tier3.com/v2/servers/{0}/{1}", accountAlias, serverId),
                MediaType = "application/json",
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetServerResponse>(serviceRequest).ConfigureAwait(false);

            return result;
        }

        public async Task<PauseServerResponse> PauseServer(string accountAlias, List<string> serverIds)
        {
            var serversToBePaused = new List<string>();

            //Ensure pausing only those servers that are PoweredOn.
            foreach(var serverId in serverIds)
            {
                var server = await GetServer(accountAlias, serverId).ConfigureAwait(false);

                if(server.Details.PowerState == "started")
                {
                    serversToBePaused.Add(serverId);
                }
            }

            if (serversToBePaused.Count > 0)
            {
                var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

                var serviceRequest = new ServiceRequest()
                {
                    BaseAddress = "https://api.tier3.com/",
                    ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/pause", accountAlias),
                    MediaType = "application/json",
                    RequestModel = requestModel,
                    HttpMethod = HttpMethod.Post
                };

                var response = await Invoke<ServiceRequest, PauseServerResponse>(serviceRequest).ConfigureAwait(false);

                return response;
            }

            return default(PauseServerResponse);
        }

        public async Task<PowerOnServerResponse> PowerOnServer(string accountAlias, List<string> serverIds)
        {
            var serversToBePoweredOn = new List<string>();

            //Ensure powering only those servers that are PoweredOn and...
            //TODO: We need to find out from what power state we can go to what power state and what the power state strings are.
            foreach (var serverId in serverIds)
            {
                var server = await GetServer(accountAlias, serverId).ConfigureAwait(false);

                if (server.Details.PowerState == "paused")
                {
                    serversToBePoweredOn.Add(serverId);
                }
            }

            if (serversToBePoweredOn.Count > 0)
            {
                var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

                var serviceRequest = new ServiceRequest()
                {
                    BaseAddress = "https://api.tier3.com/",
                    ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/powerOn", accountAlias),
                    MediaType = "application/json",
                    RequestModel = requestModel,
                    HttpMethod = HttpMethod.Post
                };

                var response = await Invoke<ServiceRequest, PowerOnServerResponse>(serviceRequest).ConfigureAwait(false);

                return response;
            }

            return default(PowerOnServerResponse);
        }
    }
}
