// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Validations
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ValidationRules;
    using Properties;

    public sealed class AddressValidator : IValidator<Address>
    {
        /// <summary>
        /// Provides the ability to interact with Partner Center.
        /// </summary>
        private readonly IPartner partner;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValidator" /> class.
        /// </summary>
        /// <param name="partner">Provides the ability interact with Partner Center.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="partner"/> is null.
        /// </exception>
        public AddressValidator(IPartner partner)
        {
            partner.AssertNotNull(nameof(partner));
            this.partner = partner;
        }

        /// <summary>
        /// Determines if the resource is valid.
        /// </summary>
        /// <param name="resource">The resource to be validate.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the resource is valid; otherwise <c>false</c>.</returns>
        public async Task<bool> IsValidAsync(Address resource, CancellationToken cancellationToken = default)
        {
            CountryValidationRules validationRules;

            resource.AssertNotNull(nameof(resource));

            validationRules = await partner.CountryValidationRules.ByCountry(resource.Country).GetAsync(cancellationToken).ConfigureAwait(false);

            if (validationRules.IsCityRequired && string.IsNullOrEmpty(resource.City))
            {
                throw new ValidationException(Resources.CityRequiredError);
            }

            if (validationRules.IsPostalCodeRequired && string.IsNullOrEmpty(resource.PostalCode))
            {
                throw new ValidationException(Resources.PostalCoderequiredError);
            }

            if (validationRules.IsStateRequired)
            {
                if (string.IsNullOrEmpty(resource.State))
                {
                    throw new ValidationException(Resources.StateRequiredError);
                }
                else
                {
                    if (!validationRules.SupportedStatesList.Contains(resource.State))
                    {
                        throw new ValidationException(
                            string.Format(
                                CultureInfo.CurrentCulture,
                                Resources.InvalidStateError,
                                resource.State,
                                string.Join(",", validationRules.SupportedStatesList)));
                    }
                }
            }

            if (!string.IsNullOrEmpty(validationRules.PhoneNumberRegex)
                && !string.IsNullOrEmpty(resource.PhoneNumber) &&
                !Regex.Match(resource.PhoneNumber, validationRules.PhoneNumberRegex).Success)
            {
                throw new ValidationException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidPhoneFormatError,
                        resource.PhoneNumber));
            }

            return await partner.Validations.IsAddressValidAsync(resource, cancellationToken).ConfigureAwait(false);
        }
    }
}