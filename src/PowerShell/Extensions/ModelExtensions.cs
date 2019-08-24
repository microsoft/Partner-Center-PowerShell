// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using Models;

    /// <summary>
    /// Methods for all extensible models - allows retrieving and setting extension proeprties without knowing the underlying implementation.
    /// </summary>
    public static class ModelExtensions
    {
        /// <summary>
        /// Safely get the given property for the model
        /// </summary>
        /// <param name="model">The model to search</param>
        /// <param name="propertyKey">The given key of the property</param>
        /// <returns>The value of the property in the given model, or null if the property is not set</returns>
        public static string GetProperty(this IExtensibleModel model, string propertyKey)
        {
            string result = null;

            if (model.IsPropertySet(propertyKey))
            {
                result = model.ExtendedProperties.GetProperty(propertyKey);
            }

            return result;
        }

        /// <summary>
        /// Determine if the given proeprty is set in the model
        /// </summary>
        /// <param name="model">The model to check</param>
        /// <param name="propertyKey">The property to check</param>
        /// <returns>True if the property is set, otherwise false</returns>
        public static bool IsPropertySet(this IExtensibleModel model, string propertyKey)
        {
            bool result = false;
            if (propertyKey != null)
            {
                result = model.ExtendedProperties.IsPropertySet(propertyKey);
            }

            return result;
        }

        /// <summary>
        /// Safely set the given property for the model to the given values.  If more than one value is provided, values are 
        /// represented as a comma-separated list
        /// </summary>
        /// <param name="model">The model to change.</param>
        /// <param name="propertyKey">The property to set</param>
        /// <param name="values">The value(s) to set for the property</param>
        public static void SetProperty(this IExtensibleModel model, string propertyKey, params string[] values)
        {
            if (propertyKey != null)
            {
                model.ExtendedProperties.SetProperty(propertyKey, values);
            }
        }
    }
}