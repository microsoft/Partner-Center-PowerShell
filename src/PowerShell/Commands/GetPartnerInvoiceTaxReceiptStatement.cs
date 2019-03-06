// -----------------------------------------------------------------------
// <copyright file="GetPartnerInvoiceTaxReceiptStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using Authentication;

    /// <summary>
    /// Get partner licenses usage information aggregated to include all customers from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceTaxReceiptStatement")]
    public class GetPartnerInvoiceTaxReceiptStatement : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// The invoice identifier of the statement to retrieve.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The indentifier of the invoice.")]
        [ValidateNotNullOrEmpty]
        public string InvoiceId { get; set; }

        /// <summary>
        /// The output path of the PDF statement file.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The output path of the PDF statement file.")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        /// <summary>
        /// Gets or sets a flag indiciating whether or to overwrite the file if it exists.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A flag indiciating whether or not to overwrite the file if it exists.")]
        [ValidateNotNull]
        public SwitchParameter Overwrite { get; set; }

        /// <summary>
        /// The tax receipt identifier of the statement to retrieve.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The indentifier of the tax receipt.")]
        [ValidateNotNullOrEmpty]
        public string TaxReceiptId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(OutputPath))
            {
                OutputPath = Directory.GetCurrentDirectory();
            }

            DirectoryInfo dirInfo = Directory.CreateDirectory(OutputPath);
            string filePath;

            if (dirInfo.FullName.EndsWith(Path.DirectorySeparatorChar.ToString(CultureInfo.CurrentCulture), System.StringComparison.CurrentCulture))
            {
                filePath = dirInfo.FullName + InvoiceId + ".pdf";
            }
            else
            {
                filePath = dirInfo.FullName + Path.DirectorySeparatorChar.ToString(CultureInfo.CurrentCulture) + InvoiceId + ".pdf";
            }

            if (File.Exists(filePath) && !Overwrite.IsPresent)
            {
                throw new PSInvalidOperationException("The path already exists: " + filePath + ". Specify the -Overwrite switch to overwrite the file");
            }

            FileStream fileStream = null;

            try
            {
                using (Stream stream = Partner.Invoices.ById(InvoiceId).Documents.Statement.GetAsync().GetAwaiter().GetResult())
                {
                    fileStream = File.Create(filePath);
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }
            finally
            {
                fileStream?.Dispose();
            }
        }
    }
}