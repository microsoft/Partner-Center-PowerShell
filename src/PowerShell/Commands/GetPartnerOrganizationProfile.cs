// -----------------------------------------------------------------------
// <copyright file="GetPartnerOrganizationProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Authentication;
    using Models.Partners;

    /// <summary>
    /// Gets the partner organization profile from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerOrganizationProfile"), OutputType(typeof(PSOrganizationProfile))]
    public class GetPartnerOrganizationProfile : PartnerPSCmdlet
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
            WriteObject(new PSOrganizationProfile(Partner.Profiles.OrganizationProfile.GetAsync().GetAwaiter().GetResult()));
        }
    }
}