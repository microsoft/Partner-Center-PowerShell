// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Partners;

    /// <summary>
    /// Gets the partner organization profile from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerLegalProfile"), OutputType(typeof(PSLegalBusinessProfile))]
    public class GetPartnerLegalProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(new PSLegalBusinessProfile(Partner.Profiles.LegalBusinessProfile.GetAsync().GetAwaiter().GetResult()));
        }
    }
}