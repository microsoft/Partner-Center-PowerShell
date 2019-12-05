// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Graph;
    using Models.Authentication;
    using Network;
    using Properties;

    [Cmdlet(VerbsCommon.Get, "PartnerUserSignInActivity"), OutputType(typeof(SignIn))]
    public class GetPartnerUserSignInActivity : PartnerAsyncCmdlet
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
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (PartnerSession.Instance.Context == null)
            {
                throw new PSInvalidOperationException(Resources.RunConnectPartnerCenter);
            }

            base.BeginProcessing();
        }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
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

            Scheduler.RunTask(async () =>
            {
                List<SignIn> activities;
                List<QueryOption> queryOptions = null;

                if (!string.IsNullOrEmpty(filter))
                {
                    queryOptions = new List<QueryOption>
                    {
                        new QueryOption("$filter", $"({filter})")
                    };
                }

                GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as GraphServiceClient;
                client.AuthenticationProvider = new GraphAuthenticationProvider();

                IAuditLogRootSignInsCollectionPage data = await client
                    .AuditLogs.SignIns.Request(queryOptions).GetAsync(CancellationToken).ConfigureAwait(false);

                activities = new List<SignIn>(data.CurrentPage);

                while (data.NextPageRequest != null)
                {
                    data = await data.NextPageRequest.GetAsync(CancellationToken).ConfigureAwait(false);
                    activities.AddRange(data.CurrentPage);
                }

                WriteObject(activities, true);
            });
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