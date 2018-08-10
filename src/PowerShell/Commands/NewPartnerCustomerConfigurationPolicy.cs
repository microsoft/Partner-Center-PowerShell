// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerConfigurationPolicy.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Models;
    using PartnerCenter.Models.DevicesDeployment;
    using PartnerCenter.PowerShell.Properties;

    /// <summary>
    /// Creates a new configuration policies for the specified customer identifier.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "PartnerCustomerConfigurationPolicy", SupportsShouldProcess = true), OutputType(typeof(PSConfigurationPolicy))]
    public class NewPartnerCustomerConfigurationPolicy : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the required policy name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Policy name for the new policy.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the optional policy description.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Description for the new policy.")]
        [ValidateNotNullOrEmpty]
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
            if (!ShouldProcess(Resources.NewPartnerCustomerConfigurationPolicyWhatIf)) return;

            List<PolicySettingsType> policySettings = new List<PolicySettingsType>();
            if (OobeUserNotLocalAdmin) policySettings.Add(PolicySettingsType.OobeUserNotLocalAdmin);
            if (SkipEula) policySettings.Add(PolicySettingsType.SkipEula);
            if (SkipExpressSettings) policySettings.Add(PolicySettingsType.SkipExpressSettings);
            if (RemoveOemPreinstalls) policySettings.Add(PolicySettingsType.RemoveOemPreinstalls);
            if (SkipOemRegistration) policySettings.Add(PolicySettingsType.SkipOemRegistration);

            ConfigurationPolicy configurationPolicy = new ConfigurationPolicy
            {
                Name = Name,
                Description = Description,
                PolicySettings = policySettings
            };

            ConfigurationPolicy devicePolicy;
            CustomerId.AssertNotEmpty(nameof(CustomerId));

            try
            {
                devicePolicy = Partner.Customers[CustomerId].ConfigurationPolicies.Create(configurationPolicy);
                WriteObject(new PSConfigurationPolicy(devicePolicy));
            }
            finally
            {
                devicePolicy = null;
            }
        }
    }
}