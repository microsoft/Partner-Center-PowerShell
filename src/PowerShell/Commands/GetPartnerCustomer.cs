// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Enumerators;
    using Models.Customers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Customers;

    /// <summary>
    /// Get a customer, or a list of customers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomer"), OutputType(typeof(PSCustomer))]
    public class GetPartnerCustomer : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the optional customer identifier.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then a list of customers will be returned.
        /// When it is specified then the customer associated with the identifier will be returned.
        /// </remarks>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = false, Position = 0)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(CustomerId))
            {
                GetCustomers();
            }
            else
            {
                WriteObject(new PSCustomer(Partner.Customers[CustomerId].Get()));
            }
        }

        /// <summary>
        /// Gets a list of customers from Partner Center.
        /// </summary>
        /// <remarks>
        /// The maximum number of customers returned by the Partner Center API in a single call is 500. 
        /// So, we will need to use an enumerator to return all the available customers.
        /// </remarks>
        private void GetCustomers()
        {
            IResourceCollectionEnumerator<SeekBasedResourceCollection<Customer>> customersEnumerator;
            List<Customer> customers;
            SeekBasedResourceCollection<Customer> seekCustomers;

            customers = new List<Customer>();

            seekCustomers = Partner.Customers.Get();
            customersEnumerator = Partner.Enumerators.Customers.Create(seekCustomers);

            while (customersEnumerator.HasValue)
            {
                customers.AddRange(customersEnumerator.Current.Items);
                customersEnumerator.Next();
            }

            WriteObject(customers.Select(c => new PSCustomer(c)), true);

        }
    }
}