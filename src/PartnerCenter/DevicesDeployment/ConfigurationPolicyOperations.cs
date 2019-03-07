// -----------------------------------------------------------------------
// <copyright file="ConfigurationPolicyOperations.cs" company="Microsoft">
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
    using Models.DevicesDeployment;

    /// <summary>
    /// Implements operations that apply to configuration policy.
    /// </summary>
    internal class ConfigurationPolicyOperations : BasePartnerComponent<Tuple<string, string>>, IConfigurationPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPolicyOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="policyId">The policy identifier.</param>
        public ConfigurationPolicyOperations(IPartner rootPartnerOperations, string customerId, string policyId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, policyId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            policyId.AssertNotEmpty(nameof(policyId));
        }

        /// <summary>
        /// Deletes a configuration policy.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            await Partner.ServiceClient.DeleteAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.DeleteConfigurationPolicy.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the policy details.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The policy retrieved by policy identifier under a particular customer.</returns>
        public async Task<ConfigurationPolicy> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ConfigurationPolicy>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetConfigurationPolicy.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a configuration policy.
        /// </summary>
        /// <param name="entity">Payload of the update request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Updated configuration policy.</returns>
        public async Task<ConfigurationPolicy> PatchAsync(ConfigurationPolicy entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PutAsync<ConfigurationPolicy, ConfigurationPolicy>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateConfigurationPolicy.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}