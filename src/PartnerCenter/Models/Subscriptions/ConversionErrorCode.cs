// -----------------------------------------------------------------------
// <copyright file="ConversionErrorCode.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// The type of errors that prevent trial subscription conversion from happening.
    /// </summary>
    public enum ConversionErrorCode
    {
        /// <summary>
        /// General error.
        /// </summary>
        Other,

        /// <summary>
        /// Cannot find any conversions for the trial subscription to convert to.
        /// </summary>
        ConversionsNotFound
    }
}