// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Graph;

    [Cmdlet(VerbsCommon.Get, "PartnerUserSignInActivity"), OutputType(typeof(SignIn))]
    public class GetPartnerUserSignInActivity : PartnerPSCmdlet
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
            List<SignIn> activities = new List<SignIn>();
            List<QueryOption> queryOptions = null;
            string filter = string.Empty;

            if (StartDate != null)
            {
                filter = AppendValue(filter, $"createdDateTime gt {StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            }

            if (EndDate != null)
            {
                filter = AppendValue(filter, $"createdDateTime ls {EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")}");
            }

            if (!string.IsNullOrEmpty(UserId))
            {
                filter = AppendValue(filter, $"userId eq '{UserId}'");
            }

            if (!string.IsNullOrEmpty(filter))
            {
                queryOptions = new List<QueryOption>
                {
                    new QueryOption("$filter", $"({filter})")
                };
            }

            IAuditLogRootSignInsCollectionPage data = Graph
                .AuditLogs.SignIns.Request(queryOptions).GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            activities.AddRange(data.CurrentPage);

            while (data.NextPageRequest != null)
            {
                data = data.NextPageRequest.GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                activities.AddRange(data.CurrentPage);
            }

            WriteObject(data.CurrentPage, true);
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