// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.ManagedServices;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ManagedServices;

    /// <summary>
    /// Gets the customer's managed services from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerManagedService")]
    [OutputType(typeof(PSManagedService))]
    public class GetPartnerCustomerManagedService : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the managed service identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A string that identifies the managed service.")]
        [ValidateNotNullOrEmpty]
        public string ManagedServiceId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<ManagedService> managedServices = await partner.Customers.ById(CustomerId).ManagedServices.GetAsync(CancellationToken).ConfigureAwait(false);

                if (string.IsNullOrEmpty(ManagedServiceId))
                {
                    WriteObject(managedServices.Items.Select(s => new PSManagedService(s)), true);
                }
                else
                {
                    WriteObject(managedServices.Items.Where(s => s.Id == ManagedServiceId).Select(i => new PSManagedService(i)), true);
                }
            }, true);
        }
    }
}