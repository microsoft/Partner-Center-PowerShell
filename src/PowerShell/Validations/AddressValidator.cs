// -----------------------------------------------------------------------
// <copyright file="AddressValidator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Validations
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Common;
    using Exceptions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ValidationRules;
    using Properties;

    public sealed class AddressValidator : IValidator<Address>
    {
        /// <summary>
        /// Provides the ability to interact with Partner Center.
        /// </summary>
        private readonly PartnerCenter.IPartner partner;

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
        public bool IsValid(Address resource)
        {
            CountryValidationRules validationRules;

            resource.AssertNotNull(nameof(resource));

            try
            {
                if (resource.Country.Equals("CN", StringComparison.InvariantCultureIgnoreCase) ||
                    resource.Country.Equals("MX", StringComparison.InvariantCultureIgnoreCase) ||
                    resource.Country.Equals("US", StringComparison.InvariantCultureIgnoreCase))
                {
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

                return partner.Validations.IsAddressValidAsync(resource).GetAwaiter().GetResult();
            }
            catch (PartnerCenter.Exceptions.PartnerException ex)
            {
                if (ex.ServiceErrorPayload != null)
                {
                    throw new PartnerPSException($"{ex.ServiceErrorPayload.ErrorCode} {ex.ServiceErrorPayload.ErrorMessage}", ex);
                }

                throw;
            }
        }
    }
}