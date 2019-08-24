// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    using System.ComponentModel;

    /// <summary>
    /// 
    /// </summary>
    public enum ApiError
    {
        [Description("Unknown error")]
        Unknown = 0,

        [Description("Product was not found")]
        ProductNotFound = 400013,

        [Description("Sku was not found")]
        SkuNotFound = 400018,

        [Description("A required inventory context item is missing")]
        InventoryContextMissing = 400026,

        [Description("Access to the requested segment is not allowed")]
        SegmentNotAllowed = 400030,

        [Description("Access to the requested catalog is not allowed")]
        CatalogNotAllowed = 400036
    }
}