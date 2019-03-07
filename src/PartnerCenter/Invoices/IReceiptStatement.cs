// -----------------------------------------------------------------------
// <copyright file="IReceiptStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.IO;
    using GenericOperations;

    /// <summary>
    /// Represents the operations available to an invoice statement.
    /// </summary>
    public interface IReceiptStatement : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<Stream>
    {
    }
}