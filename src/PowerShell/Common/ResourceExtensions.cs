// -----------------------------------------------------------------------
// <copyright file="ResourceExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Models.Carts;
    using Models.Orders;
    using Models.Utilizations;
    using PartnerCenter.Models.Carts;
    using PartnerCenter.Models.Orders;
    using PartnerCenter.Models.Utilizations;

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
        /// Copies the values from an instance of <see cref="PSAzureUtilizationRecord" />.
        /// </summary>
        /// <param name="azureUtilizationRecord">An instance of the <see cref="PSAzureUtilizationRecord" /> class.</param>
        /// <param name="other">The base Azure utilization record that should be cloned.</param>
        public static void CopyFrom(this PSAzureUtilizationRecord azureUtilizationRecord, AzureUtilizationRecord other)
        {
            if (azureUtilizationRecord != null && other != null)
            {
                CloneProperties(azureUtilizationRecord, other);

                azureUtilizationRecord.AdditionalInfo = other.InstanceData.AdditionalInfo;
                azureUtilizationRecord.InfoFields = other.InfoFields;
                azureUtilizationRecord.Tags = other.InstanceData.Tags;

                azureUtilizationRecord.CopyFrom(other.InstanceData);
                azureUtilizationRecord.CopyFrom(other.Resource);
            }
        }

        #region Orders

        /// <summary>
        /// Copies the values from an instance of <see cref="PSOrderLineItem" />.
        /// </summary>
        /// <param name="orderLineItem">An instance of the <see cref="PSOrderLineItem"/> class.</param>
        /// <param name="other">The base order line item whose properties should be copied.</param>
        public static void CopyFrom(this PSOrderLineItem orderLineItem, OrderLineItem other)
        {
            if (orderLineItem != null && other != null)
            {
                CloneProperties(orderLineItem, other);

                if (other.ProvisioningContext != null)
                {
                    foreach (KeyValuePair<string, string> item in other.ProvisioningContext)
                        orderLineItem.ProvisioningContext.Add(item.Key, item.Value);

                }
            }
        }

        /// <summary>
        /// Converts an instance of <see cref="PSCartLineItem" /> to an instance of <see cref="CartLineItem" />.
        /// </summary>
        /// <param name="orderLineItem">An instance the <see cref="PSCartLineItem" /> class that represents purcharse data for an offer.</param>
        /// <returns>An instance of the <see cref="CartLineItem" /> that represents purchase data for an offer.</returns>
        public static CartLineItem ToCartLineItem(this PSCartLineItem cartLineItem) => new CartLineItem
        {
            BillingCycle = cartLineItem.BillingCycle,
            CatalogItemId = cartLineItem.CatalogItemId,
            CurrencyCode = cartLineItem.CurrencyCode,
            Error = cartLineItem.Error,
            FriendlyName = cartLineItem.FriendlyName,
            Id = cartLineItem.Id,
            OrderGroup = cartLineItem.OrderGroup,
            Participants = cartLineItem.Participants,
            ProvisioningContext = cartLineItem.ProvisioningContext?.Cast<DictionaryEntry>().ToDictionary(entry => (string)entry.Key, kvp => (string)kvp.Value),
            Quantity = cartLineItem.Quantity
        };

        /// <summary>
        /// Converts an instance of <see cref="PSOrderLineItem" /> to an instance of <see cref="OrderLineItem" />.
        /// </summary>
        /// <param name="orderLineItem">An instance the <see cref="PSOrderLineItem" /> class that represents purcharse data for an offer.</param>
        /// <returns>An instance of the <see cref="OrderLineItem" /> that represents purchase data for an offer.</returns>
        public static OrderLineItem ToOrderLineItem(this PSOrderLineItem orderLineItem) => new OrderLineItem
        {
            FriendlyName = orderLineItem.FriendlyName,
            LineItemNumber = orderLineItem.LineItemNumber,
            OfferId = orderLineItem.OfferId,
            ParentSubscriptionId = orderLineItem.ParentSubscriptionId,
            PartnerIdOnRecord = orderLineItem.PartnerIdOnRecord,
            ProvisioningContext = orderLineItem.ProvisioningContext?.Cast<DictionaryEntry>().ToDictionary(entry => (string)entry.Key, kvp => (string)kvp.Value),
            Quantity = orderLineItem.Quantity,
            SubscriptionId = orderLineItem.SubscriptionId
        };

        #endregion

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
                        prop.SetValue(output, input.GetType().GetRuntimeProperty(prop.Name).GetValue(input));
                    }
                }
            }
        }
    }
}