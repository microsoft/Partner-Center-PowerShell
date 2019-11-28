// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using Models;
    using Models.Authentication;
    using Utilities;

    public abstract class PartnerAsyncCmdlet : PartnerPSCmdlet
    {
        private const string WriteDebugKey = "WriteDebug";

        private const string WriteObjectKey = "WriteObject";

        private const string WriteWarningKey = "WriteWarning";

        private const int WaitTimeout = 1000;

        private readonly ConcurrentQueue<Task> outputTasks = new ConcurrentQueue<Task>();

        private event EventHandler<StreamEventArgs> WriteDebugEvent;

        private event EventHandler<StreamEventArgs> WriteObjectEvent;

        private event EventHandler<StreamEventArgs> WriteWarningEvent;

        public LimitedConcurrencyTaskScheduler Scheduler { get; private set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            Scheduler = new LimitedConcurrencyTaskScheduler(1000, CancellationToken);

            WriteDebugEvent -= WriteDebugSender;
            WriteDebugEvent += WriteDebugSender;

            WriteObjectEvent -= WriteObjectSender;
            WriteObjectEvent += WriteObjectSender;

            WriteWarningEvent -= WriteWarningSender;
            WriteWarningEvent += WriteWarningSender;

            PartnerSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteDebugKey);
            PartnerSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteObjectKey);
            PartnerSession.Instance.UnregisterComponent<EventHandler<StreamEventArgs>>(WriteWarningKey);

            PartnerSession.Instance.RegisterComponent(WriteDebugKey, () => WriteDebugEvent);
            PartnerSession.Instance.RegisterComponent(WriteObjectKey, () => WriteObjectEvent);
            PartnerSession.Instance.RegisterComponent(WriteWarningKey, () => WriteWarningEvent);
        }

        protected override void EndProcessing()
        {
            do
            {
                while (outputTasks.TryDequeue(out Task task))
                {
                    task?.RunSynchronously();
                }
            }
            while (!Scheduler.WaitForComplete(WaitTimeout, CancellationToken));

            if (!outputTasks.IsEmpty)
            {
                while (outputTasks.TryDequeue(out Task task))
                {
                    task?.RunSynchronously();
                }
            }

            base.EndProcessing();
        }

        protected new void WriteDebug(string message)
        {
            if (PartnerSession.Instance.TryGetComponent(WriteDebugKey, out EventHandler<StreamEventArgs> writeObjectEvent))
            {
                writeObjectEvent(this, new StreamEventArgs() { Message = message });
            }
        }

        /// <summary>
        /// Writes the object the pipeline.
        /// </summary>
        /// <param name="sendToPipeline">The object to be written to the pipeline.</param>
        protected new void WriteObject(object sendToPipeline)
        {
            if (PartnerSession.Instance.TryGetComponent(WriteObjectKey, out EventHandler<StreamEventArgs> writeObjectEvent))
            {
                writeObjectEvent(this, new StreamEventArgs() { Resource = sendToPipeline });
            }
        }

        /// <summary>
        /// Writes the warning message to the pipeline.
        /// </summary>
        /// <param name="text">The message to be written to the pipeline.</param>
        protected new void WriteWarning(string message)
        {
            if (PartnerSession.Instance.TryGetComponent(WriteWarningKey, out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs() { Message = message });
            }
        }

        private void WriteDebugSender(object send, StreamEventArgs args)
        {
            outputTasks.Enqueue(new Task(() => base.WriteDebug(args.Message)));
        }

        private void WriteObjectSender(object send, StreamEventArgs args)
        {
            outputTasks.Enqueue(new Task(() => base.WriteObject(args.Resource)));
        }

        private void WriteWarningSender(object sender, StreamEventArgs args)
        {
            outputTasks.Enqueue(new Task(() => base.WriteWarning(args.Message)));
        }
    }
}