// -----------------------------------------------------------------------
// <copyright file="ServiceCostSummaryOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.ServiceCosts;

    /// <summary>
    /// This class implements the operations for a customer's service costs summary.
    /// </summary>
    internal class ServiceCostSummaryOperations : BasePartnerComponent<Tuple<string, ServiceCostsBillingPeriod>>, IServiceCostSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCostSummaryOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="context">The context, including customer identifier and billing period.</param>
        public ServiceCostSummaryOperations(IPartner rootPartnerOperations, Tuple<string, ServiceCostsBillingPeriod> context)
          : base(rootPartnerOperations, context)
        {
            context.AssertNotNull(nameof(context));
        }

        /// <summary>
        /// Gets the customer's service cost summary.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's service cost summary.</returns>
        public ServiceCostsSummary Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the customer's service cost summary.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer's service cost summary.</returns>
        public async Task<ServiceCostsSummary> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ServiceCostsSummary>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerServiceCostsSummary.Path}",
                        Context.Item1,
                        Context.Item2.ToString()),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}