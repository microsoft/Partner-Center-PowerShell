// -----------------------------------------------------------------------
// <copyright file="GetPartnerInvoiceStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;

    /// <summary>
    /// Get partner licenses usage information aggregated to include all customers from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceStatement")]
    public class GetPartnerInvoiceStatement : PartnerPSCmdlet
    {
        /// <summary>
        /// The invoice id of the statement to retrieve.
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
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(OutputPath))
            {
                OutputPath = Directory.GetCurrentDirectory();
            }

            DirectoryInfo dirInfo = Directory.CreateDirectory(OutputPath);
            string filePath = "";

            if (dirInfo.FullName.EndsWith(Path.DirectorySeparatorChar.ToString(CultureInfo.CurrentCulture), System.StringComparison.CurrentCulture))
            {
                filePath = dirInfo.FullName + InvoiceId + ".pdf";
            }
            else
            {
                filePath = dirInfo.FullName + Path.DirectorySeparatorChar.ToString(CultureInfo.CurrentCulture) + InvoiceId + ".pdf";
            }

            if (File.Exists(filePath))
            {
                if (!Overwrite.IsPresent)
                    throw new PSInvalidOperationException("The path already exists: " + filePath + ". Specify the -Overwrite switch to overwrite the file");
            }

            GetStatement(InvoiceId, filePath);
        }

        /// <summary>
        ///  Gets the specified invoice statement for the specified invoiceId and outputs the PDF file to outputPath
        /// </summary>
        private void GetStatement(string invoiceId, string filePath)
        {
            Stream stream;
            FileStream file;

            try
            {
                stream = Partner.Invoices.ById(invoiceId).Documents.Statement.Get();
                file = File.Create(filePath);
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(file);
                file.Close();
                stream.Close();
            }
            finally
            {
                stream = null;
                file = null;
            }
        }
    }
}