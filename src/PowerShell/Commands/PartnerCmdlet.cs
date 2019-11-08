// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;
    using Properties;

    /// <summary>
    /// Represents base class for the Partner Center cmdlets.
    /// </summary>
    public abstract class PartnerCmdlet : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets the available Partner Center operations.
        /// </summary>
        internal IPartner Partner { get; private set; }

        /// <summary>
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (PartnerSession.Instance.Context == null)
            {
                throw new PSInvalidOperationException(Resources.RunConnectPartnerCenter);
            }

            Partner = PartnerSession.Instance.ClientFactory.CreatePartnerOperations();

            base.BeginProcessing();
        }
    }
}