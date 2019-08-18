﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    using System;

    /// <summary>
    /// Represents the stream event arguments.
    /// </summary>
    public class StreamEventArgs : EventArgs
    {
        /// <summary>
        /// The message to write to the corresponding stream.
        /// </summary>
        public string Message { get; set; }
    }
}