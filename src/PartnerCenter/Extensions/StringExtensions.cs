// -----------------------------------------------------------------------
// <copyright file="UserPartnerCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Common string conversion methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the string value to an instance of <see cref="SecureString"/>.
        /// </summary>
        /// <param name="value">The string value to be converted.</param>
        /// <returns>An instance of <see cref="SecureString"/> that represents the string.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> is empty or null.
        /// </exception>
        public static SecureString ToSecureString(this string value)
        {
            SecureString secureValue = new SecureString();

            value.AssertNotEmpty(nameof(value));

            foreach (char c in value)
            {
                secureValue.AppendChar(c);
            }

            secureValue.MakeReadOnly();

            return secureValue;
        }

        /// <summary>
        /// Converts an instance of <see cref="SecureString"/> to a <see cref="string"/>.
        /// </summary>
        /// <param name="secureString">Secure string to be converted.</param>
        /// <returns>An instance of <see cref="string"/> that represents the <see cref="SecureString"/> value.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="secureString"/> is null.
        /// </exception>
        public static string ToUnsecureString(this SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;

            secureString.AssertNotNull(nameof(secureString));

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}