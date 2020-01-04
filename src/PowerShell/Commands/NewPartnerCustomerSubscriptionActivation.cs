// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Subscriptions;
    using Properties;

    /// <summary>
    /// Activates a third-party subscription in the integration sandbox. 
    /// </summary>
    [Cmdlet(VerbsCommon.New, "PartnerCustomerSubscriptionActivation", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSubscriptionActivationResult))]
    public class NewPartnerCustomerSubscriptionActivation : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                if (ShouldProcess(string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.SubscriptionActivationWhatIf,
                    SubscriptionId,
                    CustomerId)))
                {
                    IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                    WriteObject(await partner.Customers[CustomerId].Subscriptions[SubscriptionId].ActivateAsync(CancellationToken).ConfigureAwait(false));
                }
            }, true);

        }
    }
}
