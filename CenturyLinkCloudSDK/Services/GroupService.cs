﻿using CenturyLinkCloudSDK.Runtime;
using CenturyLinkCloudSDK.ServiceModels;
using CenturyLinkCloudSDK.ServiceModels.Requests.Group;
using CenturyLinkCloudSDK.ServiceModels.Responses.Groups;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CenturyLinkCloudSDK.Extensions;

namespace CenturyLinkCloudSDK.Services
{
    /// <summary>
    /// This class contains operations associated with server groups.
    /// </summary>
    public class GroupService : ServiceBase
    {
        internal GroupService(Authentication authentication)
            : base(authentication)
        {
        }

        /// <summary>
        /// Gets the details for a individual server group and any sub-groups and servers that it contains. 
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<Group> GetGroup(string groupId)
        {
            return await GetGroup(groupId, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details for a individual server group and any sub-groups and servers that it contains.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Group> GetGroup(string groupId, CancellationToken cancellationToken)
        {
            var uri = string.Format(Constants.ServiceUris.Group.GetGroup, Configuration.BaseUri, authentication.AccountAlias, groupId);
            return await GetGroupByLink(uri, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns recent group activity.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetRecentActivity(IEnumerable<string> referenceIds)
        {

            return await GetRecentActivity(referenceIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns recent group activity.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetRecentActivity(IEnumerable<string> referenceIds, CancellationToken cancellationToken)
        {

            return await GetRecentActivity(referenceIds, 10, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns recent group activity.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetRecentActivity(IEnumerable<string> referenceIds, int recordCountLimit)
        {

            return await GetRecentActivity(referenceIds, recordCountLimit, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns recent data center activity.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetRecentActivity(IEnumerable<string> accounts, IEnumerable<string> referenceIds, int recordCountLimit)
        {
            return await GetRecentActivity(accounts, referenceIds, recordCountLimit, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns recent group activity.
        /// </summary>
        /// <param name="referenceIds"></param>
        /// <param name="recordCountLimit"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetRecentActivity(IEnumerable<string> referenceIds, int recordCountLimit, CancellationToken cancellationToken)
        {
            var accounts = new List<string>();
            accounts.Add(authentication.AccountAlias);

            return await GetRecentActivity(accounts, referenceIds, recordCountLimit, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns recent group activity.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetRecentActivity(IEnumerable<string> accounts, IEnumerable<string> referenceIds, int recordCountLimit, CancellationToken cancellationToken)
        {
            var requestModel = new GetRecentActivityRequest()
            {
                EntityTypes = new List<string>() { Constants.EntityTypes.Server, Constants.EntityTypes.Group },
                ReferenceIds = referenceIds,
                Accounts = accounts,
                Limit = recordCountLimit
            };

            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Post, string.Format(Constants.ServiceUris.Group.GetRecentActivity, Configuration.BaseUri), requestModel);
            var result = await ServiceInvoker.Invoke<IEnumerable<Activity>>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Gets the group overview, which contains composite information from several different areas such as billing, assets, recent activities etc.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<GroupOverview> GetGroupOverview(string groupId)
        {
            return await GetGroupOverview(groupId, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the group overview, which contains composite information from several different areas such as billing, assets, recent activities etc.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GroupOverview> GetGroupOverview(string groupId, CancellationToken cancellationToken)
        {
            var group = await GetGroup(groupId, cancellationToken).ConfigureAwait(false);

            if (group != null)
            {
                var serverIds = GetServerIds(group, new List<string>());
                var tasks = new List<Task>();

                BillingDetail billingTotals = null;
                TotalAssets totalAssets = null;
                DefaultSettings defaultSettings = null;
                IEnumerable<Activity> recentActivity = null;

                tasks.Add(Task.Run(async () => billingTotals = await group.GetBillingTotals(cancellationToken).ConfigureAwait(false)));
                tasks.Add(Task.Run(async () => totalAssets = await GetTotalAssets(serverIds, cancellationToken).ConfigureAwait(false)));
                tasks.Add(Task.Run(async () => defaultSettings = await group.GetDefaultSettings(cancellationToken).ConfigureAwait(false)));
                tasks.Add(Task.Run(async () => recentActivity = await GetRecentActivity(serverIds, cancellationToken).ConfigureAwait(false)));

                await Task.WhenAll(tasks);

                var groupOverview = new GroupOverview()
                {
                    Group = group,
                    BillingTotals = billingTotals,
                    TotalAssets = totalAssets,
                    DefaultSettings = defaultSettings,
                    RecentActivity = recentActivity
                };

                return groupOverview;
            }

            return null;
        }

        /// <summary>
        /// Gets the total assets for the group.
        /// </summary>
        /// <param name="serverIds"></param>
        /// <returns></returns>
        public async Task<TotalAssets> GetTotalAssets(List<string> serverIds)
        {
            return await GetTotalAssets(serverIds, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the total assets for the group.
        /// </summary>
        /// <param name="serverIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TotalAssets> GetTotalAssets(List<string> serverIds, CancellationToken cancellationToken)
        {
            var serverService =  new ServerService(authentication);
            var totalAssets =  new TotalAssets();

            totalAssets.Servers = serverIds.Count;

            foreach(var serverId in serverIds)
            {
                var server = await serverService.GetServer(serverId, cancellationToken).ConfigureAwait(false);

                if(server == null)
                {
                    return null;
                }

                if(server.Details == null)
                {
                    return null;
                }

                totalAssets.Cpus += server.Details.Cpu;
                totalAssets.MemoryGB += server.Details.MemoryMB;
                totalAssets.StorageGB += server.Details.StorageGB;     
            }

            //The memory values we get for the servers is in MB so we need to convert to GB to display.
            totalAssets.MemoryGBFormatted = totalAssets.MemoryGB.ConvertMBToGB();

            return totalAssets;
        }

        /// <summary>
        /// Recursive method that gets the serverIds of the data center root group and all subgroups.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="serverIds"></param>
        /// <returns></returns>
        public List<string> GetServerIds(Group group, List<string> serverIds)
        {
            var groupServerIds = group.GetServerIds();

            if (groupServerIds != null)
            {
                serverIds.AddRange(groupServerIds);
            }

            foreach (var subgroup in group.Groups)
            {
                serverIds = GetServerIds(subgroup, serverIds);
            }

            return serverIds;
        }

        /// <summary>
        /// Gets the details for a individual server group and any sub-groups and servers that it contains by hypermedia link.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        internal async Task<Group> GetGroupByLink(string uri)
        {
            return await GetGroupByLink(uri, CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details for a individual server group and any sub-groups and servers that it contains by hypermedia link.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<Group> GetGroupByLink(string uri, CancellationToken cancellationToken)
        {
            var httpRequestMessage = CreateHttpRequestMessage(HttpMethod.Get, uri);
            var result = await ServiceInvoker.Invoke<Group>(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            result.Authentication = authentication;

            return result;
        }
    }
}
