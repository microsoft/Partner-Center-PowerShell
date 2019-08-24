// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.ManagedServices
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.ManagedServices;

    /// <summary>
    /// Represents a customer's managed service.
    /// </summary>
    public sealed class PSManagedService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSManagedService" /> class.
        /// </summary>
        public PSManagedService()
        {
            Links = new Dictionary<string, Uri>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSManagedService" /> class.
        /// </summary>
        /// <param name="managedService">The base managed service for this instance.</param>
        public PSManagedService(ManagedService managedService)
        {
            Links = new Dictionary<string, Uri>();
            this.CopyFrom(managedService, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the managed service group name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets the available links.
        /// </summary>
        public Dictionary<string, Uri> Links { get; }

        /// <summary>
        /// Gets or sets the managed service identifier.
        /// </summary>
        public string ManagedServiceId { get; set; }

        /// <summary>
        /// Gets or sets the managed service name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="ManagedService" /> to an instance of <see cref="PSManagedService" />. 
        /// </summary>
        /// <param name="managedService">The managed service being cloned.</param>
        private void CloneAdditionalOperations(ManagedService managedService)
        {
            ManagedServiceId = managedService.Id;

            if (managedService.Links != null)
            {
                if (managedService.Links.AdminService != null)
                {
                    Links.Add(nameof(managedService.Links.AdminService), managedService.Links.AdminService.Uri);
                }

                if (managedService.Links.ServiceHealth != null)
                {
                    Links.Add(nameof(managedService.Links.ServiceHealth), managedService.Links.ServiceHealth.Uri);
                }

                if (managedService.Links.ServiceTicket != null)
                {
                    Links.Add(nameof(managedService.Links.ServiceTicket), managedService.Links.ServiceTicket.Uri);
                }
            }
        }
    }
}