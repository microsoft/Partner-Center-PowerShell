// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using System;
    using System.Globalization;
    using Properties;

    /// <summary>
    /// Groups useful extension methods used for validation.
    /// </summary>
    public static class AssertExtensions
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

        /// <summary>
        /// Ensures that a given number is greater than zero. Throws an exception otherwise.
        /// </summary>
        /// <param name="number">The number to validate.</param>
        /// <param name="caption">The name to report in the exception.</param>
        public static void AssertPositive(this int number, string caption)
        {
            if (number <= 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.AssertNumberPositiveInvalidError, caption ?? Resources.AssertNumberPositiveInvalidPrefix));
            }
        }

        /// <summary>
        /// Ensures that a given number is greater than zero. Throws an exception otherwise.
        /// </summary>
        /// <param name="number">The number to validate.</param>
        /// <param name="caption">The name to report in the exception.</param>
        public static void AssertPositive(this decimal number, string caption)
        {
            if (number <= 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.AssertNumberPositiveInvalidError, caption ?? Resources.AssertNumberPositiveInvalidPrefix));
            }
        }
    }
}