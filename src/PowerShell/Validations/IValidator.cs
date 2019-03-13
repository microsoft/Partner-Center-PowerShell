// -----------------------------------------------------------------------
// <copyright file="IValidator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Validations
{
    using System;

    public interface IValidator<in T>
    {
        bool IsValid(T resource, Action<string> debugAction);
    }
}