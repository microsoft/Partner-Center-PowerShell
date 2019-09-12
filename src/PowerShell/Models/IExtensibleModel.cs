// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A model with extensible properties, to allow backward compatible updates to the model.
    /// </summary>
    public interface IExtensibleModel
    {
        /// <summary>
        /// Gets the extended properties.
        /// </summary>
        IDictionary<string, string> ExtendedProperties { get; }
    }
}