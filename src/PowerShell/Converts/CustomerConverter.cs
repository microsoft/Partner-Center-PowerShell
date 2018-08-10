// -----------------------------------------------------------------------
// <copyright file="CustomerConverter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Converts
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using PartnerCenter.Models.Customers;

    public class CustomerConverter
    {
        private readonly Dictionary<Func<string>, Action<string>> mappings;

        public CustomerConverter(SetPartnerCustomer setPSCustomer, Customer customer)
        {
            mappings = new Dictionary<Func<string>, Action<string>>
            {
                {
                    () => setPSCustomer.BillingAddressCity, c => customer.BillingProfile.DefaultAddress.City = c
                },
                {
                    () => setPSCustomer.BillingAddressLine1, c => customer.BillingProfile.DefaultAddress.AddressLine1 = c
                },
                {
                    () => setPSCustomer.BillingAddressLine2, c => customer.BillingProfile.DefaultAddress.AddressLine2 = c
                },
                {
                    () => setPSCustomer.BillingAddressCountry, c => customer.BillingProfile.DefaultAddress.Country = c
                },
                {
                    () => setPSCustomer.BillingAddressPostalCode, c => customer.BillingProfile.DefaultAddress.PostalCode = c
                },
                {
                    () => setPSCustomer.BillingAddressRegion, c => customer.BillingProfile.DefaultAddress.Region = c
                },
                {
                    () => setPSCustomer.BillingAddressState, c => customer.BillingProfile.DefaultAddress.State = c
                },
                {
                    () => setPSCustomer.Name, c => customer.BillingProfile.CompanyName = c
                }
            };
        }

        public void Convert()
        {
            foreach (KeyValuePair<Func<string>, Action<string>> element in mappings)
            {
                if (!string.IsNullOrEmpty(element.Key.Invoke()))
                {
                    element.Value(element.Key.Invoke());
                }
            }
        }
    }
}