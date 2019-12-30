// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Models.Agreements;
    using Models.Authentication;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Agreements;

    /// <summary>
    /// Gets a metadata for the available agreements.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerAgreementDetail")]
    [OutputType(typeof(PSAgreementMetaData))]
    public class GetPartnerAgreementDetail : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the agreement type. 
        /// </summary>
        [Parameter(HelpMessage = "The type of agreement of being requested.", Mandatory = false)]
        [ValidateSet("All", "MicrosoftCloudAgreement", "MicrosoftCustomerAgreement")]
        public string AgreementType { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<AgreementMetaData> agreements;

                if (string.IsNullOrEmpty(AgreementType))
                {
                    agreements = await partner.AgreementDetails.GetAsync(CancellationToken).ConfigureAwait(false);
                }
                else if (AgreementType.Equals("All", StringComparison.InvariantCultureIgnoreCase))
                {
                    agreements = await partner.AgreementDetails.ByAgreementType("*").GetAsync(CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    agreements = await partner.AgreementDetails.ByAgreementType(AgreementType).GetAsync(CancellationToken).ConfigureAwait(false);
                }

                WriteObject(agreements.Items.Select(a => new PSAgreementMetaData(a)), true);

            }, true);
        }
    }
}