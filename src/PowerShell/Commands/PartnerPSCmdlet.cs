// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using System.Threading;
    using Models.Authentication;
    using Properties;

    /// <summary>
    /// Represents base class for the Partner Center PowerShell cmdlets.
    /// </summary>
    public abstract class PartnerPSCmdlet : PSCmdlet
    {
        /// <summary>
        /// The link that provide addtional information regarding the breaking change.
        /// </summary>
        private const string BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK = "https://aka.ms/partnercenterps-changewarnings";

        /// <summary>
        /// Provides a signal to <see cref="CancellationToken" /> that it should be canceled.
        /// </summary>
        private CancellationTokenSource cancellationSource;

        /// <summary>
        /// Gets the cancellation token used to propagate a notification that operations should be canceled.
        /// </summary>
        protected CancellationToken CancellationToken => cancellationSource.Token;

        /// <summary>
        /// Operations that happen before the cmdlet is invoked.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (cancellationSource == null)
            {
                cancellationSource = new CancellationTokenSource();
            }

            ProcessBreakingChangeAttributesAtRuntime(GetType(), MyInvocation, WriteWarning);
        }

        /// <summary>
        /// Operations that happend after the cmdlet is invoked.
        /// </summary>
        protected override void EndProcessing()
        {
            if (cancellationSource != null)
            {
                if (!cancellationSource.IsCancellationRequested)
                {
                    cancellationSource.Cancel();
                }

                cancellationSource.Dispose();
                cancellationSource = null;
            }
        }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ExecuteCmdlet();
        }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public virtual void ExecuteCmdlet()
        {
        }

        /// <summary>
        /// Operations that are performed when the processing a cmdlet is stopping.
        /// </summary>
        protected override void StopProcessing()
        {
            if (cancellationSource != null)
            {
                if (!cancellationSource.IsCancellationRequested)
                {
                    cancellationSource.Cancel();
                }

                cancellationSource.Dispose();
                cancellationSource = null;
            }

            base.StopProcessing();
        }

        /// <summary>
        /// Writes the object the pipeline.
        /// </summary>
        /// <param name="sendToPipeline">The object to be written to the pipeline.</param>
        protected new void WriteObject(object sendToPipeline)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline);
        }

        /// <summary>
        /// Writes the object the pipeline.
        /// </summary>
        /// <param name="sendToPipeline">The object to be written to the pipeline.</param>
        /// <param name="enumerateCollection">A flag indicating whether or not to enumerate the collection.</param>
        protected new void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// Writes the warning message to the pipeline.
        /// </summary>
        /// <param name="text">The message to be written to the pipeline.</param>
        protected new void WriteWarning(string text)
        {
            FlushDebugMessages();
            base.WriteWarning(text);
        }

        /// <summary>
        /// Gets all of the breaking change attributes in the specified type.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <param name="invocationInfo">The description of how and where this command was invoked.</param>
        private static IEnumerable<BreakingChangeBaseAttribute> GetAllBreakingChangeAttributesInType(Type type, InvocationInfo invocationInfo)
        {
            {
                List<BreakingChangeBaseAttribute> attributeList = new List<BreakingChangeBaseAttribute>();

                attributeList.AddRange(type.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());

                foreach (MethodInfo m in type.GetRuntimeMethods())
                {
                    attributeList.AddRange((m.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>()));
                }

                foreach (FieldInfo f in type.GetRuntimeFields())
                {
                    attributeList.AddRange(f.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
                }

                foreach (PropertyInfo p in type.GetRuntimeProperties())
                {
                    attributeList.AddRange(p.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
                }

                return invocationInfo == null ? attributeList : attributeList.Where(e => e.IsApplicableToInvocation(invocationInfo));
            }
        }

        /// <summary>
        /// Gets the name of the command from the type.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <returns>The name of the command from the type.</returns>
        private static string GetNameFromCmdletType(Type type)
        {
            string cmdletName = null;
            CmdletAttribute cmdletAttrib = (CmdletAttribute)type.GetCustomAttributes(typeof(CmdletAttribute), false).FirstOrDefault();

            if (cmdletAttrib != null)
            {
                cmdletName = cmdletAttrib.VerbName + "-" + cmdletAttrib.NounName;
            }

            return cmdletName;
        }

        /// <summary>
        /// Flushes the debug messages to the console.
        /// </summary>
        private void FlushDebugMessages()
        {
            while (PartnerSession.Instance.DebugMessages.TryDequeue(out string message))
            {
                WriteDebug(message);
            }
        }

        /// <summary>
        /// Processes the break changes defined for the cmdlet.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <param name="invocationInfo">The description of how and where this command was invoked.</param>
        /// <param name="writeOutput">The action used to write the output.</param>
        private void ProcessBreakingChangeAttributesAtRuntime(Type type, InvocationInfo invocationInfo, Action<string> writeOutput)
        {
            List<BreakingChangeBaseAttribute> attributes =
                new List<BreakingChangeBaseAttribute>(GetAllBreakingChangeAttributesInType(type, invocationInfo));

            if (attributes.Count > 0)
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesHeaderMessage,
                        GetNameFromCmdletType(type)));

                foreach (BreakingChangeBaseAttribute attribute in attributes)
                {
                    attribute.PrintCustomAttributeInfo(type, false, writeOutput);
                }

                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesFooterMessage,
                        BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK));
            }
        }
    }
}