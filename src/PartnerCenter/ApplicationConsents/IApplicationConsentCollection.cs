// -----------------------------------------------------------------------
// <copyright file="IApplicationConsentCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ApplicationConsents
{
    using GenericOperations;
    using Models;
    using Models.ApplicationConsents;

    public interface IApplicationConsentCollection : IPartnerComponent<string>, IEntityCreateOperations<ApplicationConsent, ApplicationConsent>
    {
    }
}