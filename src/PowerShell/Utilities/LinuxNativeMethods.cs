// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System.Runtime.InteropServices;

    internal static class LinuxNativeMethods
    {
        public const int RootUserId = 0;

        /// <summary>
        /// Get the real user identifier of the calling process.
        /// </summary>
        /// <returns>the real user ID of the calling process</returns>
        [DllImport("libc")]
        public static extern int getuid();
    }
}