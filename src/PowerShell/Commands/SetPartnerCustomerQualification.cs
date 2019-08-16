// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Customers;
    using PartnerCenter.Models.Customers;
    using PartnerCenter.Models.ValidationCodes;
    using Properties;

    /// <summary>
    /// Updates the specified customer’s qualification to be "Education" or "GovernmentCommunityCloud."
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerCustomerQualification", DefaultParameterSetName = "Customer", SupportsShouldProcess = true)]
    [OutputType(typeof(CustomerQualification))]
    public class SetPartnerCustomerQualification : PartnerPSCmdlet
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
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true, ParameterSetName = "Customer")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the qualiciation assigned to the customer.
        /// </summary>
        [Parameter(HelpMessage = "The qualification assigned to the customer.", Mandatory = true)]
        [ValidateSet(nameof(CustomerQualification.Education), nameof(CustomerQualification.GovernmentCommunityCloud))]
        public CustomerQualification Qualification { get; set; }

        /// <summary>
        /// Gets or sets the validation code used when assigning the Government Community Cloud qualification.
        /// </summary>
        [Parameter(HelpMessage = "The validation code used when assigning the Government Community Cloud qualification.", Mandatory = false)]
        public ValidationCode ValidationCode { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string customerId = (InputObject == null) ? CustomerId : InputObject.CustomerId;

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.SetPartnerCustomerWhatIf, customerId)))
            {
                if (InputObject == null && string.IsNullOrEmpty(CustomerId))
                {
                    throw new PSInvalidOperationException(Resources.InvalidSetCustomerIdentifierException);
                }

                if (Qualification == CustomerQualification.GovernmentCommunityCloud)
                {
                    if (ValidationCode == null)
                    {
                        throw new PSInvalidOperationException("The validation code must be set when assigning the Government Community Cloud qualification. Use the Get-PartnerValidation command to get the validation code.");
                    }

                    WriteObject(Partner.Customers[customerId].Qualification.UpdateAsync(Qualification, ValidationCode).GetAwaiter().GetResult());
                }
                else
                {
                    WriteObject(Partner.Customers[customerId].Qualification.UpdateAsync(Qualification).GetAwaiter().GetResult());
                }
            }
        }
    }
}