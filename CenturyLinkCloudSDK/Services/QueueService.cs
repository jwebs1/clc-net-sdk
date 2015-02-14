﻿using CenturyLinkCloudSDK.ServiceModels;
using CenturyLinkCloudSDK.ServiceModels.Responses.Queues;
using CenturyLinkCloudSDK.Runtime;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace CenturyLinkCloudSDK.Services
{
    /// <summary>
    /// This class contains operations associated with queues.
    /// </summary>
    public class QueueService
    {
        private Authentication authentication;

        internal QueueService(Authentication authentication)
        {
            this.authentication = authentication;
        }

        /// <summary>
        /// Gets the status of a particular job in the queue, which keeps track of any long-running 
        /// asynchronous requests (such as server power operations or provisioning tasks).
        /// Use this API operation when you want to check the status of a specific job in the queue. 
        /// It is usually called after running a batch job and receiving the job identifier from the status link (e.g. Power On, Create Server, etc.) 
        /// and will typically continue to get called until a "succeeded" or "failed" response is returned.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="statusId"></param>
        /// <returns>An asynchronous Task of Queue.</returns>
        public async Task<Queue> GetStatus(string statusId)
        {
            return await GetStatus(statusId, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the status of a particular job in the queue, which keeps track of any long-running 
        /// asynchronous requests (such as server power operations or provisioning tasks).
        /// Use this API operation when you want to check the status of a specific job in the queue. 
        /// It is usually called after running a batch job and receiving the job identifier from the status link (e.g. Power On, Create Server, etc.) 
        /// and will typically continue to get called until a "succeeded" or "failed" response is returned.
        /// </summary>
        /// <param name="statusId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>An asynchronous Task of Queue.</returns>
        public async Task<Queue> GetStatus(string statusId, CancellationToken cancellationToken)
        {
            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/status/{1}", authentication.AccountAlias, statusId),
                Authentication = authentication,
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await ServiceInvoker.Invoke<ServiceRequest, GetStatusResponse>(serviceRequest, cancellationToken).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the status of a particular job in the queue, which keeps track of any long-running 
        /// asynchronous requests (such as server power operations or provisioning tasks) by hypermedia link.
        /// Use this API operation when you want to check the status of a specific job in the queue. 
        /// It is usually called after running a batch job and receiving the job identifier from the status link (e.g. Power On, Create Server, etc.) 
        /// and will typically continue to get called until a "succeeded" or "failed" response is returned.
        /// </summary>
        /// <param name="hypermediaLink"></param>
        /// <returns>An asynchronous Task of Queue.</returns>
        public async Task<Queue> GetStatusByHypermediaLink(string hypermediaLink)
        {
            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = Constants.ServiceUris.ApiBaseAddress + hypermediaLink,
                Authentication = authentication,
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await ServiceInvoker.Invoke<ServiceRequest, GetStatusResponse>(serviceRequest, CancellationToken.None).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response;
                return response;
            }

            return null;
        }
    }
}
