// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerRelationship.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Relationships;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Relationships;

    /// <summary>
    /// Gets all the partner relationships associated to the customer based on the logged in partner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerRelationship"), OutputType(typeof(PSPartnerRelationship))]
    public class GetPartnerCustomerRelationship : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<PartnerRelationship> relationships;

            try
            {
                relationships = Partner.Customers[CustomerId].Relationships.Get();
                WriteObject(relationships.Items.Select(r => new PSPartnerRelationship(r)), true);
            }
            finally
            {
                relationships = null;
            }
        }
    }
}