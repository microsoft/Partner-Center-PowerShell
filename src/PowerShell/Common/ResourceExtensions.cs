// -----------------------------------------------------------------------
// <copyright file="ResourceExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Common
{
    using System;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// Useful extension for performing conversions.
    /// </summary>
    internal static class ResourceExtensions
    {
        public static void CopyFrom<TInput, TOutput>(this TOutput value, TInput other)
                  where TInput : class
                  where TOutput : class, new()
        {
            if (value != null && other != null)
            {
                CloneProperties(value, other);
            }
        }

        public static void CopyFrom<TInput, TOutput>(this TOutput value, TInput other, Action<TInput> operation)
            where TInput : class
            where TOutput : class, new()
        {
            if (value != null && other != null)
            {
                CloneProperties(value, other);
                operation.Invoke(other);
            }
        }

        /// <summary>
        /// Clones the properties from the input to the output.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="output"></param>
        /// <param name="input"></param>
        private static void CloneProperties<TInput, TOutput>(TOutput output, TInput input) where TOutput : class, new()
        {
            foreach (PropertyInfo prop in output.GetType().GetRuntimeProperties())
            {
                if (input.GetType().GetRuntimeProperty(prop.Name) != null && prop.CanWrite)
                {
                    if (!typeof(ICollection).IsAssignableFrom(prop.PropertyType))
                    {
                        if (prop.PropertyType.IsAssignableFrom(input.GetType().GetRuntimeProperty(prop.Name).PropertyType))
                        {
                            prop.SetValue(output, input.GetType().GetRuntimeProperty(prop.Name).GetValue(input));
                        }
                    }
                }
            }
        }
    }
}