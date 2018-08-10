// -----------------------------------------------------------------------
// <copyright file="CustomerConverTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Converters
{
    using Converts;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Customers;
    using PowerShell.Commands;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomerConverTests
    {
        [TestMethod]
        public void ConvertTest()
        {
            Customer customer;
            SetPartnerCustomer cmdlet;

            try
            {
                cmdlet = new SetPartnerCustomer
                {
                    BillingAddressLine1 = "12012 Sunset Hills Road",
                    BillingAddressLine2 = "Suite 100",
                    BillingAddressCity = "Reston",
                    BillingAddressCountry = "US",
                    BillingAddressPostalCode = "20190",
                    BillingAddressRegion = "Test-Value",
                    BillingAddressState = "VA",
                    Name = "Microsoft MTC"
                };

                customer = new Customer
                {
                    BillingProfile = new CustomerBillingProfile
                    {
                        DefaultAddress = new Address
                        {
                            AddressLine1 = "1 Microsoft Way",
                            AddressLine2 = "Second Line",
                            City = "Redmond",
                            Country = "US",
                            PostalCode = "98052",
                            State = "WA"
                        }
                    }
                };

                new CustomerConverter(cmdlet, customer).Convert();

                Assert.AreEqual("12012 Sunset Hills Road", customer.BillingProfile.DefaultAddress.AddressLine1);
                Assert.AreEqual("Suite 100", customer.BillingProfile.DefaultAddress.AddressLine2);
                Assert.AreEqual("Reston", customer.BillingProfile.DefaultAddress.City);
                Assert.AreEqual("US", customer.BillingProfile.DefaultAddress.Country);
                Assert.AreEqual("20190", customer.BillingProfile.DefaultAddress.PostalCode);
                Assert.AreEqual("Test-Value", customer.BillingProfile.DefaultAddress.Region);
                Assert.AreEqual("VA", customer.BillingProfile.DefaultAddress.State);
                Assert.AreEqual("Microsoft MTC", customer.BillingProfile.CompanyName);
            }
            finally
            {
                cmdlet = null;
                customer = null;
            }
        }
    }
}