// -----------------------------------------------------------------------
// <copyright file="ICountryValidationRules.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ValidationRules
{
    using GenericOperations;
    using Models.ValidationRules;

    /// <summary>
    /// Represents the behavior of a specific country validation rules.
    /// </summary>
    public interface ICountryValidationRules : IPartnerComponent<string>, IEntityGetOperations<CountryValidationRules>
    {
    }
}