﻿// -----------------------------------------------------------------------
// <copyright file="MockClientFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories
{
    using System;
    using PowerShell.Factories;
    using Profile;

    /// <summary>
    /// Factory that provides initialized clients used to mock interactions with online services.
    /// </summary>
    public class MockClientFactory : IClientFactory
    {
        /// <summary>
        /// Delegate used to initialize the partner operations.
        /// </summary>
        private readonly Func<PartnerContext, IAggregatePartner> initializeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockClientFactory" /> class.
        /// </summary>
        public MockClientFactory(Func<PartnerContext, IAggregatePartner> initializeFunc)
        {
            this.initializeFunc = initializeFunc;
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public IAggregatePartner CreatePartnerOperations(PartnerContext context)
        {
            return initializeFunc(context);
        }
    }
}