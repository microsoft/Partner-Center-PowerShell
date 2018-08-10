// -----------------------------------------------------------------------
// <copyright file="GetPartnerLegalProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Partners;
    using PartnerCenter.Models.Partners;

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
            LegalBusinessProfile profile;

            try
            {
                profile = Partner.Profiles.LegalBusinessProfile.Get();

                WriteObject(new PSLegalBusinessProfile(profile));
            }
            finally
            {
                profile = null;
            }
        }
    }
}