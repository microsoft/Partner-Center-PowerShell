// -----------------------------------------------------------------------
// <copyright file="PartnerException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Models;
    using RequestContext;

    /// <summary>
    /// The standard exception thrown by the partner service. This pertains to errors accessing the partner service. Other standard exceptions
    /// such as null argument exceptions will also be thrown in case of malformed input.
    /// </summary>
    [Serializable]
    public class PartnerException : Exception
    {
        /// <summary>
        /// The error category field name used in serialization.
        /// </summary>
        private const string ErrorCategoryFieldName = "ErrorCategory";

        /// <summary>
        /// The partner context field name used in serialization.
        /// </summary>
        private const string PartnerContextFieldName = "PartnerContext";

        /// <summary>
        /// The service error payload field name used in serialization.
        /// </summary>
        private const string ServiceErrorPayloadFieldName = "ServiceErrorCode";
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerException" /> class.
        /// </summary>
        public PartnerException()
        {
            ErrorCategory = PartnerErrorCategory.NotSpecified;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PartnerException(string message) : base(message)
        {
            ErrorCategory = PartnerErrorCategory.NotSpecified;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public PartnerException(string message, Exception innerException) : base(message, innerException)
        {
            ErrorCategory = PartnerErrorCategory.NotSpecified;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="context">The context for the request.</param>
        /// <param name="errorCategory">The category for the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public PartnerException(
            string message,
            IRequestContext context,
            PartnerErrorCategory errorCategory = PartnerErrorCategory.NotSpecified,
            Exception innerException = null) : base(message, innerException)
        {
            Context = context;
            ErrorCategory = errorCategory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PartnerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCategory = (PartnerErrorCategory)info.GetInt32(nameof(ErrorCategory));
            Context = info.GetValue(PartnerContextFieldName, typeof(IRequestContext)) as IRequestContext;
            ServiceErrorPayload = info.GetValue(ServiceErrorPayloadFieldName, typeof(ApiFault)) as ApiFault;
        }

        /// <summary>
        /// Gets the error classification that resulted in this exception.
        /// </summary>
        public PartnerErrorCategory ErrorCategory { get; protected set; }

        /// <summary>
        /// Gets the partner context associated with the exception.
        /// </summary>
        public IRequestContext Context { get; protected set; }

        /// <summary>
        /// Gets the service error payload.
        /// </summary>
        public ApiFault ServiceErrorPayload { get; protected set; }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(ErrorCategoryFieldName, ErrorCategory);
            info.AddValue(PartnerContextFieldName, Context);
            info.AddValue(ServiceErrorPayloadFieldName, ServiceErrorPayload);

            base.GetObjectData(info, context);
        }
    }
}