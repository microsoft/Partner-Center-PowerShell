// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Agreements;
    using PartnerCenter.Models.Agreements;
    using Properties;

    /// <summary>
    /// Create a new agreement for the specified customer.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "PartnerCustomerAgreement"), OutputType(typeof(PSAgreement))]
    public class NewPartnerCustomerAgreement : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the agreement type. 
        /// </summary>
        [Parameter(HelpMessage = "The type of agreement being accepted.", Mandatory = true)]
        [ValidateSet("MicrosoftCloudAgreement", "MicrosoftCustomerAgreement")]
        public string AgreementType { get; set; }

        /// <summary>
        /// Gets or sets the email address of the primary contact of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The email address of the primary contact of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the first name of the primary contact of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The first name of the primary contact of the customer.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the primary contact of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The last name of the primary contact of the customer.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ContactLastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the primary contact of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The phone number of the primary contact of the customer.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ContactPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the date the agreement was signed.
        /// </summary>
        [Parameter(HelpMessage = "The date the agreement was signed.", Mandatory = false)]
        public DateTime? DateAgreed { get; set; }

        /// <summary>
        /// Gets or sets the required template identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the template.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TemplateId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Agreement agreement;
            DateTime dateAgreed = DateAgreed ?? DateTime.Now;

            if (ShouldProcess(Resources.NewPartnerCustomerAgreementWhatIf))
            {
                agreement = new Agreement
                {
                    DateAgreed = dateAgreed,
                    PrimaryContact = new Contact
                    {
                        Email = ContactEmail,
                        FirstName = ContactFirstName,
                        LastName = ContactLastName,
                        PhoneNumber = ContactPhoneNumber

                    },
                    TemplateId = TemplateId,
                    Type = AgreementType,
                };

                agreement = Partner.Customers[CustomerId].Agreements.CreateAsync(agreement).GetAwaiter().GetResult();

                WriteObject(agreement);
            }

        }
    }
}