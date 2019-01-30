// -----------------------------------------------------------------------
// <copyright file="InventoryRestriction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that represents an inventory restriction.
    /// </summary>
    public class InventoryRestriction
    {
        /// <summary>
        /// The set of properties that further describe this restriction.
        /// </summary>
        private Dictionary<string, string> properties;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the set of properties that further describe this restriction.
        /// </summary>
        public Dictionary<string, string> Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }

                return properties;
            }
            set
            {
                properties = new Dictionary<string, string>(value, StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Gets or sets the reason code.
        /// </summary>
        public string ReasonCode { get; set; }
    }
}