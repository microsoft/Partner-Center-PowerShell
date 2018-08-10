<#
.SYNOPSIS
Tests to be performed using the Get-PartnerInvoice cmdlet.
#>
function Test-GetPartnerInvoice
{
    $invoice = Get-PartnerInvoice -InvoiceId 'D030001TFO'

    Assert-NotNull $invoice

    $invoices = Get-PartnerInvoice

    Assert-NotNull $invoices 
    Assert-NotNullOrEmpty $invoices[0].InvoiceId
}