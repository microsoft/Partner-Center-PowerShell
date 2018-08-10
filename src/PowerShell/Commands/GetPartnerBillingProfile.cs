// -----------------------------------------------------------------------
// <copyright file="GetPartnerBillingProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Partners;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Gets the partner billing profile from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerBillingProfile"), OutputType(typeof(PSBillingProfile))]
    public class GetPartnerBillingProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            BillingProfile profile;

            try
            {
                profile = Partner.Profiles.BillingProfile.Get();

                WriteObject(new PSBillingProfile(profile));
            }
            finally
            {
                profile = null;
            }
        }
    }
}