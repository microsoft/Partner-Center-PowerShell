// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using System.Management.Automation;

    /// <summary>
    /// Represents an error that occurred with the execution of a command.
    /// </summary>
    public class PartnerErrorRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerErrorRecord" /> class.
        /// </summary>
        /// <param name="record">The record of the error.</param>
        public PartnerErrorRecord(ErrorRecord record)
        {
            if (record != null)
            {
                ErrorCategory = record.CategoryInfo;
                ErrorDetails = record.ErrorDetails;
                InvocationInfo = record.InvocationInfo;
                ScriptStackTrace = record.ScriptStackTrace;
            }
        }

        /// <summary>
        /// Gets or sets the error category.
        /// </summary>
        public ErrorCategoryInfo ErrorCategory { get; set; }

        /// <summary>
        /// Gets or sets the error details.
        /// </summary>
        public ErrorDetails ErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the invocation information.
        /// </summary>
        public InvocationInfo InvocationInfo { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        public string ScriptStackTrace { get; set; }
    }
}