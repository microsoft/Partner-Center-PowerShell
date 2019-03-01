// -----------------------------------------------------------------------
// <copyright file="RelationshipCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Relationships
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.JsonConverters;
    using Models.Query;
    using Models.Relationships;

    /// <summary>
    /// The relationship collection implementation.
    /// </summary>
    internal class RelationshipCollectionOperations : BasePartnerComponent<string>, IRelationshipCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public RelationshipCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets all the partner relationships.
        /// </summary>
        /// <param name="partnerRelationshipType">The type of partner relationship.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner relationships.</returns>
        public async Task<ResourceCollection<PartnerRelationship>> GetAsync(PartnerRelationshipType partnerRelationshipType, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetPartnerRelationships.Parameters.RelationshipType,
                    partnerRelationshipType.ToString()
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<PartnerRelationship>>(
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetPartnerRelationships.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<PartnerRelationship>(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Queries partner relationships associated to the partner.
        /// - Only <see cref="SimpleQuery" /> with a <see cref="SimpleFieldFilter" /> is supported.
        /// - This query supports a <see cref="FieldFilterOperation.Substring" /> search of the partner. Check <see cref="PartnerRelationshipSearchField" /> for
        /// the list of supported search fields.
        /// </summary>
        /// <param name="partnerRelationshipType">The type of partner relationship.</param>
        /// <param name="query">A query to apply onto partner relationships. Check <see cref="QueryFactory" /> to see how
        /// to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The partner relationships that match the given query.</returns>
        public async Task<ResourceCollection<PartnerRelationship>> QueryAsync(PartnerRelationshipType partnerRelationshipType, IQuery query, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetPartnerRelationships.Parameters.RelationshipType,
                    partnerRelationshipType.ToString()
                }
            };

            if (query?.Filter != null)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.GetPartnerRelationships.Parameters.Filter,
                    query.Filter.ToString());
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<PartnerRelationship>>(
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetPartnerRelationships.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<PartnerRelationship>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}