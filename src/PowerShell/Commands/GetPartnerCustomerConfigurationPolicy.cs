// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models;
    using Models.Authentication;
    using PartnerCenter.Models;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Return a list of configuration policies or a specific configration policy for the specified customer identifier.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerConfigurationPolicy")]
    [OutputType(typeof(PSConfigurationPolicy))]
    public class GetPartnerCustomerConfigurationPolicy : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the optional configuration policy identifier.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then a list of all policies for the specified customer will be returned.
        /// When it is specified then the policy associated with the identifier will be returned.
        /// </remarks>
        [Parameter(Mandatory = false, HelpMessage = "The identifier for the configuration policy.")]
        [ValidateNotNullOrEmpty]
        public string PolicyId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {

            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                if (string.IsNullOrEmpty(PolicyId))
                {
                    ResourceCollection<ConfigurationPolicy> policies = await partner.Customers[CustomerId].ConfigurationPolicies.GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteObject(policies.Items.Select(d => new PSConfigurationPolicy(d)), true);
                }
                else
                {
                    ConfigurationPolicy policy = await partner.Customers[CustomerId].ConfigurationPolicies[PolicyId].GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteObject(policy);
                }
            }, true);
        }
    }
}