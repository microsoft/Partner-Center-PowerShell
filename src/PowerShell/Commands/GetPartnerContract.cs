using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Enumerators;
    using Models.Customers;
    using Graph;
    using Models.Authentication;
    using PartnerCenter.Models.Query;

    /// <summary>
    /// Get a customer, or a list of customers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerContract"), OutputType(typeof(Contract))]
    public class GetPartnerContract : PartnerCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IGraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient();

            IGraphServiceContractsCollectionPage data = client.Contracts.Request().GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(data.CurrentPage, true);
        }
    }
}