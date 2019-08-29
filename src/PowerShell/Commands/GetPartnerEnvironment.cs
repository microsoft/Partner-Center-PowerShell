// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;

    /// <summary>
    /// Command that gets the available environments.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerEnvironment")]
    [OutputType(typeof(PSPartnerEnvironment))]
    public class GetPartnerEnvironment : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the environment name.
        /// </summary>
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the environment.")]
        [ValidateSet(nameof(EnvironmentName.AzureChinaCloud), nameof(EnvironmentName.AzureCloud), nameof(EnvironmentName.AzureGermanCloud), nameof(EnvironmentName.AzurePPE), nameof(EnvironmentName.AzureUSGovernment))]
        public string Name { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            IList<PSPartnerEnvironment> environments = new List<PSPartnerEnvironment>();

            foreach (KeyValuePair<EnvironmentName, PartnerEnvironment> env in PartnerEnvironment.PublicEnvironments)
            {
                environments.Add(new PSPartnerEnvironment(env.Value)
                {
                    Name = env.Key.ToString()
                });
            }

            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(environments, true);
            }
            else
            {
                WriteObject(environments.Single(e => e.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase)));
            }
        }
    }
}