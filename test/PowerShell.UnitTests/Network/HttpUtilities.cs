// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    using System;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Various utility functions for HTTP operations.
    /// </summary>
    public static class HttpUtilities
    {
        /// <summary>
        /// The regular expression to be used when checking if the HTTP content contains binary.
        /// </summary>
        private static readonly Regex binaryMimeRegex = new Regex("(image/*|audio/*|video/*|application/octet-stream|multipart/form-data)");

        /// <summary>
        /// Creates an instance of the <see cref="HttpContent" /> class that represents the content.
        /// </summary>
        /// <param name="contentData">The data used to build the HTTP content object.</param>
        /// <returns>An instance of the <see cref="HttpContent"/> that represents the content.</returns>
        public static HttpContent CreateHttpContent(string contentData)
        {
            HttpContent createdContent = null;
            byte[] hashBytes = null;
            bool isContentDataBinary = true;

            if (contentData != null)
            {
                try
                {
                    hashBytes = Convert.FromBase64String(contentData);

                    if (hashBytes != null)
                    {
                        createdContent = new ByteArrayContent(hashBytes);
                    }
                }
                catch
                {
                    isContentDataBinary = false;
                }

                if (!isContentDataBinary)
                {
                    createdContent = new StringContent(contentData);
                }
            }
            else
            {
                createdContent = new StringContent(string.Empty);
            }

            return createdContent;
        }

        /// <summary>
        /// Converts the HTTP content to a string literal.
        /// </summary>
        /// <param name="httpContent">The HTTP content to be converted.</param>
        /// <returns>A formatted string that represents the HTTP content.</returns>
        public static string FormatHttpContent(HttpContent httpContent)
        {
            string formattedContent = string.Empty;

            if (IsHttpContentBinary(httpContent))
            {
                formattedContent = Convert.ToBase64String(Task.Run(() => httpContent.ReadAsByteArrayAsync()).Result);
            }
            else
            {
                formattedContent = FormatString(httpContent.ReadAsStringAsync().Result);
            }

            return formattedContent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FormatString(string content)
        {
            if (IsJson(content))
            {
                return TryFormatJson(content);
            }
            else if (IsXml(content))
            {
                return TryFormatXml(content);
            }

            return content;
        }

        /// <summary>
        /// Checks if the content contains binary.
        /// </summary>
        /// <param name="content">The HTTP content to be checked.</param>
        /// <returns><c>true</c> if the content contains binary; otherwise <c>false</c>.</returns>
        public static bool IsHttpContentBinary(HttpContent content)
        {
            bool isBinary = false;
            string contentType = content?.Headers?.ContentType?.MediaType;

            if (!string.IsNullOrEmpty(contentType))
            {
                isBinary = binaryMimeRegex.IsMatch(contentType);
            }

            return isBinary;
        }

        /// <summary>
        /// Checks if the content is JSON.
        /// </summary>
        /// <param name="content">The content to be checked.</param>
        /// <returns><c>true</c> if the content is JSON; otherwise <c>false</c>.</returns>
        public static bool IsJson(string content)
        {
            content = content.Trim();

            return content.StartsWith("{", StringComparison.InvariantCultureIgnoreCase)
                && content.EndsWith("}", StringComparison.InvariantCultureIgnoreCase)
                   || content.StartsWith("[", StringComparison.InvariantCultureIgnoreCase)
                        && content.EndsWith("]", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Checks if the content is valid XML or not.
        /// </summary>
        /// <param name="content">The content to be checked.</param>
        /// <returns><c>true</c> if the content is XML; otherwise <c>false</c>.</returns>
        public static bool IsXml(string content)
        {
            try
            {
                XDocument.Parse(content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Formats the JSON using the appropriate indentation.
        /// </summary>
        /// <param name="content">The JSON to be formatted.</param>
        /// <returns>The formatted JSON string.</returns>
        public static string TryFormatJson(string content)
        {
            try
            {
                return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(content), Formatting.Indented);
            }
            catch
            {
                return content;
            }
        }

        /// <summary>
        /// Formats the XML using the appropriate indentation.
        /// </summary>
        /// <param name="content">The XML to be formatted.</param>
        /// <returns>The formatted XML string.</returns>
        public static string TryFormatXml(string content)
        {
            try
            {
                return XDocument.Parse(content).ToString();
            }
            catch
            {
                return content;
            }
        }
    }
}