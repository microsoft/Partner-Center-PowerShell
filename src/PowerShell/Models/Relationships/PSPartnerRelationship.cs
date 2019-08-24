// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Relationships
{
    using Extensions;
    using PartnerCenter.Models.Relationships;

    /// <summary>
    /// This represents a relationship between two partners.
    /// </summary>
    public sealed class PSPartnerRelationship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerRelationship" /> class.
        /// </summary>
        public PSPartnerRelationship()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerRelationship" /> class.
        /// </summary>
        /// <param name="relationship">The base relationship for this instance.</param>
        public PSPartnerRelationship(PartnerRelationship relationship)
        {
            this.CopyFrom(relationship, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the location of the partner.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or set the MPN identifier
        /// </summary>
        public string MpnId { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner who is in the recipient (from) side of the relationship.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier. 
        /// </summary>
        /// <remarks>
        /// The partner identifier specifies tenant identifier of the 
        /// partner who is in the recipient (from) side of relationship.
        /// </remarks>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the type of the relationship.
        /// </summary>
        public PartnerRelationshipType RelationshipType { get; set; }

        /// <summary>
        /// Gets or sets the state of the relationship.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="PartnerRelationship" /> to an instance of <see cref="PSPartnerRelationship" />. 
        /// </summary>
        /// <param name="relationship">The relationship being cloned.</param>
        private void CloneAdditionalOperations(PartnerRelationship relationship)
        {
            PartnerId = relationship.Id;
        }
    }
}