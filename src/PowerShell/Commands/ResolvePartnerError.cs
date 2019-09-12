// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Errors;
    using PartnerCenter.Exceptions;

    [Cmdlet(VerbsDiagnostic.Resolve, "PartnerError")]
    [OutputType(typeof(PartnerErrorRecord))]
    [OutputType(typeof(PartnerExceptionRecord))]
    [OutputType(typeof(PartnerRestExceptionRecord))]
    public class ResolvePartnerError : PSCmdlet
    {
        private const string AnyErrorParameterSet = "AnyErrorParameterSet";

        private const string LastErrorParameterSet = "LastErrorParameterSet";

        [Parameter(HelpMessage = "The error records to resolve", Mandatory = false, ParameterSetName = AnyErrorParameterSet, Position = 0, ValueFromPipeline = true)]
        public ErrorRecord[] Error { get; set; }

        [Parameter(HelpMessage = "The last error", Mandatory = true, ParameterSetName = LastErrorParameterSet)]
        public SwitchParameter Last { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<ErrorRecord> records = null;

            if (ParameterSetName.Equals(LastErrorParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                IEnumerable<ErrorRecord> errors = GetErrorVariable();

                if (errors != null && errors.FirstOrDefault() != null)
                {
                    records = new List<ErrorRecord> { { errors.FirstOrDefault() } };
                }
            }
            else
            {
                records = Error ?? GetErrorVariable();
            }


            if (records != null)
            {
                foreach (ErrorRecord record in records)
                {
                    HandleException(record.Exception, record);
                }
            }
        }

        private IEnumerable<ErrorRecord> GetErrorVariable()
        {
            IEnumerable<ErrorRecord> result = null;

            if (GetVariableValue("global:Error", null) is IEnumerable errors)
            {
                result = errors.OfType<ErrorRecord>();
            }

            return result;
        }

        private void HandleException(Exception exception, ErrorRecord record)
        {
            if (exception == null)
            {
                WriteObject(new PartnerErrorRecord(record));
            }

            if (exception is AggregateException aggregateException)
            {
                foreach (Exception innerException in aggregateException.InnerExceptions.Where(e => e != null))
                {
                    HandleException(innerException, record);
                }
            }
            else if (exception is PartnerException)
            {
                WriteObject(new PartnerRestExceptionRecord(exception as PartnerException, record));
            }
            else
            {
                WriteObject(new PartnerExceptionRecord(exception, record));

                if (exception.InnerException != null)
                {
                    HandleException(exception.InnerException, record);
                }
            }
        }
    }
}