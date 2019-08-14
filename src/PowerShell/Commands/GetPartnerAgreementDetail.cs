// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Authentication;
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
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<AgreementMetaData> agreements = Partner.AgreementDetails.GetAsync().GetAwaiter().GetResult();

            WriteObject(agreements.Items.Select(a => new PSAgreementMetaData(a)), true);
        }
    }
}