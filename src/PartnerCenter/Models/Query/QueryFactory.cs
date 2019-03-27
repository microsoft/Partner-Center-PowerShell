// -----------------------------------------------------------------------
// <copyright file="QueryFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System;

    /// <summary>
    /// Factory used to create instances of <see cref="IQuery" /> objects.
    /// </summary>
    public static class QueryFactory
    {
        /// <summary>Builds a simple query.</summary>
        /// <param name="filter">An optional filter.</param>
        /// <param name="sortOption">Optional sorting options.</param>
        /// <param name="token">Optional query token.</param>
        /// <returns>A simple query.</returns>
        public static IQuery BuildSimpleQuery(FieldFilter filter = null, Sort sortOption = null, object token = null)
        {
            SimpleQuery simpleQuery = new SimpleQuery
            {
                Filter = filter,
                Sort = sortOption,
                Token = token
            };

            return simpleQuery;
        }

        /// <summary>Builds an indexed query.</summary>
        /// <param name="pageSize">The number of results to return.</param>
        /// <param name="index">The results starting index.</param>
        /// <param name="filter">An optional filter.</param>
        /// <param name="sortOption">Optional sorting options.</param>
        /// <param name="token">Optional query token.</param>
        /// <returns>A paged query.</returns>
        public static IQuery BuildIndexedQuery(int pageSize, int index = 0, FieldFilter filter = null, Sort sortOption = null, object token = null)
        {
            IndexedQuery indexedQuery = new IndexedQuery
            {
                PageSize = pageSize,
                Index = index,
                Filter = filter,
                Sort = sortOption,
                Token = token
            };

            return indexedQuery;
        }

        /// <summary>Builds a count query.</summary>
        /// <param name="filter">An optional filter.</param>
        /// <param name="token">Optional query token.</param>
        /// <returns>A count query.</returns>
        public static IQuery BuildCountQuery(FieldFilter filter = null, object token = null)
        {
            CountQuery countQuery = new CountQuery
            {
                Filter = filter,
                Token = token
            };

            return countQuery;
        }

        /// <summary>Builds a seek query.</summary>
        /// <param name="seekOperation">The seek operation to perform.</param>
        /// <param name="pageSize">The desired result page size.</param>
        /// <param name="index">The index of the page to retrieve. This is only used if the seek operation specified a page index.</param>
        /// <param name="filter">An optional filter to apply.</param>
        /// <param name="sortingOption">An optional sorting options.</param>
        /// <param name="token">An optional query token.</param>
        /// <returns>The seek query.</returns>
        public static IQuery BuildSeekQuery(SeekOperation seekOperation, int pageSize = 0, int index = 0, FieldFilter filter = null, Sort sortingOption = null, object token = null)
        {
            SeekQuery seekQuery = new SeekQuery
            {
                SeekOperation = seekOperation,
                PageSize = pageSize,
                Index = index,
                Filter = filter,
                Sort = sortingOption,
                Token = token
            };

            return seekQuery;
        }
    }
}