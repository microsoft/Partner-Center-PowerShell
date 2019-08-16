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
    using Properties;
    using Validations;

    /// <summary>
    /// Sets the partner legal profile in Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerLegalProfile", SupportsShouldProcess = true), OutputType(typeof(PSLegalBusinessProfile))]
    public class SetPartnerLegalProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The first line of the address.")]
        [ValidateNotNullOrEmpty]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The second line of the adress.")]
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
        /// Gets or sets a flag that indicates whether the additional client side validation should be disabled.
        /// </summary>
        [Parameter(HelpMessage = "A flag that indicates whether the additional client side validation should be disabled.", Mandatory = false)]
        public SwitchParameter DisableValidation { get; set; }

        /// <summary>
        /// Gets or sets the email address of the primary billing contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The email address of the primary billing contact.")]
        [ValidatePattern(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", Options = RegexOptions.IgnoreCase)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name of the primary billing contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The first name of the primary billing contact.")]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the primary billing contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The last name of the primary billing contact.")]
        [ValidateNotNullOrEmpty]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the primary billing contact.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The phone number of the primary billing contact.")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The postal code portion of the address.")]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the region portion of the address.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The region portion of the address.")]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

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
            IValidator<Address> validator;
            LegalBusinessProfile profile;

            if (ShouldProcess(Resources.SetPartnerLegalProfileWhatIf))
            {
                profile = Partner.Profiles.LegalBusinessProfile.GetAsync().GetAwaiter().GetResult();

                profile.Address.AddressLine1 = UpdateValue(AddressLine1, profile.Address.AddressLine1);
                profile.Address.AddressLine2 = UpdateValue(AddressLine2, profile.Address.AddressLine2);
                profile.Address.City = UpdateValue(City, profile.Address.City);
                profile.Address.Country = UpdateValue(Country, profile.Address.Country);
                profile.Address.PostalCode = UpdateValue(PostalCode, profile.Address.PostalCode);
                profile.Address.Region = UpdateValue(Region, profile.Address.Region);
                profile.Address.State = UpdateValue(State, profile.Address.State);
                profile.CompanyApproverAddress = profile.Address;
                profile.CompanyApproverEmail = UpdateValue(EmailAddress, profile.CompanyApproverEmail);

                if (!DisableValidation.ToBool())
                {
                    validator = new AddressValidator(Partner);

                    if (!validator.IsValid(profile.Address, d => WriteDebug(d)))
                    {
                        throw new PSInvalidOperationException("The specified address is invalid. Please verify the address and try again.");
                    }
                }

                profile = Partner.Profiles.LegalBusinessProfile.UpdateAsync(profile).GetAwaiter().GetResult();

                WriteObject(new PSLegalBusinessProfile(profile));
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