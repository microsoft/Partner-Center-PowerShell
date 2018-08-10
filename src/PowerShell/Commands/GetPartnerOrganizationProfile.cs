// -----------------------------------------------------------------------
// <copyright file="GetPartnerOrganizationProfile.cs" company="Microsoft">
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
    [Cmdlet(VerbsCommon.Get, "PartnerOrganizationProfile"), OutputType(typeof(PSOrganizationProfile))]
    public class GetPartnerOrganizationProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            OrganizationProfile profile;

            try
            {
                profile = Partner.Profiles.OrganizationProfile.Get();

                WriteObject(new PSOrganizationProfile(profile));
            }
            finally
            {
                profile = null;
            }
        }
    }
}