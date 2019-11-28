// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using System; 

    public class StreamEventArgs : EventArgs
    {
        public StreamEventArgs()
        { }

        public string Message { get; set; }

        public object Resource { get; set; }
    }
}