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
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The Policy.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class Policy : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Policy class.
        /// </summary>
        public Policy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Policy class.
        /// </summary>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="marketplacePurchases">The marketplace purchases are
        /// free, allowed or not allowed. Possible values include:
        /// 'AllAllowed', 'OnlyFreeAllowed', 'NotAllowed'</param>
        /// <param name="reservationPurchases">The reservation purchases
        /// allowed or not. Possible values include: 'Allowed',
        /// 'NotAllowed'</param>
        /// <param name="viewCharges">Who can view charges. Possible values
        /// include: 'Allowed', 'NotAllowed'</param>
        public Policy(string id = default(string), string name = default(string), string type = default(string), string marketplacePurchases = default(string), string reservationPurchases = default(string), string viewCharges = default(string))
            : base(id, name, type)
        {
            MarketplacePurchases = marketplacePurchases;
            ReservationPurchases = reservationPurchases;
            ViewCharges = viewCharges;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the marketplace purchases are free, allowed or not
        /// allowed. Possible values include: 'AllAllowed', 'OnlyFreeAllowed',
        /// 'NotAllowed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.marketplacePurchases")]
        public string MarketplacePurchases { get; set; }

        /// <summary>
        /// Gets or sets the reservation purchases allowed or not. Possible
        /// values include: 'Allowed', 'NotAllowed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.reservationPurchases")]
        public string ReservationPurchases { get; set; }

        /// <summary>
        /// Gets or sets who can view charges. Possible values include:
        /// 'Allowed', 'NotAllowed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.viewCharges")]
        public string ViewCharges { get; set; }

    }
}
