// -----------------------------------------------------------------------
// <copyright file="SetPartnerCustomer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Converts;
    using Exceptions;
    using Models.Customers;
    using PartnerCenter.Exceptions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Customers;
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
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

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
            CustomerConverter converter;
            Customer customer;
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

                    customer = Partner.Customers[customerId].Get();

                    converter = new CustomerConverter(this, customer);
                    converter.Convert();

                    validator = new AddressValidator(Partner);

                    if (validator.IsValid(customer.BillingProfile.DefaultAddress))
                    {
                        Partner.Customers[customerId].Profiles.Billing.Update(customer.BillingProfile);

                        WriteObject(new PSCustomer(customer));
                    }
                    else
                    {
                        throw new PSInvalidOperationException("The address specified was invalid. Please check the values and try again.");
                    }
                }
            }
            catch (PartnerException ex)
            {
                throw new PSPartnerException("An error was encountered when communicating with Partner Center.", ex);
            }
            finally
            {
                converter = null;
                customer = null;
            }
        }
    }
}