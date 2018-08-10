// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerLicense.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Models.Licenses;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Licenses;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerLicense", DefaultParameterSetName = "ByCustomerId"), OutputType(typeof(PSSubscribedSku))]
    public class GetPartnerCustomerLicense : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByUserId", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByUserId", Mandatory = false, HelpMessage = "The identifier for the user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the license group identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = false, HelpMessage = "The identifier for the license group.")]
        public LicenseGroupId? LicenseGroupId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(UserId))
            {
                GetUserLicenses(CustomerId, UserId);
            }
            else
            {
                GetSubscribedSkus(CustomerId, LicenseGroupId);
            }
        }

        /// <summary>
        /// Gets a list of available licenses.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="groupId">Identifier of the license group.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetSubscribedSkus(string customerId, LicenseGroupId? groupId)
        {
            ResourceCollection<SubscribedSku> skus;

            customerId.AssertNotEmpty(nameof(customerId));

            try
            {
                if (groupId.HasValue)
                {
                    skus = Partner.Customers.ById(customerId).SubscribedSkus.Get(new List<LicenseGroupId>() { groupId.Value });
                }
                else
                {
                    // this is not easily mocked, because it uses an optional parameter.
                    skus = Partner.Customers.ById(customerId).SubscribedSkus.Get(null);
                }

                if (skus.TotalCount > 0)
                    WriteObject(skus.Items.Select(s => new PSSubscribedSku(s)), true);
            }
            finally
            {
                skus = null;
            }
        }

        /// <summary>
        /// Gets a list of licenses assigned to a user.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userId">Identifier of the user.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// or
        /// <paramref name="userId"/> is empty or null.
        /// </exception>
        private void GetUserLicenses(string customerId, string userId)
        {
            ResourceCollection<License> licenses;

            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));

            try
            {
                licenses = Partner.Customers.ById(CustomerId).Users.ById(userId).Licenses.Get(null);

                if (licenses.TotalCount > 0)
                    WriteObject(licenses.Items.Select(l => new PSLicense(l)), true);
            }
            finally
            {
                licenses = null;
            }
        }
    }
}