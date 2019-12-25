// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;

    /// <summary>
    /// A cross platform mechanism for creating a lockfile for the token cache.
    /// </summary>
    internal class CrossPlatformLock : IDisposable
    {
        /// <summary>
        /// The default size for a buffer.
        /// </summary>
        private const int DefaultBufferSize = 4096;

        /// <summary>
        /// The default delay for retrying the ability to create the lockfile.
        /// </summary>
        private const int LockfileRetryDelayDefault = 100;

        /// <summary>
        /// The default number of times that creating the lockfile operation will be attempted.
        /// </summary>
        private const int LockfileRetryCountDefault = 60000 / LockfileRetryDelayDefault;

        /// <summary>
        /// The path for the lockfile.
        /// </summary>
        private readonly string lockFilePath;

        /// <summary>
        /// The stream used for accessing the lockfile.
        /// </summary>
        private FileStream lockFileStream;

        /// <summary>
        /// A flag indicating whether or not this instance has been disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossPlatformLock" /> class.
        /// </summary>
        /// <param name="lockFilePath">The path for the lockfile.</param>
        public CrossPlatformLock(string lockFilePath)
        {
            lockFilePath.AssertNotEmpty(nameof(lockFilePath));
            this.lockFilePath = lockFilePath;
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
                lockFileStream?.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Creates the token cache lock file.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        public async Task CreateLockAsync(CancellationToken cancellationToken = default)
        {
            Exception exception = null;
            FileStream fileStream = null;

            // Create lock file dir if it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(lockFilePath));

            for (int tryCount = 0; tryCount < LockfileRetryCountDefault; tryCount++)
            {

                try
                {
                    // We are using the file locking to synchronize the store, do not allow multiple writers or readers for the file.
                    FileShare fileShare = FileShare.None;

                    if (SharedUtilities.IsWindowsPlatform())
                    {
                        // This is so that Windows can offer read due to the granularity of the locking. Unix will not
                        // lock with FileShare.Read. Read access on Windows is only for debugging purposes and will not
                        // affect the functionality.
                        //
                        // See: https://github.com/dotnet/coreclr/blob/98472784f82cee7326a58e0c4acf77714cdafe03/src/System.Private.CoreLib/shared/System/IO/FileStream.Unix.cs#L74-L89
                        fileShare = FileShare.Read;
                    }

                    fileStream = new FileStream(lockFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, fileShare, DefaultBufferSize, FileOptions.DeleteOnClose);

                    using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8, DefaultBufferSize, leaveOpen: true))
                    {
                        await writer.WriteAsync($"{Process.GetCurrentProcess().Id} {Process.GetCurrentProcess().ProcessName}").ConfigureAwait(false);

                    }
                    break;
                }
                catch (IOException ex)
                {
                    exception = ex;
                    await Task.Delay(LockfileRetryDelayDefault, cancellationToken).ConfigureAwait(false);
                }
                catch (UnauthorizedAccessException ex)
                {
                    exception = ex;
                    await Task.Delay(LockfileRetryCountDefault, cancellationToken).ConfigureAwait(false);
                }
            }

            lockFileStream = fileStream ?? throw new InvalidOperationException("Could not get access to the shared lock file.", exception);
        }
    }
}