// -----------------------------------------------------------------------
// <copyright file="ApiFault.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a failure with the API.
    /// </summary>
    [Serializable]
    public sealed class ApiFault : ResourceBase
    {
        /// <summary>
        /// Gets or sets the API error code.
        /// </summary>
        [JsonProperty("code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets additional fault information if present.
        /// </summary>
        [JsonProperty("data")]
        public IEnumerable<object> ErrorData { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty("description")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Returns a meaningful summary regarding the API fault.
        /// </summary>
        /// <returns>A meaningful summary regarding the fault.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine().AppendFormat("Error code: {0}", ErrorCode).AppendLine();
            stringBuilder.AppendFormat("Error message: {0}", ErrorMessage).AppendLine();

            if (ErrorData != null)
            {
                stringBuilder.AppendLine("Error data:");

                foreach (object obj in ErrorData)
                {
                    if (obj != null)
                    {
                        stringBuilder.AppendLine(obj.ToString());
                    }
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}