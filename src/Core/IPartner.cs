// -----------------------------------------------------------------------
// <copyright file="IPartner.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core
{
    using Customers;
    using Network;
    using RequestContext;

    /// <summary>
    /// The main entry point into using the Partner Center SDK functionality. Represents a partner and encapsulates all the behavior attached to partners.
    /// Use this interface to get to the partner's customers, profiles, and customer orders, profiles and subscriptions and more.
    /// </summary>
    public interface IPartner
    {
        /// <summary>
        /// Gets the partner credentials.
        /// </summary>
        IPartnerCredentials Credentials { get; }

        /// <summary>
        /// Gets the partner's customers operations.
        /// </summary>
        ICustomerCollection Customers { get; }

        /// <summary>
        /// Gets the partner context.
        /// </summary>
        IRequestContext RequestContext { get; }

        /// <summary>
        /// Gets the partner service client.
        /// </summary>
        IPartnerServiceClient ServiceClient { get; }
    }
}