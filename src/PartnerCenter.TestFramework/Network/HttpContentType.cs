// -----------------------------------------------------------------------
// <copyright file="HttpContentType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.TestFramework.Network
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