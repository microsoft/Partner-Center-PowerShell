// -----------------------------------------------------------------------
// <copyright file="GetPartnerIndirectReseller.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Relationships;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Relationships;

    /// <summary>
    /// Gets a list of indirect resellers from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerIndirectReseller"), OutputType(typeof(PSPartnerRelationship))]
    public class GetPartnerIndirectReseller : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<PartnerRelationship> resellers;

            try
            {
                resellers = Partner.Relationships.Get(PartnerRelationshipType.IsIndirectCloudSolutionProviderOf);

                WriteObject(resellers.Items.Select(r => new PSPartnerRelationship(r)), true);
            }
            finally
            {
                resellers = null;
            }
        }
    }
}