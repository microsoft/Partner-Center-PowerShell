// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication;
    using Models;

    [Cmdlet(VerbsCommon.Get, "PartnerUserSignInActivity"), OutputType(typeof(MicrosoftgraphsignIn))]
    public class GetPartnerUserSignInActivity : PartnerCmdlet
    {
        /// <summary>
        /// Gets or sets the end date porition of the query.
        /// </summary>
        [Parameter(HelpMessage = "The end date of the activity logs.", Mandatory = false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start date porition of the query.
        /// </summary>
        [Parameter(HelpMessage = "The start date of the activity logs.", Mandatory = false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the user.", Mandatory = false)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<MicrosoftgraphsignIn> activities = new List<MicrosoftgraphsignIn>();
            PathsauditlogsSigninsgetresponses200contentapplicationJsonschema data;
            string filter = string.Empty;

            if (StartDate != null)
            {
                filter = AppendValue(filter, $"createdDateTime ge {StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            }

            if (EndDate != null)
            {
                filter = AppendValue(filter, $"createdDateTime le {EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            }

            if (!string.IsNullOrEmpty(UserId))
            {
                filter = AppendValue(filter, $"userId eq '{UserId}'");
            }

            AuditLogClient client = PartnerSession.Instance.ClientFactory.CreateServiceClient<AuditLogClient>(new[] { $"{PartnerSession.Instance.Context.Environment.GraphEndpoint}/.default" });

            if (!string.IsNullOrEmpty(filter))
            {
                client.Filter = filter;
            }

            data = client.AuditLogs.ListSignInsAsync(null, null, null, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(data.Value, true);
        }

        private static string AppendValue(string baseValue, string appendValue)
        {
            if (string.IsNullOrEmpty(baseValue))
            {
                return appendValue;
            }

            return $"{baseValue} and {appendValue}";
        }
    }
}