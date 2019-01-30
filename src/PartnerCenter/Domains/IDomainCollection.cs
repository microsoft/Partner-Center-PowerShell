// -----------------------------------------------------------------------
// <copyright file="IDomainCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Domains
{
    /// <summary>
    /// Encapsulates domains behavior.
    /// </summary>
    public interface IDomainCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the specific domain behavior.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>The domain operations.</returns>
        IDomain ByDomain(string domain);
    }
}