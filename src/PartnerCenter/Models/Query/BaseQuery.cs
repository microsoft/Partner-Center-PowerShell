// -----------------------------------------------------------------------
// <copyright file="BaseQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System;

    /// <summary>
    /// The base class which all queries should derive from. This class does not support any query capabilities except for the token by default.
    /// Therefore, implementation classes will pick and choose what to support.
    /// </summary>
    internal abstract class BaseQuery : IQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQuery" /> class.
        /// </summary>
        /// <param name="token">An optional query token.</param>
        protected BaseQuery(object token = null)
        {
            Token = token;
        }

        /// <summary>
        /// Gets the query type.
        /// </summary>
        public virtual QueryType Type => throw new NotImplementedException();

        /// <summary>
        /// Gets or sets the query filter.
        /// </summary>
        public virtual FieldFilter Filter
        {
            get => throw new InvalidOperationException("Filter is not supported.");
            set => throw new InvalidOperationException("Filter is not supported.");
        }

        /// <summary>
        /// Gets or sets the query sorting options.
        /// </summary>
        public virtual Sort Sort
        {
            get => throw new InvalidOperationException("Sort is not supported.");
            set => throw new InvalidOperationException("Sort is not supported.");
        }

        /// <summary>
        /// Gets or sets the result starting index.
        /// </summary>
        public virtual int Index
        {
            get => throw new InvalidOperationException("Index is not supported.");
            set => throw new InvalidOperationException("Index is not supported.");
        }

        /// <summary>
        /// Gets or sets the results page size.
        /// </summary>
        public virtual int PageSize
        {
            get => throw new InvalidOperationException("PageSize is not supported.");
            set => throw new InvalidOperationException("PageSize is not supported.");
        }

        /// <summary>
        /// Gets or sets the seek token.
        /// </summary>
        public object Token { get; set; }

        /// <summary>
        /// Gets or sets the seek operation that needs to be performed.
        /// </summary>
        public virtual SeekOperation SeekOperation
        {
            get => throw new InvalidOperationException("SeekOperation is not supported.");
            set => throw new InvalidOperationException("SeekOperation is not supported.");
        }
    }
}