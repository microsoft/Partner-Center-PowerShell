// -----------------------------------------------------------------------
// <copyright file="IClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;

    /// <summary>
    /// Represents a factory that provides initialized clients used to interact with online services.
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        IPartner CreatePartnerOperations(Action<string> debugAction);
    }
}