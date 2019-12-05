// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Xml.Linq;
    using Extensions;
    using Newtonsoft.Json;
    using Rest;

    /// <summary>
    /// Provides useful information about operations that are performed.
    /// </summary>
    public class RecordingTracingInterceptor : IServiceClientTracingInterceptor
    {
        /// <summary>
        /// The queue where message will be enqueued for output.
        /// </summary>
        private readonly ConcurrentQueue<string> messageQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordingTracingInterceptor" /> class.
        /// </summary>
        /// <param name="messageQueue">The queue where message will be enqueued for output.</param>
        public RecordingTracingInterceptor(ConcurrentQueue<string> messageQueue)
        {
            messageQueue.AssertNotNull(nameof(messageQueue));

            this.messageQueue = messageQueue;
        }

        /// <summary>
        /// Probe configuration for the value of a setting
        /// </summary>
        /// <param name="source">The configuration source.</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value"> The value of the setting in the source.</param>
        public void Configuration(string source, string name, string value)
        {
        }

        /// <summary>
        /// Enter a method.
        /// </summary>
        /// <param name="invocationId">The method invocation identifier.</param>
        /// <param name="instance">The instance with the method.</param>
        /// <param name="method">The name of the method.</param>
        /// <param name="parameters">The parameters provided during the method invociation.</param>
        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
        }

        /// <summary>
        /// Exit a method. Note: Exit will not be called in the event of an error.
        /// </summary>
        /// <param name="invocationId">The method invocation identifier.</param>
        /// <param name="returnValue">The value returned from the method invocation.</param>
        public void ExitMethod(string invocationId, object returnValue)
        {
        }

        /// <summary>
        /// Handles the request to trace information.
        /// </summary>
        /// <param name="message">The information to trace.</param>
        public void Information(string message)
        {
            messageQueue.Enqueue(message);
        }

        /// <summary>
        /// Receive an HTTP response.
        /// </summary>
        /// <param name="invocationId">The method invocation identifier.</param>
        /// <param name="response">The response from the HTTP operation.</param>
        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"============================ HTTP RESPONSE ============================");
            output.AppendLine($"Status Code:{Environment.NewLine}{response.StatusCode}{Environment.NewLine}");
            output.AppendLine($"Headers:");

            foreach (KeyValuePair<string, IEnumerable<string>> item in response.Headers.ToDictionary(h => h.Key, h => h.Value).ToArray())
            {
                output.AppendLine(string.Format(
                    "{0,-30}: {1}",
                    item.Key,
                    string.Join(",", item.Value)));
            }

            if (response.Content != null)
            {
                output.AppendLine(string.Empty);
                output.AppendLine("Body:");
                output.AppendLine(FormatString(response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult()));
            }

            messageQueue.Enqueue(output.ToString());
        }

        /// <summary>
        /// Send an HTTP request.
        /// </summary>
        /// <param name="invocationId">The method invocation identifier.</param>
        /// <param name="request">The HTTP request to be sent.</param>
        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"============================ HTTP REQUEST ============================");
            output.AppendLine($"HTTP Method:{Environment.NewLine}{request.Method}{Environment.NewLine}");
            output.AppendLine($"Absolute Uri:{Environment.NewLine}{request.RequestUri}{Environment.NewLine}");
            output.AppendLine($"Headers:");

            foreach (KeyValuePair<string, IEnumerable<string>> item in request.Headers.Where(h => !h.Key.Equals("Authorization")).ToDictionary(h => h.Key, h => h.Value).ToArray())
            {
                output.AppendLine(string.Format(
                    "{0,-30}: {1}",
                    item.Key,
                    string.Join(",", item.Value)));
            }

            if (request.Content != null)
            {
                output.AppendLine(string.Empty);
                output.AppendLine("Body:");
                output.AppendLine(FormatString(request.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult()));
            }

            messageQueue.Enqueue(output.ToString());
        }

        /// <summary>
        /// Provides the ability to trace an error.
        /// </summary>
        /// <param name="invocationId">The method invocation identifier.</param>
        /// <param name="exception">The exception that was thrown during the method invocation.</param>
        public void TraceError(string invocationId, Exception exception)
        {
        }

        /// <summary>
        /// Formats the content based on the type.
        /// </summary>
        /// <param name="content">The content to be formatted.</param>
        /// <returns>A string that contains the formatted content.</returns>
        private static string FormatString(string content)
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