// -----------------------------------------------------------------------
// <copyright file="ICountryValidationRulesCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CountryValidationRules
{
    using GenericOperations;

    /// <summary>
    /// Encapsulates country validation rules behavior.
    /// </summary>
    public interface ICountryValidationRulesCollection : IPartnerComponent<string>, ICountrySelector<ICountryValidationRules>
    {
    }
}