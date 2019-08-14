// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell
{
    /// <summary>
    /// Attribute that describes a breaking change.
    /// </summary>
    public sealed class BreakingChangeAttribute : BreakingChangeBaseAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BreakingChangeAttribute" /> class.
        /// </summary>
        /// <param name="message">The message that describes the breaking change.</param>
        public BreakingChangeAttribute(string message) : base(message)
        {
            message.AssertNotEmpty(nameof(message));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakingChangeAttribute" /> class.
        /// </summary>
        /// <param name="message">The message that describes the breaking change.</param>
        /// <param name="deprecateByVersion">The version where the change will be required.</param>
        public BreakingChangeAttribute(string message, string deprecateByVersion) : base(message, deprecateByVersion)
        {
            message.AssertNotEmpty(nameof(message));
            deprecateByVersion.AssertNotEmpty(nameof(deprecateByVersion));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BreakingChangeAttribute" /> class.
        /// </summary>
        /// <param name="message">The message that describes the breaking change.</param>
        /// <param name="deprecateByVersion">The version where the change will be required.</param>
        /// <param name="changeInEfectByDate">The data when the change will be required.</param>
        public BreakingChangeAttribute(string message, string deprecateByVersion, string changeInEfectByDate)
            : base(message, deprecateByVersion, changeInEfectByDate)
        {
            message.AssertNotEmpty(nameof(message));
            deprecateByVersion.AssertNotEmpty(nameof(deprecateByVersion));
            changeInEfectByDate.AssertNotEmpty(nameof(changeInEfectByDate));
        }
    }
}