// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell
{
    using System;
    using System.Globalization;
    using Properties;

    /// <summary>
    /// Groups useful validation extension methods.
    /// </summary>
    internal static class ValidationExtensions
    {
        /// <summary>
        /// Ensures that a given object is not null. Throws an exception otherwise.
        /// </summary>
        /// <param name="objectToValidate">The object we are validating.</param>
        /// <param name="caption">The name to report in the exception.</param>
        public static void AssertNotNull(this object objectToValidate, string caption)
        {
            if (objectToValidate == null)
            {
                throw new ArgumentNullException(caption);
            }
        }

        /// <summary>
        /// Ensures that a string is not empty. Throws an exception if so.
        /// </summary>
        /// <param name="nonEmptyString">The string to validate.</param>
        /// <param name="caption">The name to report in the exception.</param>
        public static void AssertNotEmpty(this string nonEmptyString, string caption)
        {
            if (string.IsNullOrWhiteSpace(nonEmptyString))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.AssertStringNotEmptyInvalidError, caption ?? Resources.AssertStringNotEmptyInvalidPrefix));
            }
        }
    }
}
