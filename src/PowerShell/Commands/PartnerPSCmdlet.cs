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
    using Models.Authentication;
    using Properties;

    /// <summary>
    /// Represents base class for the Partner Center cmdlets.
    /// </summary>
    public abstract class PartnerPSCmdlet : PSCmdlet
    {
        /// <summary>
        /// The link that provide addtional information regarding the breaking change.
        /// </summary>
        private const string BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK = "https://aka.ms/partnercenterps-changewarnings";

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

            ProcessBreakingChangeAttributesAtRuntime(GetType(), MyInvocation, WriteWarning);
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
    }
}