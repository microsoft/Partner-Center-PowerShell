// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.ValidationRules
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.ValidationRules;

    /// <summary>Holds validation information for a single country.</summary>
    public sealed class PSCountryValidationRules
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCountryValidationRules" /> class.
        /// </summary>
        public PSCountryValidationRules()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCountryValidationRules" /> class.
        /// </summary>
        /// <param name="rules">The base customer for this instance.</param>
        public PSCountryValidationRules(CountryValidationRules rules)
        {
            this.CopyFrom(rules);
        }

        /// <summary>
        /// Gets or sets the country calling codes.
        /// </summary>
        public IEnumerable<string> CountryCallingCodesList { get; set; }

        /// <summary>
        /// Gets or sets the default culture.
        /// </summary>
        public string DefaultCulture { get; set; }

        /// <summary>
        /// Gets or sets the ISO2 code.
        /// </summary>
        public string Iso2Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a city is required or not.
        /// </summary>
        public bool IsCityRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a postal code is required or not.
        /// </summary>
        public bool IsPostalCodeRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the state is required or not.
        /// </summary>
        public bool IsStateRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a tax identifier is optional or not.
        /// </summary>
        public bool IsTaxIdOptional { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a tax identifier is supported or not.
        /// </summary>
        public bool IsTaxIdSupported { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a VAT identifier is required or not.
        /// </summary>
        public bool IsVatIdSupported { get; set; }

        /// <summary>
        /// Gets or sets the phone number regular expression.
        /// </summary>
        public string PhoneNumberRegex { get; set; }

        /// <summary>
        /// Gets or sets the postal code regular expression.
        /// </summary>
        public string PostalCodeRegex { get; set; }

        /// <summary>
        /// Gets or sets a list of supported cultures.
        /// </summary>
        public IEnumerable<string> SupportedCulturesList { get; set; }

        /// <summary>
        /// Gets or sets a list of supported languages.
        /// </summary>
        public IEnumerable<string> SupportedLanguagesList { get; set; }

        /// <summary>
        /// Gets or sets a list of states in the country.
        /// </summary>
        public IEnumerable<string> SupportedStatesList { get; set; }

        /// <summary>
        /// Gets or sets the tax identifier format.
        /// </summary>
        public string TaxIdFormat { get; set; }

        /// <summary>
        /// Gets or sets the tax identifier sample.
        /// </summary>
        public string TaxIdSample { get; set; }

        /// <summary>
        /// Gets or sets the tax identifier regular expression.
        /// </summary>
        public string VatIdRegex { get; set; }
    }
}