// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Partners;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Partners;
    using Validations;

    /// <summary>
    /// Sets the partner organization profile in Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerOrganizationProfile", SupportsShouldProcess = true), OutputType(typeof(PSOrganizationProfile))]
    public class SetPartnerOrganizationProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The company name.")]
        [ValidateNotNullOrEmpty]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The first line of the address.")]
        [ValidateNotNullOrEmpty]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The second line of the address.")]
        [ValidateNotNullOrEmpty]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The city portion of the address.")]
        [ValidateNotNullOrEmpty]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country portion of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The country portion of the address.")]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the preferred culture of the organization.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The preferred organization culture.")]
        [ValidateNotNullOrEmpty]
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicates whether the additional client side validation should be disabled.
        /// </summary>
        [Parameter(HelpMessage = "A flag that indicates whether the additional client side validation should be disabled.", Mandatory = false)]
        public SwitchParameter DisableValidation { get; set; }

        /// <summary>
        /// Gets or sets the email address of the organization contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The organization technical contact's email address.")]
        [ValidatePattern(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", Options = RegexOptions.IgnoreCase)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name of the primary organization contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The primary organization contact's first name.")]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the preferred language of the organization.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The primary organization language.")]
        [ValidateNotNullOrEmpty]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the last name of the primary organization contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The primary organization contact's last name.")]
        [ValidateNotNullOrEmpty]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the primary organization contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The primary organization contact's phone number.")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The postal code of the address.")]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the state portion of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The state portion of the address.")]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            OrganizationProfile profile;
            IValidator<Address> validator;

            if (ShouldProcess("Updates the partner's organization profile"))
            {
                profile = Partner.Profiles.OrganizationProfile.GetAsync().GetAwaiter().GetResult();

                profile.CompanyName = UpdateValue(CompanyName, profile.CompanyName);
                profile.Email = UpdateValue(Email, profile.Email);
                profile.Language = UpdateValue(Language, profile.Language);
                profile.Culture = UpdateValue(Culture, profile.Culture);

                profile.DefaultAddress.AddressLine1 = UpdateValue(AddressLine1, profile.DefaultAddress.AddressLine1);
                profile.DefaultAddress.AddressLine2 = UpdateValue(AddressLine2, profile.DefaultAddress.AddressLine2);
                profile.DefaultAddress.City = UpdateValue(City, profile.DefaultAddress.City);
                profile.DefaultAddress.Country = UpdateValue(Country, profile.DefaultAddress.Country);
                profile.DefaultAddress.PostalCode = UpdateValue(PostalCode, profile.DefaultAddress.PostalCode);
                profile.DefaultAddress.State = UpdateValue(State, profile.DefaultAddress.State);
                profile.DefaultAddress.FirstName = UpdateValue(FirstName, profile.DefaultAddress.FirstName);
                profile.DefaultAddress.LastName = UpdateValue(LastName, profile.DefaultAddress.LastName);
                profile.DefaultAddress.PhoneNumber = UpdateValue(PhoneNumber, profile.DefaultAddress.PhoneNumber);

                if (!DisableValidation.ToBool())
                {
                    validator = new AddressValidator(Partner);

                    if (!validator.IsValid(profile.DefaultAddress, d => WriteDebug(d)))
                    {
                        throw new PSInvalidOperationException("The specified address is invalid. Please verify the address and try again.");
                    }
                }

                profile = Partner.Profiles.OrganizationProfile.UpdateAsync(profile).GetAwaiter().GetResult();
                WriteObject(new PSOrganizationProfile(profile));
            }
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