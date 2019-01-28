// -----------------------------------------------------------------------
// <copyright file="ICountryValidationRules.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CountryValidationRules
{
    using GenericOperations;
    using Models.CountryValidationRules;

    /// <summary>
    /// Represents the behavior of a specific country validation rules.
    /// </summary>
    public interface ICountryValidationRules : IPartnerComponent<string>, IEntityGetOperations<CountryValidationRules>
    {
    }
}