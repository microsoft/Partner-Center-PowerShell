﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A task scheduler with limited concurrency.
    /// </summary>
    public class LimitedConcurrencyTaskScheduler
    {
        /// <summary>
        /// Task number counter
        /// The following counter should be used with Interlocked
        /// </summary>
        private long totalTaskCount = 0;
        private long failedTaskCount = 0;
        private long finishedTaskCount = 0;
        private long activeTaskCount = 0;
        private readonly int maxConcurrency = 0;
        private readonly CountdownEvent taskCounter;
        private CancellationToken cancellationToken;
        private bool IsFirstWait;

        public long TotalTaskCount { get { return Interlocked.Read(ref totalTaskCount); } }
        public long FailedTaskCount { get { return Interlocked.Read(ref failedTaskCount); } }
        public long FinishedTaskCount { get { return Interlocked.Read(ref finishedTaskCount); } }
        public long ActiveTaskCount { get { return Interlocked.Read(ref activeTaskCount); } }

        public delegate void ErrorEventHandler(object sender, TaskExceptionEventArgs e);

        /// <summary>
        /// The error event for the running task.
        /// </summary>
        public event ErrorEventHandler OnError;

        /// <summary>
        /// Task waiting queue
        /// </summary>
        private readonly ConcurrentQueue<Tuple<long, Func<long, Task>>> taskQueue;

        /// <summary>
        /// Task status
        /// Key: Output id
        /// Value: Task is done or not.
        /// </summary>
        private readonly ConcurrentDictionary<long, bool> TaskStatus;

        /// <summary>
        /// Construct a limited concurrency task scheduler
        /// </summary>
        /// <param name="maxConcurrency"></param>
        /// <param name="cancellationToken"></param>
        public LimitedConcurrencyTaskScheduler(int maxConcurrency, CancellationToken cancellationToken)
        {
            taskQueue = new ConcurrentQueue<Tuple<long, Func<long, Task>>>();
            this.maxConcurrency = maxConcurrency;
            this.cancellationToken = cancellationToken;
            taskCounter = new CountdownEvent(1);
            IsFirstWait = true;
            TaskStatus = new ConcurrentDictionary<long, bool>();
        }

        /// <summary>
        /// Wait for all task completion
        /// </summary>
        /// <param name="millisecondsTimeout">Wait time out</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if all task completed, otherwise false.</returns>
        public bool WaitForComplete(int millisecondsTimeout, CancellationToken cancellationToken)
        {
            //There is no concurrency issue here since it should be only called by EndProcessing in PowerShell.
            if (IsFirstWait)
            {
                IsFirstWait = false;
                //Enable task scheduler complete
                taskCounter.Signal();
            }

            return taskCounter.Wait(millisecondsTimeout, cancellationToken);
        }

        /// <summary>
        /// Get available task id
        ///     thread unsafe since it should only run in main thread
        /// </summary>
        public long GetAvailableTaskId()
        {
            return totalTaskCount;
        }

        /// <summary>
        /// Is the specified task completed
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <returns>True if the specified task completed, otherwise false</returns>
        public bool IsTaskCompleted(long taskId)
        {
            bool existed = TaskStatus.TryGetValue(taskId, out bool finished);
            return existed && finished;
        }

        /// <summary>
        /// Run async task
        /// </summary>
        /// <param name="task">Task operation</param>
        /// <param name="taskId">Task id</param>
        protected async void RunConcurrentTask(long taskId, Task task)
        {
            bool initTaskStatus = false;
            bool finishedTaskStatus = true;

            Interlocked.Increment(ref activeTaskCount);

            try
            {
                TaskStatus.TryAdd(taskId, initTaskStatus);
                await task.ConfigureAwait(false);
                Interlocked.Increment(ref finishedTaskCount);
            }
            catch (Exception e)
            {
                Interlocked.Increment(ref failedTaskCount);

                if (OnError != null)
                {
                    TaskExceptionEventArgs eventArgs = new TaskExceptionEventArgs(taskId, e);

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
                TaskStatus.TryUpdate(taskId, finishedTaskStatus, initTaskStatus);
            }

            Interlocked.Decrement(ref activeTaskCount);
            taskCounter.Signal();

            RunRemainingTask();
        }

        /// <summary>
        /// Run the remaining task in the waiting queue
        /// </summary>
        private void RunRemainingTask()
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            taskQueue.TryDequeue(out Tuple<long, Func<long, Task>> remainingTask);
            if (remainingTask != null)
            {
                Task task = remainingTask.Item2(remainingTask.Item1);
                RunConcurrentTask(remainingTask.Item1, task);
            }
        }

        /// <summary>
        /// Run a task
        /// </summary>
        /// <param name="taskGenerator">Task generator</param>
        public void RunTask(Func<long, Task> taskGenerator)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            long taskId = GetAvailableTaskId();

            Interlocked.Increment(ref totalTaskCount);
            taskCounter.AddCount();

            if (Interlocked.Read(ref activeTaskCount) < maxConcurrency)
            {
                Task task = taskGenerator(taskId);
                RunConcurrentTask(taskId, task);
            }
            else
            {
                Tuple<long, Func<long, Task>> waitTask = new Tuple<long, Func<long, Task>>(taskId, taskGenerator);
                taskQueue.Enqueue(waitTask);
            }
        }
    }

    /// <summary>
    /// Task exception event arguments
    /// </summary>
    public class TaskExceptionEventArgs : EventArgs
    {
        public long TaskId { get; private set; }
        public Exception Exception { get; private set; }

        /// <summary>
        /// Construct a task exception event arguments object.
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="e">Task exception</param>
        public TaskExceptionEventArgs(long taskId, Exception e)
        {
            TaskId = taskId;
            Exception = e;
        }
    }
}
