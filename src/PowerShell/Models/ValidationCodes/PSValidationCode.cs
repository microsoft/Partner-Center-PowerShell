// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.ValidationCodes
{
    using Extensions;
    using PartnerCenter.Models.ValidationCodes;

    /// <summary>
    /// Represents validation codes. Used to create Government Community Cloud (GCC) accounts.
    /// </summary>
    public sealed class PSValidationCode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSValidationCode" /> class.
        /// </summary>
        public PSValidationCode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSValidationCode" /> class.
        /// </summary>
        /// <param name="validationCode">The validation code used to create Government Community Cloud (GCC) accounts.</param>
        public PSValidationCode(ValidationCode validationCode)
        {
            this.CopyFrom(validationCode);
        }

        /// <summary>
        /// Gets or sets number of maximum customer creates for this code.
        /// </summary>
        public int? MaxCreates { get; set; }

        /// <summary>
        /// Gets or sets the organization name.
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the partner's identifier.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the number of remaining customer creates for this code.
        /// </summary>
        public int? RemainingCreates { get; set; }

        /// <summary>
        /// Gets or sets the validation identifier.
        /// </summary>
        public string ValidationId { get; set; }
    }
}
