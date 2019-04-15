// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerAgreement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Authentication;
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
        [ValidateSet(nameof(AgreementType.MicrosoftCloudAgreement))]
        public AgreementType AgreementType { get; set; }

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
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// Gets or sets the required template identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the template.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [BreakingChange("The API will now derive this value based on the authenticated user. So, this parameter will be removed in a future release.", "1.5.1906.1")]
        [Parameter(HelpMessage = "The identifier of the user in the partner tenant who is providing confirmation on behalf of the customer.", Mandatory = false)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Agreement agreement;
            DateTime dateAgreed = DateAgreed ?? DateTime.Now;
            string userId = UserId;

            if (PartnerSession.Instance.Context.Account.Properties.ContainsKey(AzureAccountPropertyType.UserIdentifier) && string.IsNullOrEmpty(UserId))
            {
                userId = PartnerSession.Instance.Context.Account.Properties[AzureAccountPropertyType.UserIdentifier];
            }

            if (string.IsNullOrEmpty(userId))
            {
                throw new PSInvalidOperationException(Resources.NewCustomerAgreementInvalidOperationMessage);
            }

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
                    UserId = userId
                };

                agreement = Partner.Customers[CustomerId].Agreements.CreateAsync(agreement).GetAwaiter().GetResult();

                WriteObject(agreement);
            }

        }
    }
}