// -----------------------------------------------------------------------
// <copyright file="TestPartnerDomainAvailability.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Common;

    /// <summary>
    /// Check to see if the specified domain name is available.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "PartnerDomainAvailability"), OutputType(typeof(bool))]
    public class TestPartnerDomainAvailability : PartnerPSCmdlet
    {
        /// <summary>
        /// Test if the specified domain name is available.
        /// </summary>
        [Parameter(HelpMessage = "A string that identifies the domain to check, e.g. \"contoso.onmicrosoft.com\" - 27 characters maximum domain prefix + 16 maximum characters suffix for '.onmicrosoft.com' . ", Mandatory = true, Position = 0)]
        [ValidateLength(17, 43)]
        public string Domain { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet() { TestDomainAvailability(Domain); }

        /// <summary>
        /// Checks if domain name is available.
        /// </summary>
        /// <param name="domain">Domain to test.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="domain"/> is empty or null.
        /// </exception>
        private void TestDomainAvailability(string domain)
        {
            bool domainExists;

            domain.AssertNotEmpty(nameof(domain));

            domainExists = Partner.Domains.ByDomain(domain).Exists();
            WriteObject(!domainExists);
        }
    }
}