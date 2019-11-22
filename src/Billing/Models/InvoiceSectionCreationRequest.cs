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
    using Newtonsoft.Json;

    /// <summary>
    /// The properties of an InvoiceSection.
    /// </summary>
    public partial class InvoiceSectionCreationRequest
    {
        /// <summary>
        /// Initializes a new instance of the InvoiceSectionCreationRequest
        /// class.
        /// </summary>
        public InvoiceSectionCreationRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the InvoiceSectionCreationRequest
        /// class.
        /// </summary>
        /// <param name="displayName">The name of the InvoiceSection.</param>
        public InvoiceSectionCreationRequest(string displayName = default(string))
        {
            DisplayName = displayName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the InvoiceSection.
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

    }
}
