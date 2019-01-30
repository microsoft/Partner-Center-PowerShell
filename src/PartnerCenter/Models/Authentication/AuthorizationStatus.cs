// -----------------------------------------------------------------------
// <copyright file="AuthorizationStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Authentication
{
    /// <summary>
    /// The available status entries for an authorization request.
    /// </summary>
    internal enum AuthorizationStatus
    {
        Success,
        ErrorHttp,
        ProtocolError,
        UserCancel,
        UnknownError
    }
}