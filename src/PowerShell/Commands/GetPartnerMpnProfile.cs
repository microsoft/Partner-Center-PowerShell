// -----------------------------------------------------------------------
// <copyright file="GetPartnerMpnProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Authentication;
    using Models.Partners;
    using PartnerCenter.Models.Partners;

    [Cmdlet(VerbsCommon.Get, "PartnerMpnProfile"), OutputType(typeof(PSMpnProfile))]
    public class GetPartnerMpnProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the MPN identifier.
        /// </summary>
        [Parameter(HelpMessage = "The partner's MPN identifier.", Mandatory = false)]
        [ValidateNotNull]
        public string MpnId { get; set; }

        /// <summary>
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            MpnProfile profile;

            if (string.IsNullOrEmpty(MpnId))
            {
                profile = Partner.Profiles.MpnProfile.GetAsync().GetAwaiter().GetResult();
            }
            else
            {
                profile = Partner.Profiles.MpnProfile.GetAsync(MpnId).GetAwaiter().GetResult();
            }

            WriteObject(new PSMpnProfile(profile));
        }
    }
}