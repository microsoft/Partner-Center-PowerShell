// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Properties;

    /// <summary>
    /// Return a list of configuration policies or a specific configration policy for the specified customer identifier.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerCustomerConfigurationPolicy"), OutputType(typeof(bool))]
    public class RemovePartnerCustomerConfigurationPolicy : PartnerPSCmdlet
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
        [Parameter(Mandatory = true, HelpMessage = "The identifier for the configuration policy.")]
        [ValidateNotNullOrEmpty]
        public string PolicyId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!ShouldProcess(Resources.RemovePartnerCustomerConfigurationPolicyWhatIf, PolicyId))
            {
                return;
            }

            Partner.Customers[CustomerId].ConfigurationPolicies[PolicyId].DeleteAsync().GetAwaiter().GetResult();
            WriteObject(true);
        }
    }
}