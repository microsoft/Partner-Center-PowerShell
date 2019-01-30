// -----------------------------------------------------------------------
// <copyright file="AzureInstanceData.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Utilizations
{
    using System;
    using System.Collections.Generic;

    public class AzureInstanceData
    {
        /// <summary>
        /// Gets or sets additional data for an Azure resource.
        /// </summary>
        public IDictionary<string, string> AdditionalInfo { get; set; }

        /// <summary>
        /// Gets or sets the region in which the service was run.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the unique namespace used to identify the 3rd party order for Azure Marketplace.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique namespace used to identify the resource for Azure Marketplace 3rd party usage.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified Azure resource ID, which includes the resource groups and the instance name.
        /// </summary>
        public Uri ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the resource tags specified by the user.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
    }
}