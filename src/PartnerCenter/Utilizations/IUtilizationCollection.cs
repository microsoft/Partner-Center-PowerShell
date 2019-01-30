// -----------------------------------------------------------------------
// <copyright file="IUtilizationCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Utilization
{
    using System;

    /// <summary>
    /// Groups subscription utilization behavior.
    /// </summary>
    public interface IUtilizationCollection : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Gets Azure subscription utilization behavior.
        /// </summary>
        IAzureUtilizationCollection Azure { get; }
    }
}