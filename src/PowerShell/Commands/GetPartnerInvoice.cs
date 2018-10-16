﻿// -----------------------------------------------------------------------
// <copyright file="GetPartnerInvoice.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Enumerators;
    using Models.Invoices;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Gets a list of invoices from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoice"), OutputType(typeof(PSInvoice))]
    public class GetPartnerInvoice : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the invoice.", Mandatory = false)]
        [ValidateNotNull]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(InvoiceId))
            {
                GetInvoices();
            }
            else
            {
                WriteObject(new PSInvoice(Partner.Invoices[InvoiceId].Get()));
            }
        }

        private void GetInvoices()
        {
            IResourceCollectionEnumerator<ResourceCollection<Invoice>> enumerator;
            List<PSInvoice> invoices;
            ResourceCollection<Invoice> resources;

            resources = Partner.Invoices.Get();
            enumerator = Partner.Enumerators.Invoices.Create(resources);

            invoices = new List<PSInvoice>();

            while (enumerator.HasValue)
            {
                invoices.AddRange(enumerator.Current.Items.Select(i => new PSInvoice(i)));
                enumerator.Next();
            }

            WriteObject(invoices, true);
        }
    }
}