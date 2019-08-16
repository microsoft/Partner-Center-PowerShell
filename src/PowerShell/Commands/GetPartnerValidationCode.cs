// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.ValidationCodes;

    /// <summary>
    /// Gets validation code which is used for Government Community Cloud customers qualification.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerValidationCode")]
    [OutputType(typeof(PSValidationCode))]
    public class GetPartnerValidationCode : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(Partner.Validations.GetValidationCodesAsync().GetAwaiter().GetResult().Select(c => new PSValidationCode(c)), true);
        }
    }
}