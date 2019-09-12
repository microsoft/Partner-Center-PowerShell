// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Represents an error that occurred during command execution.
    /// </summary>
    public class PartnerExceptionRecord : PartnerErrorRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerExceptionRecord"/>
        /// </summary>
        /// <param name="exception">The error that occur during command execution.</param>
        /// <param name="record">The record of the error.</param>
        public PartnerExceptionRecord(Exception exception, ErrorRecord record) :
            base(record)
        {
            if (exception != null)
            {
                Message = exception.Message;
                HelpLink = exception.HelpLink;
                StackTrace = exception.StackTrace;
            }

            Exception = exception;
        }

        /// <summary>
        /// Gets the error that occur during command execution.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the link to the help file associated with this exception.
        /// </summary>
        public string HelpLink { get; }


        /// <summary>
        /// Gets the message that describes the current exception.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the string representation of the immediate frames on the call stack.
        /// </summary>
        public string StackTrace { get; }
    }
}