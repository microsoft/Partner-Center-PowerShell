// -----------------------------------------------------------------------
// <copyright file="ConfigurationPolicyCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.DevicesDeployment;
    using Models.JsonConverters;

    /// <summary>
    /// Implements operations that apply to configuration policy collections.
    /// </summary>
    internal class ConfigurationPolicyCollectionOperations : BasePartnerComponent<string>, IConfigurationPolicyCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPolicyCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public ConfigurationPolicyCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets configuration policy behavior.
        /// </summary>
        /// <param name="policyId">The policy identifier.</param>
        /// <returns>The customer configuration policy behavior.</returns>
        public IConfigurationPolicy this[string id] => ById(id);

        /// <summary>
        /// Gets configuration policy behavior.
        /// </summary>
        /// <param name="policyId">The policy identifier.</param>
        /// <returns>The customer configuration policy behavior.</returns>
        public IConfigurationPolicy ById(string id)
        {
            return new ConfigurationPolicyOperations(Partner, Context, id);
        }

        /// <summary>
        /// Creates a new configuration policy.
        /// </summary>
        /// <param name="newEntity">The new configuration policy information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The policy information that was just created.</returns>
        public async Task<ConfigurationPolicy> CreateAsync(ConfigurationPolicy newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<ConfigurationPolicy, ConfigurationPolicy>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateConfigurationPolicy.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a collection of configuration policies associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of configuration policies.</returns>
        public async Task<ResourceCollection<ConfigurationPolicy>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<ConfigurationPolicy>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetConfigurationPolicies.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<ConfigurationPolicy>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}