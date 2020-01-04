// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.ValidationCodes;
    using PartnerCenter.Models.ValidationCodes;

    /// <summary>
    /// Gets validation code which is used for Government Community Cloud customers qualification.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerValidationCode")]
    [OutputType(typeof(PSValidationCode))]
    public class GetPartnerValidationCode : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                IEnumerable<ValidationCode> codes = await partner.Validations.GetValidationCodesAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(codes.Select(c => new PSValidationCode(c)), true);
            }, true);
        }
    }
}