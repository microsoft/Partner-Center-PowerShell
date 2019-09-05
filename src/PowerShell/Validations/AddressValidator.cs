// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Validations
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ValidationRules;
    using Properties;

    public sealed class AddressValidator : IValidator<Address>
    {
        /// <summary>
        /// The country code for China.
        /// </summary>
        private const string ChinaCountryCode = "CN";

        /// <summary>
        /// The country code for Mexico.
        /// </summary>
        private const string MexicoCountryCode = "MX";

        /// <summary>
        /// The country code for the United States.
        /// </summary>
        private const string UnitedStatesCountryCode = "US";

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
        /// <returns><c>true</c> if the resource is valid; otherwise <c>false</c>.</returns>
        public bool IsValid(Address resource, Action<string> debugAction)
        {
            CountryValidationRules validationRules;

            resource.AssertNotNull(nameof(resource));

            if (resource.Country.Equals(ChinaCountryCode, StringComparison.InvariantCultureIgnoreCase) ||
                resource.Country.Equals(MexicoCountryCode, StringComparison.InvariantCultureIgnoreCase) ||
                resource.Country.Equals(UnitedStatesCountryCode, StringComparison.InvariantCultureIgnoreCase))
            {
                debugAction("Requesting country validation services from the partner service.");
                validationRules = partner.CountryValidationRules.ByCountry(resource.Country).GetAsync().GetAwaiter().GetResult();

                if (validationRules.IsCityRequired && string.IsNullOrEmpty(resource.City))
                {
                    throw new ValidationException(Resources.CityRequiredError);
                }

                if (validationRules.IsPostalCodeRequired && string.IsNullOrEmpty(resource.PostalCode))
                {
                    throw new ValidationException(Resources.PostalCoderequiredError);
                }

                if (validationRules.IsStateRequired && string.IsNullOrEmpty(resource.State))
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
            }

            debugAction("Checking if the address is valid using the partner service.");
            return partner.Validations.IsAddressValidAsync(resource).GetAwaiter().GetResult();
        }
    }
}