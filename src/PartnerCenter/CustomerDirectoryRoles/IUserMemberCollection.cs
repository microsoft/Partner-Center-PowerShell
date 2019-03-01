// -----------------------------------------------------------------------
// <copyright file="IUserMemberCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Query;
    using Models.Roles;

    /// <summary>
    /// Represents the behavior of user member collection.
    /// </summary>
    public interface IUserMemberCollection : IPartnerComponent<Tuple<string, string>>, IEntityCreateOperations<UserMember, UserMember>, IEntireEntityCollectionRetrievalOperations<UserMember, SeekBasedResourceCollection<UserMember>>, IEntitySelector<IUserMember>
    {
        /// <summary>
        /// Queries the user members of a customer directory role.
        /// </summary>
        /// <param name="query">A query to apply onto user member collection.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The directory role user members.</returns>
        Task<SeekBasedResourceCollection<UserMember>> QueryAsync(IQuery query, CancellationToken cancellationToken = default);
    }
}