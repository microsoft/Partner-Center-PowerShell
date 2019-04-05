// -----------------------------------------------------------------------
// <copyright file="WebBrowserNavigateErrorEventArgs.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Platforms
{
    using System.ComponentModel;

    /// <summary>
    /// Represents the event arguments received when web browser navigation fails.
    /// This class is public only for COM requirements, but should not be used by the developer.
    /// </summary>
    public class WebBrowserNavigateErrorEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserNavigateErrorEventArgs" /> class.
        /// </summary>
        /// <param name="statusCode">Error status code</param>
        /// <param name="webBrowserActiveXInstance">return object</param>
        public WebBrowserNavigateErrorEventArgs(int statusCode, object webBrowserActiveXInstance)
        {
            StatusCode = statusCode;
            WebBrowserActiveXInstance = webBrowserActiveXInstance;
        }

        /// <summary>
        /// ADAL.Native has code for interpretation of this code to string we don't do it here, as we need to come consideration should we do it or not.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// return object
        /// </summary>
        public object WebBrowserActiveXInstance { get; }
    }
}
