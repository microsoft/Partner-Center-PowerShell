// -----------------------------------------------------------------------
// <copyright file="AuthenticationException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception that is throw when an authentication error is encountered.
    /// </summary>
    [Serializable]
    public class AuthenticationException : Exception
    {
        /// <summary>
        /// The error code field name used in serialization.
        /// </summary>
        [NonSerialized]
        private const string ErrorCodeFieldName = "ErrorCode";

        /// <summary>
        /// The error code encountering when authenticating.
        /// </summary>
        [NonSerialized]
        private readonly string errorCode; 

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException" /> class.
        /// </summary>
        public AuthenticationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AuthenticationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorCode">The error code encountered when authenticating.</param>
        public AuthenticationException(string errorCode, string message) : base(message)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected AuthenticationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            errorCode = info.GetValue(ErrorCodeFieldName, typeof(string)) as string;
        }

        /// <summary>
        /// Gets the error code encountered when authenticating.
        /// </summary>
        public string ErrorCode => errorCode;

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

            info.AddValue(ErrorCodeFieldName, errorCode);

            base.GetObjectData(info, context);
        }
    }
}