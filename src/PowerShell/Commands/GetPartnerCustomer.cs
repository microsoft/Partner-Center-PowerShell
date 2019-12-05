// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Enumerators;
    using Models.Authentication;
    using Models.Customers;
    using Network;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Customers;
    using PartnerCenter.Models.Query;

    /// <summary>
    /// Get a customer, or a list of customers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomer", DefaultParameterSetName = "ById")]
    [OutputType(typeof(PSCustomer))]
    public class GetPartnerCustomer : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the optional customer identifier.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then a list of customers will be returned.
        /// When it is specified then the customer associated with the identifier will be returned.
        /// </remarks>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = false, ParameterSetName = "ById", Position = 0)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        [Parameter(HelpMessage = "The domain assigned to the Azure AD tenant of the customer.", Mandatory = true, ParameterSetName = "ByDomain")]
        [ValidateNotNull]
        public string Domain { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () => 
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync();
                IResourceCollectionEnumerator<SeekBasedResourceCollection<Customer>> customersEnumerator;
                List<Customer> customers = new List<Customer>();
                SeekBasedResourceCollection<Customer> seekCustomers;

                if (!string.IsNullOrEmpty(CustomerId))
                {
                    WriteObject(new PSCustomer(await partner.Customers[CustomerId].GetAsync().ConfigureAwait(false)));
                    return;
                }
                if (ParameterSetName.Equals("ByDomain", StringComparison.InvariantCultureIgnoreCase))
                {
                    Graph.GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as Graph.GraphServiceClient;
                    client.AuthenticationProvider = new GraphAuthenticationProvider();

                    Graph.IGraphServiceContractsCollectionPage data = await client.Contracts.Request().Filter($"defaultDomainName eq '{Domain}'").GetAsync().ConfigureAwait(false);

                    if (data.CurrentPage != null && data.CurrentPage.Any())
                    {
                        Customer customer = await partner.Customers.ById(data.CurrentPage[0].CustomerId.ToString()).GetAsync().ConfigureAwait(false);
                        WriteObject(new PSCustomer(customer));
                        return;
                    }

                    seekCustomers = await partner.Customers.QueryAsync(
                        QueryFactory.BuildSimpleQuery(new SimpleFieldFilter(
                            CustomerSearchField.Domain.ToString(),
                            FieldFilterOperation.StartsWith,
                            Domain))).ConfigureAwait(false);
                }
                else
                {
                    seekCustomers = await partner.Customers.GetAsync().ConfigureAwait(false);
                }

                customersEnumerator = partner.Enumerators.Customers.Create(seekCustomers);

                while (customersEnumerator.HasValue)
                {
                    customers.AddRange(customersEnumerator.Current.Items);
                    await customersEnumerator.NextAsync().ConfigureAwait(false);
                }

                WriteObject(customers.Select(c => new PSCustomer(c)), true);
            }, true);
        }
    }
}