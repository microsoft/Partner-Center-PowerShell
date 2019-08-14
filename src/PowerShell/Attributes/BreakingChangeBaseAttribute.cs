// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Properties;

    /// <summary>
    /// The base class used by all breaking change attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public abstract class BreakingChangeBaseAttribute : Attribute
    {
        /// <summary>
        /// The message that describes the breaking change.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakingChangeBaseAttribute" /> class.
        /// </summary>
        /// <param name="message">The message that describes the breaking change.</param>
        protected BreakingChangeBaseAttribute(string message)
        {
            message.AssertNotEmpty(nameof(message));

            this.message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakingChangeBaseAttribute" /> class.
        /// </summary>
        /// <param name="message">The message that describes the breaking change.</param>
        /// <param name="deprecateByVersion">The version where the change will be required.</param>
        protected BreakingChangeBaseAttribute(string message, string deprecateByVersion)
        {
            message.AssertNotEmpty(nameof(message));
            deprecateByVersion.AssertNotEmpty(nameof(deprecateByVersion));

            this.message = message;
            DeprecateByVersion = deprecateByVersion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakingChangeBaseAttribute" /> class.
        /// </summary>
        /// <param name="message">The message that describes the breaking change.</param>
        /// <param name="deprecateByVersion">The version where the change will be required.</param>
        /// <param name="changeInEfectByDate">The date when the change will be required.</param>
        protected BreakingChangeBaseAttribute(string message, string deprecateByVersion, string changeInEfectByDate)
        {
            message.AssertNotEmpty(nameof(message));
            deprecateByVersion.AssertNotEmpty(nameof(deprecateByVersion));
            changeInEfectByDate.AssertNotEmpty(nameof(changeInEfectByDate));

            this.message = message;
            DeprecateByVersion = deprecateByVersion;
            ChangeInEfectByDate = DateTime.Parse(changeInEfectByDate, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets or sets the description for the change.
        /// </summary>
        public string ChangeDescription { get; set; } = null;

        /// <summary>
        /// Gets the date the change will be required.
        /// </summary>
        public DateTime? ChangeInEfectByDate { get; } = null;

        /// <summary>
        /// Gets the version when this change will be depcreated.
        /// </summary>
        public string DeprecateByVersion { get; } = null;

        /// <summary>
        /// Gets or sets the new way the command should be invoked.
        /// </summary>
        public string NewWay { get; set; }

        /// <summary>
        /// Gets or sets the old way the command was invoked.
        /// </summary>
        public string OldWay { get; set; }

        /// <summary>
        /// Checks if the breaking change applies to how or where the command was invoked.
        /// </summary>
        /// <param name="invocationInfo">The description of how and where this command was invoked.</param>
        /// <returns>
        /// <c>true</c> if the breaking change applies to how or where the command was invoked; otherwise <c>false</c>.
        /// </returns>
        public virtual bool IsApplicableToInvocation(InvocationInfo invocation)
        {
            return true;
        }

        /// <summary>
        /// Gets the specified message for the attribute.
        /// </summary>
        /// <returns>The specified message for the attribute.</returns>
        protected virtual string GetAttributeSpecificMessage()
        {
            return message;
        }

        /// <summary>
        /// Gets the name of the command from the type.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <returns>The name of the command from the type.</returns>
        public static string GetNameFromCmdletType(Type type)
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
        /// Writes the attribute information to the output.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <param name="withCmdletName">A flag indicating whether or not to write the command name.</param>
        /// <param name="writeOutput">The action used to write the output.</param>
        public void PrintCustomAttributeInfo(Type type, bool withCmdletName, Action<string> writeOutput)
        {
            if (!withCmdletName)
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesDeclarationMessage,
                        GetAttributeSpecificMessage()));
            }
            else
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesDeclarationMessageWithCmdletName,
                        GetNameFromCmdletType(type),
                        GetAttributeSpecificMessage()));
            }

            if (!string.IsNullOrWhiteSpace(ChangeDescription))
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesChangeDescriptionMessage,
                        ChangeDescription));
            }

            if (ChangeInEfectByDate.HasValue)
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesInEffectByDateMessage,
                        ChangeInEfectByDate.Value));
            }

            if (!string.IsNullOrEmpty(DeprecateByVersion))
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesInEffectByVersion,
                        DeprecateByVersion));
            }

            if (OldWay != null && NewWay != null)
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesUsageChangeMessageConsole,
                        OldWay,
                        NewWay));
            }
        }
    }
}