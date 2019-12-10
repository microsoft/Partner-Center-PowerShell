// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Graph;
    using Models.Authentication;
    using System.Collections.Generic;
    using Network;
    using System.Threading.Tasks;

    [Cmdlet(VerbsCommon.Get, "PartnerUserSignInActivity"), OutputType(typeof(SignIn))]
    public class GetPartnerUserSignInActivity : PartnerAsyncCmdlet
    {
        /// <summary>
        /// The error code thrown when attempting to request sign activites at the tenant level from a tenant that does not have Azure AD Premium.
        /// </summary>
        private const string RequestFromNonPremiumTenant = "Authentication_RequestFromNonPremiumTenantOrB2CTenant";

        /// <summary>
        /// Gets or sets the end date portion of the query.
        /// </summary>
        [Parameter(HelpMessage = "The end date of the activity logs.", Mandatory = false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start date portion of the query.
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
            Scheduler.RunTask(async () =>
            {
                GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as GraphServiceClient;
                IAuditLogRootSignInsCollectionPage collection;
                List<QueryOption> queryOptions = null;
                List<SignIn> signIns;
                string filter = string.Empty;

                client.AuthenticationProvider = new GraphAuthenticationProvider();

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

                if (!string.IsNullOrEmpty(filter))
                {
                    queryOptions = new List<QueryOption>
                        {
                            new QueryOption("$filter", $"({filter})")
                        };
                }

                collection = await client.AuditLogs.SignIns.Request(queryOptions).Top(500).GetAsync(CancellationToken).ConfigureAwait(false);
                signIns = new List<SignIn>(collection.CurrentPage);

                while (collection.NextPageRequest != null)
                {
                    collection = await collection.NextPageRequest.GetAsync(CancellationToken).ConfigureAwait(false);
                    signIns.AddRange(collection.CurrentPage);
                }


                WriteObject(signIns, true);
            }, true);
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