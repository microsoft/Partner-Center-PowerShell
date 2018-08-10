// -----------------------------------------------------------------------
// <copyright file="GetPartnerAgreementDetail.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Agreements;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Agreements;

    /// <summary>
    /// Gets a metadata for the available agreements.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerAgreementDetail"), OutputType(typeof(PSAgreementMetaData))]
    public class GetPartnerAgreementDetail : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<AgreementMetaData> agreements;

            try
            {
                agreements = Partner.AgreementDetails.Get();

                WriteObject(agreements.Items.Select(a => new PSAgreementMetaData(a)), true);
            }
            finally
            {
                agreements = null;
            }
        }
    }
}