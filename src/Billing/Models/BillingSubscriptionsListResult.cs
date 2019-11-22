// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Billing.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Result of listing billing subscriptions.
    /// </summary>
    public partial class BillingSubscriptionsListResult
    {
        /// <summary>
        /// Initializes a new instance of the BillingSubscriptionsListResult
        /// class.
        /// </summary>
        public BillingSubscriptionsListResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BillingSubscriptionsListResult
        /// class.
        /// </summary>
        /// <param name="value">The list of billing subscriptions.</param>
        /// <param name="nextLink">The link (url) to the next page of
        /// results.</param>
        public BillingSubscriptionsListResult(IList<BillingSubscription> value = default(IList<BillingSubscription>), string nextLink = default(string))
        {
            Value = value;
            NextLink = nextLink;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the list of billing subscriptions.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<BillingSubscription> Value { get; private set; }

        /// <summary>
        /// Gets the link (url) to the next page of results.
        /// </summary>
        [JsonProperty(PropertyName = "nextLink")]
        public string NextLink { get; private set; }

    }
}
