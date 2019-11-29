// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.NetworkInformation;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using ApplicationInsights;
    using ApplicationInsights.DataContracts;
    using ApplicationInsights.Extensibility;
    using Exceptions;
    using Models;
    using Models.Authentication;
    using Network;
    using Properties;
    using Rest;

    /// <summary>
    /// The base class for Partner Center PowerShell cmdlets.
    /// </summary>
    public abstract class PartnerPSCmdlet : PSCmdlet
    {
        /// <summary>
        /// Name of the telemetry event.
        /// </summary>
        private const string EventName = "cmdletInvocation";

        /// <summary>
        /// The link that provide addtional information regarding the breaking change.
        /// </summary>
        private const string BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK = "https://aka.ms/partnercenterps-changewarnings";

        /// <summary>
        /// Client that provides the ability to interact with the Application Insights service.
        /// </summary>
        private static readonly TelemetryClient telemetryClient = new TelemetryClient(TelemetryConfiguration.CreateDefault())
        {
            InstrumentationKey = "786d393c-be8e-46a8-b2b2-a3b6d5b417fc"
        };

        /// <summary>
        /// Provides a signal to <see cref="System.Threading.CancellationToken" /> that it should be canceled.
        /// </summary>
        private CancellationTokenSource cancellationSource;

        /// <summary>
        /// A SHA 256 hash of the MAC address.
        /// </summary>
        private string hashMacAddress;

        /// <summary>
        /// Provides the ability to log HTTP operations when the debug parameter is present.
        /// </summary>
        private RecordingTracingInterceptor httpTracingInterceptor;

        /// <summary>
        /// The quality of service event that will be captured by telemetry if enabled.
        /// </summary>
        private PartnerQosEvent qosEvent;

        /// <summary>
        /// Gets the cancellation token used to propagate a notification that operations should be canceled.
        /// </summary>
        protected CancellationToken CancellationToken => cancellationSource.Token;

        /// <summary>
        /// Gets the SHA 256 has the MAC address.
        /// </summary>
        private string HashMacAddress
        {
            get
            {
                if (string.IsNullOrEmpty(hashMacAddress))
                {
                    string value = NetworkInterface.GetAllNetworkInterfaces()?
                         .FirstOrDefault(nic => nic != null &&
                             nic.OperationalStatus == OperationalStatus.Up &&
                             !string.IsNullOrWhiteSpace(nic.GetPhysicalAddress()?.ToString()))?.GetPhysicalAddress()?.ToString();

                    hashMacAddress = string.IsNullOrWhiteSpace(value) ? null : GenerateSha256HashString(value)?.Replace("-", string.Empty)?.ToLowerInvariant();
                }

                return hashMacAddress;
            }
        }

        /// <summary>
        /// Operations that happen before the cmdlet is invoked.
        /// </summary>
        protected override void BeginProcessing()
        {
            string commandAlias = GetType().Name;

            if (cancellationSource == null)
            {
                cancellationSource = new CancellationTokenSource();
            }

            httpTracingInterceptor = httpTracingInterceptor ?? new RecordingTracingInterceptor(PartnerSession.Instance.DebugMessages);

            ServiceClientTracing.IsEnabled = true;
            ServiceClientTracing.AddTracingInterceptor(httpTracingInterceptor);

            if (MyInvocation != null && MyInvocation.MyCommand != null)
            {
                commandAlias = MyInvocation.MyCommand.Name;
            }

            qosEvent = new PartnerQosEvent
            {
                CommandName = commandAlias,
                IsSuccess = true,
                ModuleVersion = GetType().Assembly.GetName().Version.ToString(),
                ParameterSetName = ParameterSetName
            };

            if (MyInvocation != null && MyInvocation.BoundParameters != null && MyInvocation.BoundParameters.Keys != null)
            {
                qosEvent.Parameters = string.Join(" ", MyInvocation.BoundParameters.Keys.Select(
                    s => string.Format(CultureInfo.InvariantCulture, "-{0} ***", s)));
            }

            ProcessBreakingChangeAttributesAtRuntime(GetType(), MyInvocation, WriteWarning);
        }

        /// <summary>
        /// Operations that happend after the cmdlet is invoked.
        /// </summary>
        protected override void EndProcessing()
        {
            LogQosEvent();

            if (cancellationSource != null)
            {
                if (!cancellationSource.IsCancellationRequested)
                {
                    cancellationSource.Cancel();
                }

                cancellationSource.Dispose();
                cancellationSource = null;
            }

            ServiceClientTracing.RemoveTracingInterceptor(httpTracingInterceptor);
            base.EndProcessing();
        }

        /// <summary>
        /// Performs the execution of the command.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                ExecuteCmdlet();
                base.ProcessRecord();
            }
            catch (Exception ex) when (!IsTerminatingError(ex))
            {
                WriteExceptionError(ex);
            }
        }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public virtual void ExecuteCmdlet()
        {
        }

        /// <summary>
        /// Operations that are performed when the processing a cmdlet is stopping.
        /// </summary>
        protected override void StopProcessing()
        {
            if (cancellationSource != null)
            {
                if (!cancellationSource.IsCancellationRequested)
                {
                    cancellationSource.Cancel();
                }

                cancellationSource.Dispose();
                cancellationSource = null;
            }

            LogQosEvent();
            base.StopProcessing();
        }


        /// <summary>
        /// Terminate the command and report an error.
        /// </summary>
        /// <param name="errorRecord">The error which caused the command to be terminated.</param>
        protected new void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            FlushDebugMessages();

            if (qosEvent != null && errorRecord != null)
            {
                qosEvent.Exception = errorRecord.Exception;
                qosEvent.IsSuccess = false;
            }

            base.ThrowTerminatingError(errorRecord);
        }

        /// <summary>
        /// Writes the error record to the pipeline.
        /// </summary>
        /// <param name="errorRecord">The error record to be written to the pipeline.</param>
        protected new void WriteError(ErrorRecord errorRecord)
        {
            FlushDebugMessages();

            if (qosEvent != null && errorRecord != null)
            {
                qosEvent.Exception = errorRecord.Exception;
                qosEvent.IsSuccess = false;
            }

            base.WriteError(errorRecord);
        }

        /// <summary>
        /// Write an error message for a given exception.
        /// </summary>
        /// <param name="ex">The exception resulting from the error.</param>
        protected virtual void WriteExceptionError(Exception ex)
        {
            WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
        }

        /// <summary>
        /// Writes the object the pipeline.
        /// </summary>
        /// <param name="sendToPipeline">The object to be written to the pipeline.</param>
        protected new void WriteObject(object sendToPipeline)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline);
        }

        /// <summary>
        /// Writes the object the pipeline.
        /// </summary>
        /// <param name="sendToPipeline">The object to be written to the pipeline.</param>
        /// <param name="enumerateCollection">A flag indicating whether or not to enumerate the collection.</param>
        protected new void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            FlushDebugMessages();
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// Writes the warning message to the pipeline.
        /// </summary>
        /// <param name="text">The message to be written to the pipeline.</param>
        protected new void WriteWarning(string text)
        {
            FlushDebugMessages();
            base.WriteWarning(text);
        }

        /// <summary>
        /// Generate a SHA 256 hash string from the originInput.
        /// </summary>
        /// <param name="input">The input value to be hashed.</param>
        /// <returns>The SHA 256 hash, or empty if the input is only whtespace.</returns>
        private static string GenerateSha256HashString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            string result = null;

            try
            {
                using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                    result = BitConverter.ToString(bytes);
                }
            }
            catch
            {
                // do not throw if CryptoProvider is not provided
            }

            return result;
        }

        /// <summary>
        /// Gets all of the breaking change attributes in the specified type.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <param name="invocationInfo">The description of how and where this command was invoked.</param>
        private static IEnumerable<BreakingChangeBaseAttribute> GetAllBreakingChangeAttributesInType(Type type, InvocationInfo invocationInfo)
        {
            {
                List<BreakingChangeBaseAttribute> attributeList = new List<BreakingChangeBaseAttribute>();

                attributeList.AddRange(type.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());

                foreach (MethodInfo m in type.GetRuntimeMethods())
                {
                    attributeList.AddRange((m.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>()));
                }

                foreach (FieldInfo f in type.GetRuntimeFields())
                {
                    attributeList.AddRange(f.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
                }

                foreach (PropertyInfo p in type.GetRuntimeProperties())
                {
                    attributeList.AddRange(p.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
                }

                return invocationInfo == null ? attributeList : attributeList.Where(e => e.IsApplicableToInvocation(invocationInfo));
            }
        }

        /// <summary>
        /// Gets the name of the command from the type.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <returns>The name of the command from the type.</returns>
        private static string GetNameFromCmdletType(Type type)
        {
            string cmdletName = null;
            CmdletAttribute cmdletAttrib = (CmdletAttribute)type.GetCustomAttributes(typeof(CmdletAttribute), false).FirstOrDefault();

            if (cmdletAttrib != null)
            {
                cmdletName = cmdletAttrib.VerbName + "-" + cmdletAttrib.NounName;
            }

            return cmdletName;
        }

        /// <summary>
        /// Flushes the debug messages to the console.
        /// </summary>
        private void FlushDebugMessages()
        {
            while (PartnerSession.Instance.DebugMessages.TryDequeue(out string message))
            {
                WriteDebug(message);
            }
        }

        /// <summary>
        /// Gets a flag indicating whether or not the error is a terminating error.
        /// </summary>
        /// <param name="ex">The exception that was thrown.</param>
        /// <returns><c>true</c> if the error is a terminating error; otherwise <c>false</c></returns>
        private bool IsTerminatingError(Exception ex)
        {
            if (ex is PipelineStoppedException pipelineStoppedEx && pipelineStoppedEx.InnerException == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logs the execption event.
        /// </summary>
        private void LogExceptionEvent()
        {
            if (qosEvent == null)
            {
                return;
            }

            ExceptionTelemetry exceptionTelemetry = new ExceptionTelemetry(qosEvent.Exception)
            {
                Message = "The message has been removed due to PII"
            };

            if (qosEvent.Exception is PartnerException)
            {
                PartnerException ex = qosEvent.Exception as PartnerException;

                exceptionTelemetry.Properties.Add("ErrorCategory", ex.ErrorCategory.ToString());

                PopulatePropertiesFromResponse(exceptionTelemetry.Properties, ex.Response);

                if (ex.ServiceErrorPayload != null)
                {
                    exceptionTelemetry.Properties.Add("ErrorCode", ex.ServiceErrorPayload.ErrorCode);
                }
            }
            else if (qosEvent.Exception is RestException)
            {
                object ex = qosEvent.Exception as object;
                HttpResponseMessageWrapper response = ex.GetType().GetProperty("Response").GetValue(ex, null) as HttpResponseMessageWrapper;

                PopulatePropertiesFromResponse(exceptionTelemetry.Properties, response);
            }

            exceptionTelemetry.Metrics.Add("Duration", qosEvent.Duration.TotalMilliseconds);
            PopulatePropertiesFromQos(exceptionTelemetry.Properties);

            try
            {
                telemetryClient.TrackException(exceptionTelemetry);
            }
            catch
            {
                // Ignore any error with capturing the telemetry
            }
        }

        /// <summary>
        /// Logs the quality of srevice event.
        /// </summary>
        private void LogQosEvent()
        {
            qosEvent.FinishQosEvent();

            PageViewTelemetry pageViewTelemetry = new PageViewTelemetry
            {
                Name = EventName,
                Duration = qosEvent.Duration,
                Timestamp = qosEvent.StartTime
            };

            pageViewTelemetry.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            PopulatePropertiesFromQos(pageViewTelemetry.Properties);

            try
            {
                telemetryClient.TrackPageView(pageViewTelemetry);
            }
            catch
            {
                // Ignore any error with capturing the telemetry
            }

            if (qosEvent.Exception != null)
            {
                LogExceptionEvent();
            }
        }

        /// <summary>
        /// Populates the telemetry event properties based on the quality of service event.
        /// </summary>
        /// <param name="eventProperties">The telemetry event properties to be populated.</param>
        private void PopulatePropertiesFromQos(IDictionary<string, string> eventProperties)
        {
            if (qosEvent == null)
            {
                return;
            }

            eventProperties.Add("Command", qosEvent.CommandName);
            eventProperties.Add("CommandParameterSetName", qosEvent.ParameterSetName);
            eventProperties.Add("CommandParameters", qosEvent.Parameters);
            eventProperties.Add("HashMacAddress", HashMacAddress);
            eventProperties.Add("HostVersion", qosEvent.HostVersion);
            eventProperties.Add("IsSuccess", qosEvent.IsSuccess.ToString());
            eventProperties.Add("ModuleVersion", qosEvent.ModuleVersion);
            eventProperties.Add("PowerShellVersion", Host.Version.ToString());
        }

        /// <summary>
        /// Populates the telemetry event properties based on the HTTP response message.
        /// </summary>
        /// <param name="eventProperties">The telemetry event properties to be populated.</param>
        /// <param name="response">The HTTP response used to populate the event properties.</param>
        private void PopulatePropertiesFromResponse(IDictionary<string, string> eventProperties, HttpResponseMessageWrapper response)
        {
            if (response == null)
            {
                return;
            }

            eventProperties.Add("ReasonPhrase", response.ReasonPhrase);
            eventProperties.Add("StatusCode", response.StatusCode.ToString());
        }

        /// <summary>
        /// Processes the break changes defined for the cmdlet.
        /// </summary>
        /// <param name="type">The type for the command being invoked.</param>
        /// <param name="invocationInfo">The description of how and where this command was invoked.</param>
        /// <param name="writeOutput">The action used to write the output.</param>
        private void ProcessBreakingChangeAttributesAtRuntime(Type type, InvocationInfo invocationInfo, Action<string> writeOutput)
        {
            List<BreakingChangeBaseAttribute> attributes =
                new List<BreakingChangeBaseAttribute>(GetAllBreakingChangeAttributesInType(type, invocationInfo));

            if (attributes.Count > 0)
            {
                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesHeaderMessage,
                        GetNameFromCmdletType(type)));

                foreach (BreakingChangeBaseAttribute attribute in attributes)
                {
                    attribute.PrintCustomAttributeInfo(type, false, writeOutput);
                }

                writeOutput(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.BreakingChangesAttributesFooterMessage,
                        BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK));
            }
        }
    }
}