// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    /// <summary>
    /// The possible error categories for Partner Center PowerShell.
    /// </summary>
    public enum PartnerPowerShellErrorCategory
    {
        /// <summary>
        /// The error category was not specified.
        /// </summary>
        NotSpecified,

        /// <summary>
        /// The token being used for authentication has expired.
        /// </summary>
        TokenExpired,

        /// <summary>
        /// The error was caused by a validation failure.
        /// </summary>
        Validation
    }
}