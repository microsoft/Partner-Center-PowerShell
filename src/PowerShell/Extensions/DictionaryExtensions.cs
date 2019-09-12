// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension methods for retrieving properties from an extensions dictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Safely get the value of the given property, or return the default if no value is present in the dictionary
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <typeparam name="TValue">The dictionary value type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <returns>The value stored in the dictionary, or the default if no value is specified.</returns>
        public static TValue GetProperty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey property)
        {
            if (dictionary.ContainsKey(property))
            {
                return dictionary[property];
            }

            return default;
        }

        /// <summary>
        /// Determine if the given property has a value
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <returns><c>true</c> if the proeprty has a value; otherwise <c>false</c>.</returns>
        public static bool IsPropertySet<TKey>(this IDictionary<TKey, string> dictionary, TKey property)
        {
            return dictionary.ContainsKey(property) && !string.IsNullOrEmpty(dictionary[property]);
        }

        /// <summary>
        /// Replace the value of the given property with a comma separated list of strings
        /// </summary>
        /// <typeparam name="TKey">The disctionary key type</typeparam>
        /// <param name="dictionary">The extensions dictionary to search</param>
        /// <param name="property">The property to serach for</param>
        /// <param name="values">The strings to store in the property</param>
        public static void SetProperty<TKey>(this IDictionary<TKey, string> dictionary, TKey property, params string[] values)
        {
            if (values == null || values.Length == 0)
            {
                if (dictionary.ContainsKey(property))
                {
                    dictionary.Remove(property);
                }
            }
            else
            {
                dictionary[property] = string.Join(",", values);
            }
        }
    }
}