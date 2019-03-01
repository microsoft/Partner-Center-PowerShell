// -----------------------------------------------------------------------
// <copyright file="SetPartnerCustomer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Exceptions;
    using Models.Customers;
    using PartnerCenter.Models;
    using Properties;
    using Validations;

    [Cmdlet(VerbsCommon.Set, "PartnerCustomer", DefaultParameterSetName = "Customer", SupportsShouldProcess = true)]
    [OutputType(typeof(PSCustomer))]
    public class SetPartnerCustomer : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer being modified.
        /// </summary>
        [Parameter(
            HelpMessage = "The customer object to be modified.",
            Mandatory = true,
            ParameterSetName = "CustomerObject",
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSCustomer InputObject { get; set; }

        /// <summary>
        /// Gets or sets the first line of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The first line of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The first line of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The second line of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The second line of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The city of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The city of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressCity { get; set; }

        /// <summary>
        /// Gets or sets the country of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The country of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The county of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The phone number of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The phone number of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The postal code of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The postal code of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the region of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The region of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The region of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressRegion { get; set; }

        /// <summary>
        /// Gets or sets the state of the billing address.
        /// </summary>
        [Parameter(HelpMessage = "The state of the customer's billing address.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "The state of the customer's billing address.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string BillingAddressState { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true, ParameterSetName = "Customer")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact at the customer.
        /// </summary>
        [Parameter(HelpMessage = "Email address of the contact at the customer.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "Email address of the contact at the customer.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidatePattern(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", Options = RegexOptions.IgnoreCase)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        [Parameter(HelpMessage = "Name of the customer.", Mandatory = false, ParameterSetName = "Customer")]
        [Parameter(HelpMessage = "Name of the customer.", Mandatory = false, ParameterSetName = "CustomerObject")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PartnerCenter.Models.Customers.Customer customer;
            IValidator<Address> validator;
            string customerId;

            try
            {
                customerId = (InputObject == null) ? CustomerId : InputObject.CustomerId;

                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.SetPartnerCustomerWhatIf, customerId)))
                {
                    if (InputObject == null && string.IsNullOrEmpty(CustomerId))
                    {
                        throw new PSInvalidOperationException(Resources.InvalidSetCustomerIdentifierException);
                    }

                    customer = Partner.Customers[customerId].GetAsync().GetAwaiter().GetResult();

                    customer.BillingProfile.DefaultAddress.AddressLine1 = UpdateValue(BillingAddressLine1, customer.BillingProfile.DefaultAddress.AddressLine1);
                    customer.BillingProfile.DefaultAddress.AddressLine2 = UpdateValue(BillingAddressLine2, customer.BillingProfile.DefaultAddress.AddressLine2);
                    customer.BillingProfile.DefaultAddress.City = UpdateValue(BillingAddressCity, customer.BillingProfile.DefaultAddress.City);
                    customer.BillingProfile.DefaultAddress.Country = UpdateValue(BillingAddressCountry, customer.BillingProfile.DefaultAddress.Country);
                    customer.BillingProfile.DefaultAddress.PhoneNumber = UpdateValue(BillingAddressPhoneNumber, customer.BillingProfile.DefaultAddress.PhoneNumber);
                    customer.BillingProfile.DefaultAddress.PostalCode = UpdateValue(BillingAddressPostalCode, customer.BillingProfile.DefaultAddress.PostalCode);
                    customer.BillingProfile.DefaultAddress.Region = UpdateValue(BillingAddressRegion, customer.BillingProfile.DefaultAddress.Region);
                    customer.BillingProfile.DefaultAddress.State = UpdateValue(BillingAddressState, customer.BillingProfile.DefaultAddress.State);
                    customer.BillingProfile.CompanyName = UpdateValue(Name, customer.BillingProfile.CompanyName);
                    customer.BillingProfile.Email = UpdateValue(Email, customer.BillingProfile.Email);

                    validator = new AddressValidator(Partner);

                    if (validator.IsValid(customer.BillingProfile.DefaultAddress))
                    {
                        Partner.Customers[customerId].Profiles.Billing.UpdateAsync(customer.BillingProfile).GetAwaiter().GetResult();

                        WriteObject(new PSCustomer(customer));
                    }
                    else
                    {
                        throw new PSInvalidOperationException("The address specified was invalid. Please check the values and try again.");
                    }
                }
            }
            catch (PartnerCenter.Exceptions.PartnerException ex)
            {
                throw new PSPartnerException("An error was encountered when communicating with Partner Center.", ex);
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