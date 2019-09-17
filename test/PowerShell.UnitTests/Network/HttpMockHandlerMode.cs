// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    /// <summary>
    /// The possible modes for the mock HTTP handler.
    /// </summary>
    public enum HttpMockHandlerMode
    {
        /// <summary>
        /// The playback mode should always be after a successful record session.
        /// The mock server matches the given requests and return their stored 
        /// corresponding responses.
        /// </summary>
        Playback,

        /// <summary>
        /// In this mode the mock server watches the out-going requests and records
        /// their corresponding responses.
        /// </summary>
        Record
    }
}