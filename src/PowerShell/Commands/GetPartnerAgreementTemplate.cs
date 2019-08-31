// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Agreements;

    [Cmdlet(VerbsCommon.Get, "PartnerAgreementTemplate")]
    [OutputType(typeof(PSAgreementTemplate))]
    public class GetPartnerAgreementTemplate : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets unique identifier of the agreement type. 
        /// </summary>
        [Parameter(HelpMessage = "The unique identifier of the agreement type.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TemplateId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(new PSAgreementTemplate(Partner.AgreementDetails[TemplateId].Templates.GetAsync().ConfigureAwait(false).GetAwaiter().GetResult()));
        }
    }
}