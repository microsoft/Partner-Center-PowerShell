// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
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
        /// Provides the ability manage access to resources.
        /// </summary>
        private static readonly ReaderWriterLockSlim sessionLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        /// <summary>
        /// Gets or sets an instance of the authentication factory.
        /// </summary>
        public IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets an instance of the client factory.
        /// </summary>
        public IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets the operating context information.
        /// </summary>
        public PartnerContext Context { get; set; }

        /// <summary>
        /// Gets the queue of debug messages.
        /// </summary>
        public ConcurrentQueue<string> DebugMessages { get; } = new ConcurrentQueue<string>();

        /// <summary>
        /// Gets an instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        public static PartnerSession Instance
        {
            get
            {
                sessionLock.EnterReadLock();

                try
                {
                    return partnerSession.Value;
                }
                finally
                {
                    sessionLock.ExitReadLock();
                }
            }
        }
    }
}