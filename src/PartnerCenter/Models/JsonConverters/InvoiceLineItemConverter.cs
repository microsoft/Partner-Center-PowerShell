// -----------------------------------------------------------------------
// <copyright file="InvoiceLineItemConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.JsonConverters
{
    using System;
    using Models.Invoices;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Deserializes invoice line items to the correct type.
    /// </summary>
    public class InvoiceLineItemConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(InvoiceLineItem).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Gets a value indicating whether this instance can write.
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <exception cref="ArgumentNullException">
        /// reader
        /// or
        /// objectType
        /// </exception>
        /// <exception cref="JsonSerializationException">
        /// </exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            BillingProvider billingProvider;
            JObject json;
            string billingProviderValue;
            string invoiceLineItemType;
            InvoiceLineItem lineItem = null;

            json = JObject.Load(reader);

            billingProviderValue = json["billingProvider"].ToString();
            billingProvider = JsonConvert.DeserializeObject<BillingProvider>($"'{billingProviderValue}'");

            invoiceLineItemType = json["invoiceLineItemType"].ToString();

            if (!invoiceLineItemType.Equals("usage_line_items", StringComparison.InvariantCultureIgnoreCase))
            {
                if (invoiceLineItemType.Equals("billing_line_items", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (billingProvider == BillingProvider.Azure)
                    {
                        lineItem = new UsageBasedLineItem();
                    }
                    else if (billingProvider == BillingProvider.AzureDataMarket)
                    {
                        lineItem = new AzureDataMarketLineItem();
                    }
                    else if (billingProvider == BillingProvider.Office)
                    {
                        lineItem = new LicenseBasedLineItem();
                    }
                    else if (billingProvider == BillingProvider.OneTime)
                    {
                        lineItem = new OneTimeInvoiceLineItem();
                    }
                }
            }
            else
            {
                if (billingProvider == BillingProvider.Azure)
                {
                    lineItem = new DailyUsageLineItem();
                }
                else if (billingProvider == BillingProvider.AzureDataMarket)
                {
                    lineItem = new AzureDataMarketDailyUsageLineItem();
                }
            }

            if (lineItem == null)
            {
                throw new JsonSerializationException($"InvoiceLineItemConverter cannot deserialize invoice line items with type: '{invoiceLineItemType}' && billing provider: '{billingProviderValue}'");
            }

            serializer.Populate(json.CreateReader(), lineItem);

            return lineItem;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}