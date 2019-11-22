// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net.Http;
    using Rest;

    public class RecordingTracingInterceptor : IServiceClientTracingInterceptor
    {
        public RecordingTracingInterceptor(ConcurrentQueue<string> queue)
        {
            MessageQueue = queue;
        }

        public ConcurrentQueue<string> MessageQueue { get; private set; }

        public void Configuration(string source, string name, string value)
        {
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
        }

        public void Information(string message)
        {
            MessageQueue.Enqueue(message);
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
        }

        public void TraceError(string invocationId, Exception exception)
        {
        }
    }
}
