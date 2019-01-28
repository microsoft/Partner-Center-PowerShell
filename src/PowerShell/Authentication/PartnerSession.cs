// -----------------------------------------------------------------------
// <copyright file="PartnerSession.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    using System;
    using Factories;

    /// <summary>
    /// Contains session information for the execution of the commands.
    /// </summary>
    public class PartnerSession
    {
        /// <summary>
        /// Singleton instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        private static readonly Lazy<PartnerSession> partnerSession = new Lazy<PartnerSession>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        public PartnerSession()
        { }


        /// <summary>
        /// Gets or sets an instance of the authentication factory.
        /// </summary>
        public IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets an instance of the client facotry.
        /// </summary>
        public IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets the operating context information.
        /// </summary>
        public PartnerContext Context { get; set; }

        /// <summary>
        /// Gets an instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        public static PartnerSession Instance => partnerSession.Value;
    }
}