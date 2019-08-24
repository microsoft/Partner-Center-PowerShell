// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Return a list of configuration policies or a specific configration policy for the specified customer identifier.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerConfigurationPolicy"), OutputType(typeof(PSConfigurationPolicy))]
    public class GetPartnerCustomerConfigurationPolicy : PartnerPSCmdlet
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
            if (string.IsNullOrEmpty(PolicyId))
            {
                GetCustomerPolicies(CustomerId);
            }
            else
            {
                GetCustomerPolicy(CustomerId, PolicyId);
            }
        }

        /// <summary>
        /// Gets the configuration policies for the specified customer from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetCustomerPolicies(string customerId)
        {
            IEnumerable<ConfigurationPolicy> devicePolicy;
            customerId.AssertNotEmpty(nameof(customerId));

            devicePolicy = Partner.Customers[customerId].ConfigurationPolicies.GetAsync().GetAwaiter().GetResult().Items;
            WriteObject(devicePolicy.Select(d => new PSConfigurationPolicy(d)), true);
        }

        /// <summary>
        /// Gets the specified policy from the specified customer from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="policyId">Identifier of the policy.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// or
        /// <paramref name="policyId"/> is empty or null.
        /// </exception>
        private void GetCustomerPolicy(string customerId, string policyId)
        {
            ConfigurationPolicy devicePolicy;

            customerId.AssertNotEmpty(nameof(customerId));
            policyId.AssertNotEmpty(nameof(policyId));

            devicePolicy = Partner.Customers[customerId].ConfigurationPolicies[policyId].GetAsync().GetAwaiter().GetResult();
            WriteObject(new PSConfigurationPolicy(devicePolicy), true);
        }
    }
}