// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using PartnerCenter.Models;
    using Validations;

    /// <summary>
    /// Verifies the specified is valid.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "PartnerAddress", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class TestPartnerAddress : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The first line of the address.")]
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
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The postal code portion of the address.")]
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
            Address address;
            IValidator<Address> validator;

            address = new Address
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                City = City,
                Country = Country,
                PostalCode = PostalCode,
                Region = Region,
                State = State
            };

            validator = new AddressValidator(Partner);

            WriteObject(validator.IsValid(address, d => WriteDebug(d)));
        }
    }
}