// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;

    /// <summary>
    /// The event arguments an exception that was thrown during the execution of task.
    /// </summary>
    public class TaskExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the exception that was thrown.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskExceptionEventArgs" /> class.
        /// </summary>
        /// <param name="e">The exception that was thrown.</param>
        public TaskExceptionEventArgs(Exception e)
        {
            Exception = e;
        }
    }
}