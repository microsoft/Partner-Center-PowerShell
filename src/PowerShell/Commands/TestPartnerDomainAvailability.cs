// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;

    /// <summary>
    /// Check to see if the specified domain name is available.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "PartnerDomainAvailability")]
    [OutputType(typeof(bool))]
    public class TestPartnerDomainAvailability : PartnerAsyncCmdlet
    {
        /// <summary>
        /// The domain name to be checked.
        /// </summary>
        [Parameter(HelpMessage = "A string that identifies the domain to check, e.g. \"contoso.onmicrosoft.com\". There is a 27 characters maximum for the domain prefix.'", Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        [ValidateLength(17, 43)]
        public string Domain { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                bool exists = await partner.Domains.ByDomain(Domain).ExistsAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(!exists);
            }, true);
        }
    }
}