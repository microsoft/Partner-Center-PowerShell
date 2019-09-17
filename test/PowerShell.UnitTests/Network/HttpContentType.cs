// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    /// <summary>
    /// The available HTTP content types.
    /// </summary>
    internal enum HttpContentType
    {
        /// <summary>
        /// The type if the content contains binary.
        /// </summary>
        Binary,

        /// <summary>
        /// The type if the content contains one ore more string literal.
        /// </summary>
        Ascii,

        /// <summary>
        /// The type if the content is empty.
        /// </summary>
        Null
    }
}