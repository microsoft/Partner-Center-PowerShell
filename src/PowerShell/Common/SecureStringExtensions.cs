// -----------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Common
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Extends SecureString and string to all conversion.
    /// </summary>
    public static class SecureStringExtensions
    {
        /// <summary>
        /// Converts a secure string to a regular string.
        /// </summary>
        /// <param name="secureString">Specifies the secure string to convert.</param> 
        /// <returns>The string that was converted from a secure string </returns>
        public static string ConvertToString(this SecureString secureString)
        {
            secureString.AssertNotNull(nameof(secureString));

            IntPtr stringPtr = IntPtr.Zero;

            try
            {
                stringPtr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(stringPtr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(stringPtr);
            }
        }
    }
}