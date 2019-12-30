// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;
    using PartnerCenter.Models;
    using Validations;

    /// <summary>
    /// Verifies the specified address is valid.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "PartnerAddress")]
    [OutputType(typeof(bool))]
    public class TestPartnerAddress : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        [Parameter(HelpMessage = "The first line of the address.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the address.
        /// </summary>
        [Parameter(HelpMessage = "The second line of the adress.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        [Parameter(HelpMessage = "The city portion of the address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country portion of the address.
        /// </summary>
        [Parameter(HelpMessage = "The country portion of the address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        [Parameter(HelpMessage = "The postal code portion of the address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the region portion of the address.
        /// </summary>
        [Parameter(HelpMessage = "The region portion of the address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the state portion of the address.
        /// </summary>
        [Parameter(HelpMessage = "The state portion of the address.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);


                Address address = new Address
                {
                    AddressLine1 = AddressLine1,
                    AddressLine2 = AddressLine2,
                    City = City,
                    Country = Country,
                    PostalCode = PostalCode,
                    Region = Region,
                    State = State
                };

                IValidator<Address> validator = new AddressValidator(partner);
                bool isValid = await validator.IsValidAsync(address);

                WriteObject(isValid);
            }, true);
        }
    }
}