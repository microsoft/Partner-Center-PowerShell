// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PartnerCenter.Models.Compliance;

    [Cmdlet(VerbsCommon.Get, "PartnerAgreementStatus", DefaultParameterSetName = "ByTenantId")]
    [OutputType(typeof(AgreementSignatureStatus))]
    public class GetPartnerAgreementStatus : PartnerCmdlet
    {
        /// <summary>
        /// Gets or sets the Microsoft Partner Network (MPN) identifier.
        /// </summary>
        [Parameter(HelpMessage = "The Microsoft Partner Network (MPN) identifier for the partner.", Mandatory = true, ParameterSetName = "ByMpnId", Position = 0)]
        public string MpnId { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Parameter(HelpMessage = "The tenant identifier for the partner.", Mandatory = true, ParameterSetName = "ByTenantId", Position = 0)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string TenantId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(Partner.Compliance.AgreementSignatureStatus.GetAsync(MpnId, TenantId, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }
    }
}