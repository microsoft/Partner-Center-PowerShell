// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Graph;

    [Cmdlet(VerbsCommon.Get, "PartnerUser"), OutputType(typeof(User))]
    public class GetPartnerUser : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IGraphServiceUsersCollectionPage data = Graph.Users.Request().GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            List<User> users = new List<User>();

            users.AddRange(data.CurrentPage);

            while (data.NextPageRequest != null)
            {
                data = data.NextPageRequest.GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                users.AddRange(data.CurrentPage);
            }

            WriteObject(users, true);
        }
    }
}