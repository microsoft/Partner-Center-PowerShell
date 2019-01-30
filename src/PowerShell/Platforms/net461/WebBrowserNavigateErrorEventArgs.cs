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
        // Fields
        private readonly string targetFrameName;
        private readonly string url;
        private readonly int statusCode;
        private readonly object webBrowserActiveXInstance;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">url as a string, as in case of error it could be invalid url</param>
        /// <param name="targetFrameName">Name of the target frame that had the failure</param>
        /// <param name="statusCode">Error status code</param>
        /// <param name="webBrowserActiveXInstance">return object</param>
        public WebBrowserNavigateErrorEventArgs(string url, string targetFrameName, int statusCode, object webBrowserActiveXInstance)
        {
            this.url = url;
            this.targetFrameName = targetFrameName;
            this.statusCode = statusCode;
            this.webBrowserActiveXInstance = webBrowserActiveXInstance;
        }

        /// <summary>
        /// Name of the target frame that had the failure
        /// </summary>
        public string TargetFrameName
        {
            get
            {
                return this.targetFrameName;
            }
        }

        /// <summary>
        /// url as a string, as in case of error it could be invalid url
        /// </summary>
        public string Url
        {
            get
            {
                return this.url;
            }
        }

        /// <summary>
        /// ADAL.Native has code for interpretation of this code to string we don't do it here, as we need to come consideration should we do it or not.
        /// </summary>
        public int StatusCode
        {
            get
            {
                return this.statusCode;
            }
        }

        /// <summary>
        /// return object
        /// </summary>
        public object WebBrowserActiveXInstance
        {
            get
            {
                return this.webBrowserActiveXInstance;
            }
        }
    }
}
