﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Properties;

    /// <summary>
    /// Registers an existing Subscription so that it is enabled for ordering Azure Reserved VM Instances. 
    /// </summary>
    [Cmdlet(VerbsCommon.New, "PartnerCustomerSubscriptionRegistration", SupportsShouldProcess = true), OutputType(typeof(string))]
    public class NewPartnerCustomerSubscriptionRegistration : PartnerCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the required subscription identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the subscription.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(
                CultureInfo.CurrentCulture,
                Resources.SubscriptionRegistrationWhatIf,
                SubscriptionId,
                CustomerId)))
            {
                WriteObject(Partner.Customers[CustomerId].Subscriptions[SubscriptionId].Registration.RegisterAsync().ConfigureAwait(false).GetAwaiter().GetResult());
            }
        }
    }
}