// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models;
    using PartnerCenter.Models.DevicesDeployment;
    using Properties;

    /// <summary>
    /// Creates a new configuration policies for the specified customer identifier.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerCustomerConfigurationPolicy", SupportsShouldProcess = true), OutputType(typeof(PSConfigurationPolicy))]
    public class SetPartnerCustomerConfigurationPolicy : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the required policy identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier for the policy.")]
        [ValidateNotNullOrEmpty]
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or sets the policy name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Policy name for the policy.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the optional policy description.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Description for the policy.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the optional skip privacy setup policy setting.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enables or disables the Remove OEM preinstalls policy.")]
        public bool RemoveOemPreinstalls { get; set; }

        /// <summary>
        /// Gets or sets the optional Disable local admin account in setup policy setting.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enables or disables the Disable local admin account in setup policy.")]
        public bool OobeUserNotLocalAdmin { get; set; }

        /// <summary>
        /// Gets or sets the optional Automatically skip pages in setup policy setting.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enables or disables the Automatically skip pages in setup policy.")]
        public bool SkipExpressSettings { get; set; }

        /// <summary>
        /// Gets or sets the optional Skip end user license agreement (EULA) policy setting.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enables or disables the Skip end user license agreement (EULA) policy.")]
        public bool SkipEula { get; set; }

        /// <summary>
        /// Gets or sets the optional Skip end registration policy setting.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Enables or disables the Skip OEM registration policy.")]
        public bool SkipOemRegistration { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ConfigurationPolicy configurationPolicy = GetCustomerPolicy(CustomerId, PolicyId);
            List<PolicySettingsTypes> policySettings = new List<PolicySettingsTypes>();

            if (!ShouldProcess(Resources.SetPartnerCustomerConfigurationPolicyWhatIf, PolicyId))
            {
                return;
            }

            if (OobeUserNotLocalAdmin)
            {
                policySettings.Add(PolicySettingsTypes.OobeUserNotLocalAdmin);
            }

            if (SkipEula)
            {
                policySettings.Add(PolicySettingsTypes.SkipEula);
            }

            if (SkipExpressSettings)
            {
                policySettings.Add(PolicySettingsTypes.SkipExpressSettings);
            }

            if (RemoveOemPreinstalls)
            {
                policySettings.Add(PolicySettingsTypes.RemoveOemPreinstalls);
            }

            if (SkipOemRegistration)
            {
                policySettings.Add(PolicySettingsTypes.SkipOemRegistration);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                configurationPolicy.Name = Name;
            }

            if (!string.IsNullOrEmpty(Description))
            {
                configurationPolicy.Description = Description;
            }

            configurationPolicy.PolicySettings = policySettings;

            ConfigurationPolicy devicePolicy = Partner.Customers[CustomerId].ConfigurationPolicies[PolicyId].PatchAsync(configurationPolicy).GetAwaiter().GetResult();
            WriteObject(new PSConfigurationPolicy(devicePolicy));
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
        private ConfigurationPolicy GetCustomerPolicy(string customerId, string policyId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
            policyId.AssertNotEmpty(nameof(policyId));

            return Partner.Customers[customerId].ConfigurationPolicies[policyId].GetAsync().GetAwaiter().GetResult();
        }
    }
}