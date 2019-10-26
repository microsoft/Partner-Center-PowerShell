﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Properties;

    /// <summary>
    /// Removes a customer from the partner (this is only support within the integration sandbox).
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerSandboxCustomer", ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemovePartnerSandboxCustomer : PartnerCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true, Position = 0)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RemovePartnerSandboxCustomerWhatIf, CustomerId)))
            {
                Partner.Customers[CustomerId].DeleteAsync().GetAwaiter().GetResult();
                WriteObject(true);
            }
        }
    }
}