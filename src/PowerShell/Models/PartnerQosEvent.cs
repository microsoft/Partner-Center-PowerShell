// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a quality of service event for the module.
    /// </summary>
    public class PartnerQosEvent
    {
        /// <summary>
        /// Timer used to determine the duration of the event.
        /// </summary>
        private readonly Stopwatch timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerQosEvent" /> class.
        /// </summary>
        public PartnerQosEvent()
        {
            StartTime = DateTimeOffset.Now;

            timer = new Stopwatch();
            timer.Start();
        }

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// Gets or sets the duration of the event.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the host version.
        /// </summary>
        public string HostVersion { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the event was successful or not.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the module version.
        /// </summary>
        public string ModuleVersion { get; set; }

        /// <summary>
        /// Gets or sets the parameter set name.
        /// </summary>
        public string ParameterSetName { get; set; }

        /// <summary>
        /// Gets or sets the parameters of the event.
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Gets or sets the start time of the event.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Finishes the quality of service event.
        /// </summary>
        public void FinishQosEvent()
        {
            timer.Stop();

            Duration = timer.Elapsed;
        }
    }
}