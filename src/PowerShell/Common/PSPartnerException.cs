// -----------------------------------------------------------------------
// <copyright file="PSPartnerException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Exceptions
{
    using System;
    using System.ComponentModel;
    using System.Management.Automation;
    using System.Reflection;
    using System.Runtime.Serialization;
    using PartnerCenter.Exceptions;

    [Serializable]
    public class PSPartnerException : PSInvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerException" /> class.
        /// </summary>
        public PSPartnerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PSPartnerException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerException" /> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public PSPartnerException(string message, Exception innerException) : base(GetApiError(message, innerException), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PSPartnerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private static string GetApiError(string message, Exception innerException)
        {
            PartnerException ex = (PartnerException)innerException;
            ApiError error = (ApiError)Enum.Parse(typeof(ApiError), ex.ServiceErrorPayload.ErrorCode);
            return string.IsNullOrEmpty(message) ? "ErrorCode : " + ex.ServiceErrorPayload.ErrorCode + " - " + GetEnumDescription(error) : message + " - ErrorCode: " + ex.ServiceErrorPayload.ErrorCode + " - " + GetEnumDescription(error);
        }

        public enum ApiError
        {
            [Description("Unknown error")]
            Unknown = 0,
            [Description("Product was not found")]
            ProductNotFound = 400013,
            [Description("Sku was not found")]
            SkuNotFound = 400018,
            [Description("A required inventory context item is missing")]
            InventoryContextMissing = 400026,
            [Description("Access to the requested segment is not allowed")]
            SegmentNotAllowed = 400030,
            [Description("Access to the requested catalog is not allowed")]
            CatalogNotAllowed = 400036
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}