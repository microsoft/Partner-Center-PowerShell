// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Authentication;
    using Properties;

    /// <summary>
    /// Provides the ability to schedule task and limit the concurrency.
    /// </summary>
    public class ConcurrencyTaskScheduler : IDisposable
    {
        /// <summary>
        /// The cancellation used by other objects or threads to receive notice of cancellation.
        /// </summary>
        private readonly CancellationToken cancellationToken;

        /// <summary>
        /// The queue of tasks to be invoked.
        /// </summary>
        private readonly ConcurrentQueue<Tuple<long, Func<Task>>> taskQueue;

        /// <summary>
        /// The queue of status for each task.
        /// </summary>
        private readonly ConcurrentDictionary<long, bool> taskStatus;

        /// <summary>
        /// The synchronization primitive that is signaled when its count reaches zero.
        /// </summary>
        private readonly CountdownEvent taskCounter;

        /// <summary>
        /// The maxium number of tasks that can be running at once.
        /// </summary>
        private readonly int maxConcurrency;

        /// <summary>
        /// A flag that indicates whether or not this object has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// A flag that indicates whether or not the first wait has occurred.
        /// </summary>
        private bool isFirstWait;

        /// <summary>
        /// The number of active tasks.
        /// </summary>
        private long activeTaskCount = 0;

        /// <summary>
        /// The number of failed tasks.
        /// </summary>
        private long failedTaskCount = 0;

        /// <summary>
        /// The number of finished tasks.
        /// </summary>
        private long finishedTaskCount = 0;

        /// <summary>
        /// The total number of tasks.
        /// </summary>
        private long totalTaskCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrencyTaskScheduler" /> class.
        /// </summary>
        /// <param name="maxConcurrency">The maxium number of tasks that can be running at once.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public ConcurrencyTaskScheduler(int maxConcurrency, CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
            this.maxConcurrency = maxConcurrency;

            isFirstWait = true;
            taskCounter = new CountdownEvent(1);
            taskQueue = new ConcurrentQueue<Tuple<long, Func<Task>>>();
            taskStatus = new ConcurrentDictionary<long, bool>();
        }

        /// <summary>
        /// Occurs when an error has been encountered during the execution of a task.
        /// </summary>
        /// <param name="sender">The resource that triggered the event.</param>
        /// <param name="e">The arguments for the event.</param>
        public delegate void ErrorEventHandler(object sender, TaskExceptionEventArgs e);

        /// <summary>
        /// Occurs when an error has been encountered during the execution of a task.
        /// </summary>
        public event ErrorEventHandler OnError;

        /// <summary>
        /// Checks if all tasks have completed.
        /// </summary>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait, or System.Threading.Timeout.Infinite(-1) to wait indefinitely.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// <c>true</c> if all tasks have completed; otherwise, <c>false</c>.
        /// </returns>
        public bool CheckForComplete(int millisecondsTimeout, CancellationToken cancellationToken)
        {
            if (isFirstWait)
            {
                isFirstWait = false;
                taskCounter.Signal();
            }

            return taskCounter.Wait(millisecondsTimeout, cancellationToken);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                taskCounter?.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Queues the specified work to run on the thread pool.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        public void RunTask(Func<Task> function)
        {
            RunTask(function, false);
        }

        /// <summary>
        /// Queues the specified work to run on the thread pool.
        /// </summary>
        /// <param name="function">The work to execute asynchronously</param>
        public void RunTask(Func<Task> function, bool validateConnected)
        {
            long taskId;

            function.AssertNotNull(nameof(function));

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (validateConnected)
            {
                if (PartnerSession.Instance.Context == null)
                {
                    throw new PSInvalidOperationException(Resources.RunConnectPartnerCenter);
                }
            }

            taskId = totalTaskCount;
            Interlocked.Increment(ref totalTaskCount);

            taskCounter.AddCount();

            if (Interlocked.Read(ref activeTaskCount) < maxConcurrency)
            {
                RunConcurrentTaskAsync(taskId, function());
            }
            else
            {
                taskQueue.Enqueue(new Tuple<long, Func<Task>>(taskId, function));
            }
        }

        private async void RunConcurrentTaskAsync(long taskId, Task task)
        {
            Interlocked.Increment(ref activeTaskCount);

            try
            {
                taskStatus.TryAdd(taskId, false);
                await task.ConfigureAwait(false);

                Interlocked.Increment(ref finishedTaskCount);
            }
            catch (Exception ex)
            {
                Interlocked.Increment(ref failedTaskCount);

                if (OnError != null)
                {
                    TaskExceptionEventArgs eventArgs = new TaskExceptionEventArgs(ex);

                    try
                    {
                        OnError(this, eventArgs);
                    }
                    catch (Exception devException)
                    {
                        Debug.Fail(devException.Message);
                    }
                }
            }
            finally
            {
                taskStatus.TryUpdate(taskId, true, false);
            }

            Interlocked.Decrement(ref activeTaskCount);

            if (disposed == false)
            {
                taskCounter?.Signal();
                RunRemainingTask();
            }
        }

        private void RunRemainingTask()
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            taskQueue.TryDequeue(out Tuple<long, Func<Task>> item);

            if (item != null)
            {
                RunConcurrentTaskAsync(item.Item1, item.Item2());
            }
        }
    }
}