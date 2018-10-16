// -----------------------------------------------------------------------
// <copyright file="GetPartnerResellerRequestLink.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.CustomerRelationshipRequests;

    /// <summary>
    /// Get the resller relationship request link.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerResellerRequestLink"), OutputType(typeof(PSCustomerRelationshipRequest))]
    public class GetPartnerResellerRequestLink : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(new PSCustomerRelationshipRequest(Partner.Customers.RelationshipRequest.Get()));
        }
    }
}