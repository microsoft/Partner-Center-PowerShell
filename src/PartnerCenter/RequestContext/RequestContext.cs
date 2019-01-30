// -----------------------------------------------------------------------
// <copyright file="RequestContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RequestContext
{
    using System;

    /// <summary>
    /// Implementation of the request context.
    /// </summary>
    internal class RequestContext : IRequestContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        public RequestContext() : this(Guid.NewGuid(), Guid.Empty, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        /// <param name="correlationId">The correlation identifier used to group logical operations together.</param>
        public RequestContext(Guid correlationId) : this(correlationId, Guid.Empty, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        /// <param name="locale">The locale to be used for the oepration.</param>
        public RequestContext(string locale) : this(Guid.NewGuid(), Guid.Empty, locale)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        /// <param name="correlationId">The correlation identifier used to group logical operations together.</param>
        /// <param name="locale">The locale to be used for the oepration.</param>
        public RequestContext(Guid correlationId, string locale) : this(correlationId, Guid.Empty, locale)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext" /> class.
        /// </summary>
        /// <param name="correlationId">The correlation identifier used to group logical operations together.</param>
        /// <param name="requestId">The request identifier that uniquely identifies the operation.</param>
        /// <param name="locale">The locale to be used for the oepration.</param>
        public RequestContext(Guid correlationId, Guid requestId, string locale = null)
        {
            CorrelationId = correlationId;
            Locale = string.IsNullOrEmpty(locale) ? PartnerService.Instance.Configuration.DefaultLocale : locale;
            RequestId = requestId;
        }

        /// <summary>
        /// Gets the correlation identifier used to group logical operations together.
        /// </summary>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// Gets the locale to be used for the oepration.
        /// </summary>
        public string Locale { get; private set; }

        /// <summary>
        /// Gets the request identifier that uniquely identifies the operation.
        /// </summary>
        public Guid RequestId { get; private set; }
    }
}