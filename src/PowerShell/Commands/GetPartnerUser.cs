// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;
    using Models;

    [Cmdlet(VerbsCommon.Get, "PartnerUser"), OutputType(typeof(Microsoftgraphuser))]
    public class GetPartnerUser : PartnerCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            UserClient client = PartnerSession.Instance.ClientFactory.CreateServiceClient<UserClient>(new[] { $"{PartnerSession.Instance.Context.Environment.GraphEndpoint}/.default" });
            Pathsusersgetresponses200contentapplicationJsonschema data = client.Usersuser.ListUserAsync(null, null, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(data.Value, true);
        }
    }
}