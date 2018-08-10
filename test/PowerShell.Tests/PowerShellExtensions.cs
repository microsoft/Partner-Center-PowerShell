// -----------------------------------------------------------------------
// <copyright file="PowerShellExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests
{
    using System.Management.Automation;

    /// <summary>
    /// Useful extensions for unit testing the PowerShell cmdlets.
    /// </summary>
    internal static class PowerShellExtensions
    {
        /// <summary>
        /// Formats an <see cref="ErrorRecord"/> to a detailed string for logging.
        /// </summary>
        internal static string FormatErrorRecord(ErrorRecord record)
        {
            return $"PowerShell Error Record: {record}\nException:{record.Exception}\nDetails:{record.ErrorDetails}\nScript Stack Trace: {record.ScriptStackTrace}\n: Target: {record.TargetObject}\n";
        }
    }
}