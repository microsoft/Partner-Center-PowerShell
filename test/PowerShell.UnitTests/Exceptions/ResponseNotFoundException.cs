// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class ResponseNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseNotFoundException" /> class.
        /// </summary>
        public ResponseNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ResponseNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ResponseNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseNotFoundException"/> class.
        /// </summary>
        /// <param name="info">The serialization information that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The context that contains contextual information about the source or destination.</param>
        protected ResponseNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// When overridden in a derived class, sets the serialization information with information about the exception.
        /// </summary>
        /// <param name="info">The serialization information that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The context that contains contextual information about the source or destination.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
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