// -----------------------------------------------------------------------
// <copyright file="PartnerPSException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// User defined exception type that is thrown when an error is encountered communication with the Partner Center API.
    /// </summary>
    /// <seealso cref="Exception" />
    /// <seealso cref="ISerializable" />
    [Serializable]
    public class PartnerPSException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPSException"/> class.
        /// </summary>
        public PartnerPSException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPSException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PartnerPSException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPSException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public PartnerPSException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPSException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PartnerPSException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

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

            base.GetObjectData(info, context);
        }
    }
}