// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when an error occurs with Partner Center PowerShell.
    /// </summary>
    public class PartnerPowerShellException : Exception
    {
        /// <summary>
        /// The error category field name used in serialization.
        /// </summary>
        private const string ErrorCategoryFieldName = "ErrorCategory";

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPowerShellException" /> class.
        /// </summary>
        public PartnerPowerShellException()
        {
            ErrorCategory = PartnerPowerShellErrorCategory.NotSpecified;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPowerShellException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PartnerPowerShellException(string message)
            : base(message)
        {
            ErrorCategory = PartnerPowerShellErrorCategory.NotSpecified;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPowerShellException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorCategory">The error classification that resulted in this exception.</param>
        public PartnerPowerShellException(string message, PartnerPowerShellErrorCategory errorCategory)
            : base(message)
        {
            ErrorCategory = errorCategory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPowerShellException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public PartnerPowerShellException(string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCategory = PartnerPowerShellErrorCategory.NotSpecified;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPowerShellException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        /// <param name="errorCategory">The error classification that resulted in this exception.</param>
        public PartnerPowerShellException(string message, Exception innerException, PartnerPowerShellErrorCategory errorCategory)
            : base(message, innerException)
        {
            ErrorCategory = errorCategory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerPowerShellException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PartnerPowerShellException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCategory = (PartnerPowerShellErrorCategory)info.GetInt32(nameof(ErrorCategory));
        }

        /// <summary>
        /// Gets the error classification that resulted in this exception.
        /// </summary>
        public PartnerPowerShellErrorCategory ErrorCategory { get; }

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
            info.AssertNotNull(nameof(info));

            info.AddValue(ErrorCategoryFieldName, ErrorCategory);

            base.GetObjectData(info, context);
        }
    }
}