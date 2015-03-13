﻿using CenturyLinkCloudSDK.Runtime;
using CenturyLinkCloudSDK.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.ServiceModels
{
    public class Group
    {
        private Lazy<IEnumerable<Link>> serverLinks;

        public Authentication Authentication { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int ServersCount { get; set; }

        public ComputeLimits Limits { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        [JsonPropertyAttribute]
        private IEnumerable<Link> Links { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Group()
        {
            serverLinks = new Lazy<IEnumerable<Link>>(()=>
            {
                return Links.Where(l => String.Equals(l.Rel, "server", StringComparison.CurrentCultureIgnoreCase)).ToList();
            });
        }

        /// <summary>
        /// Determines if this Group has servers by examining the Links collection.
        /// </summary>
        private bool HasServers()
        {
            return serverLinks.Value.Count() > 0 ? true : false;
        }

        /// <summary>
        /// Gets the servers that belong to this group.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Server>> GetServers()
        {
            return await GetServers(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the servers that belong to this group.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Server>> GetServers(CancellationToken cancellationToken)
        {
            var servers = new List<Server>();

            if (!HasServers())
            {
                return null;
            }

            var serverService = new ServerService(Authentication);

            foreach (var serverLink in serverLinks.Value)
            {
                var server = await serverService.GetServerByLink(Configuration.BaseUri + serverLink.Href, cancellationToken);
                servers.Add(server);
            }

            return servers;
        }

        /// <summary>
        /// Returns the server Ids for all groups and subgroups.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetServerIds()
        {
            return GetServerIds(CancellationToken.None);
        }

        /// <summary>
        /// Returns the server Ids for all groups and subgroups.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public IEnumerable<string> GetServerIds(CancellationToken cancellationToken)
        {
            var serverIds = new List<string>();

            if (!HasServers())
            {
                return null;
            }

            return serverLinks.Value.Select(l => l.Id).ToList();
        }
    }
}
