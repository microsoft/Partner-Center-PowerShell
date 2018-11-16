// -----------------------------------------------------------------------
// <copyright file="BasePartnerComponentString.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core
{
    /// <summary>
    /// Holds common partner component properties and behavior. The context is string type by default.
    /// </summary>
    internal abstract class BasePartnerComponent : BasePartnerComponent<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePartnerComponent" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations that created this component.</param>
        /// <param name="componentContext">A component context object to work with.</param>
        protected BasePartnerComponent(IPartner rootPartnerOperations, string componentContext = null)
            : base(rootPartnerOperations, componentContext)
        {
        }
    }
}