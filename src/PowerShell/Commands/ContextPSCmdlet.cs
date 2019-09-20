// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using Models;
    using Models.Authentication;

    public abstract class ContextPSCmdlet : PSCmdlet
    {
        private event EventHandler<StreamEventArgs> WriteWarningEvent;

        protected override void BeginProcessing()
        {
            WriteWarningEvent -= WriteWarningSender;
            WriteWarningEvent += WriteWarningSender;

            PartnerSession.Instance.RegisterComponent("WriteWarning", () => WriteWarningEvent);
        }

        public void FlushDebugMessages()
        {
            while (PartnerSession.Instance.DebugMessages.TryDequeue(out string message))
            {
                WriteDebug(message);
            }
        }

        private void WriteWarningSender(object sender, StreamEventArgs args)
        {
            WriteWarning(args.Message);
        }
    }
}