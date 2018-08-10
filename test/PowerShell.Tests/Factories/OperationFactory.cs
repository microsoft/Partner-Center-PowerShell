// -----------------------------------------------------------------------
// <copyright file="OperationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Newtonsoft.Json;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Customers;

    public class OperationFactory
    {
        /// <summary>
        /// Singleton instance of the <see cref="OperationFactory" /> class.
        /// </summary>
        private static readonly Lazy<OperationFactory> instance = new Lazy<OperationFactory>();

        /// <summary>
        /// Gets an instance of the <see cref="OperationFactory" /> class.
        /// </summary>
        public static OperationFactory Instance => instance.Value;

        /// <summary>
        /// Gets the specified resource by desearilizing the recorded session.
        /// </summary>
        /// <typeparam name="T">Type of resource to be returned.</typeparam>
        /// <param name="identity">Identity of the test being performed.</param>
        /// <returns>An object that represents the requeested object.</returns>
        public T GetResource<T>([CallerMemberName]string identity = "") => JsonConvert.DeserializeObject<T>(
                File.ReadAllText(
                    Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        "SessionRecords",
                        $"{identity}.json")));

        /// <summary>
        /// Gets a customer for unit testing.
        /// </summary>
        /// <returns>A customer for unit testing.</returns>
        public Customer GetCustomer() => new Customer
        {
            BillingProfile = new CustomerBillingProfile
            {
                DefaultAddress = new Address
                {
                    AddressLine1 = "1 Microsoft Way",
                    City = "Redmond",
                    Country = "US",
                    PostalCode = "98052",
                    State = "WA"
                }
            },
            CompanyProfile = new CustomerCompanyProfile
            {
                CompanyName = "Contoso",
                Domain = "contoso.onmicrosoft.com"
            },
            Id = "46a62ece-10ad-42e5-b3f1-b2ed53e6fc08"
        };

        /// <summary>
        /// Gets a customer billing profile for unit testing.
        /// </summary>
        /// <returns>A customer billing profile for unit testing.</returns>
        public CustomerBillingProfile GetCustomerBillingProfile() => new CustomerBillingProfile
        {
            CompanyName = "Contoso",
            Culture = "en-US",
            DefaultAddress = new Address
            {
                AddressLine1 = "700 Bellevue Way NE",
                City = "Redmond",
                Country = "US",
                PostalCode = "98004",
                State = "WA"
            },
            Email = "jdoe@contoso.com",
            FirstName = "John",
            Language = "en",
            LastName = "Doe"
        };

        /// <summary>
        /// Gets a list of customers for unit testing.
        /// </summary>
        /// <returns>A resource collection of customer used for unit testing.</returns>
        public SeekBasedResourceCollection<Customer> GetCustomers() => new SeekBasedResourceCollection<Customer>(new List<Customer>
        {
            {
                new Customer
                {
                    BillingProfile = new CustomerBillingProfile
                    {
                        DefaultAddress = new Address
                        {
                            AddressLine1 = "1 Microsoft Way",
                            City = "Redmond",
                            Country = "US",
                            PostalCode = "98052",
                            State = "WA"
                        }
                    },
                    CompanyProfile = new CustomerCompanyProfile
                    {
                        CompanyName = "Contoso",
                        Domain = "contoso.onmicrosoft.com"
                    },
                    Id = "46a62ece-10ad-42e5-b3f1-b2ed53e6fc08"
                }
            },
            {
                new Customer
                {
                    BillingProfile = new CustomerBillingProfile
                    {
                        DefaultAddress = new Address
                        {
                            AddressLine1 = "700 Bellevue Way NE",
                            City = "Redmond",
                            Country = "US",
                            PostalCode = "98004",
                            State = "WA"
                        }
                    },
                    CompanyProfile = new CustomerCompanyProfile
                    {
                        CompanyName = "TailSpin Toys",
                        Domain = "tailspintoys.onmicrosoft.com"
                    },
                    Id = "f28ec9a4-fbb6-43e2-a634-c4e0bbb44842"
                }
            }
        });

        /// <summary>
        /// Gets a customer for unit testing the creation of a customer.
        /// </summary>
        /// <returns>A customer for unit testing.</returns>
        public Customer GetNewCustomer() => new Customer
        {
            BillingProfile = new CustomerBillingProfile
            {
                CompanyName = "Tailspin Toys",
                Culture = "en-US",
                DefaultAddress = new Address
                {
                    AddressLine1 = "12012 Sunset Hills Rd",
                    City = "Reston",
                    Country = "US",
                    PostalCode = "20190",
                    State = "VA"
                },
                Email = "hugh@tailspintoys.com",
                FirstName = "Hugh",
                LastName = "Williams",
                Language = "en"
            },
            CompanyProfile = new CustomerCompanyProfile
            {
                CompanyName = "TailSpin Toys",
                Domain = "tailspintoys.onmicrosoft.com",
                TenantId = "f28ec9a4-fbb6-43e2-a634-c4e0bbb44842"
            },
            Id = "f28ec9a4-fbb6-43e2-a634-c4e0bbb44842",
            RelationshipToPartner = CustomerPartnerRelationship.None,
            UserCredentials = new UserCredentials
            {
                Password = "=;;n.=s9Z",
                UserName = "admin"
            }
        };
    }
}