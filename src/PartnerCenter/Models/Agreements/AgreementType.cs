// -----------------------------------------------------------------------
// <copyright file="Contact.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Agreements
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents the types of agreements supported.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AgreementType
    {
        /// <summary>
        /// Microsoft cloud agreement
        /// </summary>
        MicrosoftCloudAgreement,
    }
}