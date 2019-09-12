// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Partners;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Sets the partner support profile in Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerSupportProfile", SupportsShouldProcess = true), OutputType(typeof(PSSupportProfile))]
    public class SetPartnerSupportProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the email address of the support contact.
        /// </summary>
        [Parameter(HelpMessage = "The email address of the support contact.", Mandatory = false)]
        [ValidatePattern(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", Options = RegexOptions.IgnoreCase)]
        public string SupportEmail { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the support contact.
        /// </summary>
        [Parameter(HelpMessage = "The phone number of the support contact.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string SupportPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the website where customers can get support.
        /// </summary>
        [Parameter(HelpMessage = "The website where customers can get support.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string SupportWebsite { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            SupportProfile profile;

            profile = Partner.Profiles.SupportProfile.GetAsync().GetAwaiter().GetResult();

            profile.Email = UpdateValue(SupportEmail, profile.Email);
            profile.Telephone = UpdateValue(SupportPhoneNumber, profile.Telephone);
            profile.Website = UpdateValue(SupportWebsite, profile.Website);

            profile = Partner.Profiles.SupportProfile.UpdateAsync(profile).GetAwaiter().GetResult();

            WriteObject(new PSSupportProfile(profile));
        }

        private static string UpdateValue(string input, string output)
        {
            string newValue = output;

            if (!string.IsNullOrEmpty(input) && !input.Equals(output, StringComparison.OrdinalIgnoreCase))
            {
                newValue = input;
            }

            return newValue;
        }
    }
}