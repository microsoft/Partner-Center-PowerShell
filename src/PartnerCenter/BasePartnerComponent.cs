// -----------------------------------------------------------------------
// <copyright file="BasePartnerComponent.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter
{
    using System;

    /// <summary>
    /// Holds common partner component properties and behavior. All components should inherit from this class.
    /// </summary>
    /// <typeparam name="TContext">The context object type.</typeparam>
    internal abstract class BasePartnerComponent<TContext> : IPartnerComponent<TContext> where TContext : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePartnerComponent" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations that created this component.</param>
        /// <param name="componentContext">A component context object to work with.</param>
        protected BasePartnerComponent(IPartner rootPartnerOperations, TContext componentContext = null)
        {
            Partner = rootPartnerOperations ?? throw new ArgumentNullException(nameof(rootPartnerOperations));
            Context = componentContext;
        }

        /// <summary>
        /// Gets a reference to the partner operations instance that generated this component.
        /// </summary>
        public IPartner Partner { get; }

        /// <summary>
        /// Gets the component context object.
        /// </summary>
        public TContext Context { get; }
    }
}