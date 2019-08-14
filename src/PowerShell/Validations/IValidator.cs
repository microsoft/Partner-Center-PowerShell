// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Validations
{
    using System;

    public interface IValidator<in T>
    {
        bool IsValid(T resource, Action<string> debugAction);
    }
}