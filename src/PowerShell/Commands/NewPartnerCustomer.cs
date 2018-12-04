// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Customers;
    using PartnerCenter.Models;
    using Profile;
    using Properties;
    using Validations;

    [Cmdlet(VerbsCommon.New, "PartnerCustomer", SupportsShouldProcess = true), OutputType(typeof(PSCustomer))]
    public class NewPartnerCustomer : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the associated partner identifier.
        /// </summary>
        [Parameter(HelpMessage = "The associated partner identifier. Used if creating a customer for an indirect reseller.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AssociatedPartnerId { get; set; }

        /// <summary>
        /// Gets or sets the first line of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The first line of the customer's billing address.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The second line of the customer's billing address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The city of the customer's billing address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressCity { get; set; }

        /// <summary>
        /// Gets or sets the country of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The country of the customer's billing address.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The postal code of the customer's billing address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the region of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The region of the customer's billing address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressRegion { get; set; }

        /// <summary>
        /// Gets or sets the state of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The state of the customer's billing address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string BillingAddressState { get; set; }

        /// <summary>
        /// Gets or sets the email address of the primary contact at the customer.
        /// </summary>
        [Parameter(HelpMessage = "The email address of the primary contact at the customer.", Mandatory = false)]
        [ValidatePattern(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", Options = RegexOptions.IgnoreCase)]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the first name of the primary contact at the customer.
        /// </summary>
        [Parameter(HelpMessage = "The first name of the primary contact at the customer.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the primary contact at the customer.
        /// </summary>
        [Parameter(HelpMessage = "The last name of the primary contact at the customer.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ContactLastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the primary contact at the customer.
        /// </summary>
        [Parameter(HelpMessage = "The phone number of the primary contact at the customer.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ContactPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the preferred culture for communication and currency.
        /// </summary>
        [Parameter(HelpMessage = "The preferred culture for communication and currency.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the domain of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The customer's domain name, such as contoso.onmicrosoft.com. - 27 characters maximum domain prefix + 16 maximum characters suffix for '.onmicrosoft.com'", Mandatory = true)]
        [ValidateLength(17, 43)]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the default language. Two character language codes (e.g., en, fr) are supported.
        /// </summary>
        [Parameter(HelpMessage = "The default language. Two character language codes (e.g., en, fr) are supported.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The name of the customer to be created.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PartnerCenter.Models.Customers.Customer customer;
            IValidator<Address> validator;
            string country;
            string culture;
            string region;

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.NewPartnerCustomerWhatIf, Name)))
            {
                if (Partner.Domains.ByDomain(Domain).Exists())
                {
                    throw new PSInvalidOperationException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.DomainExistsError,
                            Domain));
                }

                country = (string.IsNullOrEmpty(BillingAddressCountry)) ? PartnerSession.Instance.Context.CountryCode : BillingAddressCountry;
                culture = (string.IsNullOrEmpty(Culture)) ? PartnerSession.Instance.Context.Locale : Culture;

                if (string.IsNullOrEmpty(BillingAddressRegion))
                {
                    region = null;
                }
                else
                {
                    region = BillingAddressRegion.Equals("US", StringComparison.InvariantCultureIgnoreCase) ? string.Empty : BillingAddressRegion;
                }

                customer = new PartnerCenter.Models.Customers.Customer
                {
                    AssociatedPartnerId = AssociatedPartnerId,
                    BillingProfile = new PartnerCenter.Models.Customers.CustomerBillingProfile
                    {
                        CompanyName = Name,
                        Culture = culture,
                        DefaultAddress = new Address
                        {
                            AddressLine1 = BillingAddressLine1,
                            AddressLine2 = BillingAddressLine2,
                            City = BillingAddressCity,
                            Country = country,
                            FirstName = ContactFirstName,
                            LastName = ContactLastName,
                            PhoneNumber = ContactPhoneNumber,
                            PostalCode = BillingAddressPostalCode,
                            Region = region,
                            State = BillingAddressState
                        },
                        Email = ContactEmail,
                        FirstName = ContactFirstName,
                        Language = Language,
                        LastName = ContactLastName
                    },
                    CompanyProfile = new PartnerCenter.Models.Customers.CustomerCompanyProfile
                    {
                        CompanyName = Name,
                        Domain = Domain
                    }
                };

                validator = new AddressValidator(Partner);

                if (validator.IsValid(customer.BillingProfile.DefaultAddress))
                {
                    customer = Partner.Customers.Create(customer);

                    WriteObject(customer);
                }
            }
        }
    }
}