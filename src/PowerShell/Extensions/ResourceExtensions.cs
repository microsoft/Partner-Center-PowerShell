// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using System;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// Useful extension for performing conversions.
    /// </summary>
    internal static class ResourceExtensions
    {
        /// <summary>
        /// Copies the properties from the input to the output.
        /// </summary>
        /// <typeparam name="TInput">Type of the input.</typeparam>
        /// <typeparam name="TOutput">Type of the output.</typeparam>
        /// <param name="output">The object to be updated.</param>
        /// <param name="input">The object to be cloned.</param>
        public static void CopyFrom<TInput, TOutput>(this TOutput output, TInput input)
                  where TInput : class
                  where TOutput : class, new()
        {
            if (output != null && input != null)
            {
                CloneProperties(output, input);
            }
        }

        /// <summary>
        /// Copies the properties from the input to the output.
        /// </summary>
        /// <typeparam name="TInput">Type of the input.</typeparam>
        /// <typeparam name="TOutput">Type of the output.</typeparam>
        /// <param name="output">The object to be updated.</param>
        /// <param name="input">The object to be cloned.</param>
        /// <param name="operation">Additional operation to perform.</param>
        public static void CopyFrom<TInput, TOutput>(this TOutput output, TInput input, Action<TInput> operation)
            where TInput : class
            where TOutput : class, new()
        {
            if (output != null && input != null)
            {
                CloneProperties(output, input);
                operation.Invoke(input);
            }
        }

        private static void CloneProperties<TInput, TOutput>(TOutput output, TInput input) where TOutput : class, new()
        {
            foreach (PropertyInfo prop in output.GetType().GetRuntimeProperties())
            {
                if (input.GetType().GetRuntimeProperty(prop.Name) != null &&
                    prop.CanWrite &&
                    !typeof(ICollection).IsAssignableFrom(prop.PropertyType) &&
                    prop.PropertyType.IsAssignableFrom(input.GetType().GetRuntimeProperty(prop.Name).PropertyType))
                {
                    prop.SetValue(output, input.GetType().GetRuntimeProperty(prop.Name).GetValue(input));
                }
            }
        }
    }
}