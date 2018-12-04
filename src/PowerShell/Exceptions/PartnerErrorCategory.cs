// -----------------------------------------------------------------------
// <copyright file="PartnerErrorCategory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    /// <summary>
    /// Defines the error categories of the Partner Center SDK.
    /// </summary>
    public enum PartnerErrorCategory
    {
        /// <summary>
        /// Unknown error type.
        /// </summary>
        NotSpecified,
        
        /// <summary>
        /// The error was due to bad inputs from the user.
        /// </summary>
        BadInput,
        
        /// <summary>
        /// The user is not authorized to perform the requested action.
        /// </summary>
        Unauthorized,
        
        /// <summary>
        /// The operation was not granted to the caller.
        /// </summary>
        Forbidden,
        
        /// <summary>
        /// The resource was not found.
        /// </summary>
        NotFound,
        
        /// <summary>
        /// The requested data format is unsupported.
        /// </summary>
        UnsupportedDataFormat,
        
        /// <summary>
        /// The resource already exists.
        /// </summary>
        AlreadyExists,
        
        /// <summary>
        /// The requested operation is invalid.
        /// </summary>
        InvalidOperation,
        
        /// <summary>
        /// The partner service failed to process the request.
        /// </summary>
        ServerError,
        
        /// <summary>
        /// The partner service is overloaded currently.
        /// </summary>
        ServerBusy,
        
        /// <summary>
        /// The partner service did not respond in a timely manner.
        /// </summary>
        Timeout,
        
        /// <summary>
        /// The partner service response could not be parsed according to the preset expectation.
        /// </summary>
        ResponseParsing,
        
        /// <summary>
        /// There have been too many requests in a given amount of time.
        /// </summary>
        TooManyRequests
    }
}
