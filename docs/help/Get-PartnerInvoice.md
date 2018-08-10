---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerInvoice

## SYNOPSIS
Gets a list of invoices available to the partner.

## SYNTAX

```
Get-PartnerInvoice [-InvoiceId <String>] [<CommonParameters>]
```

## DESCRIPTION

Gets a specific invoice or all invoices for the authenticated partner.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerInvoice -InvoiceID 'G000024135'
```

Gets a specific invoice based for the specified invoice.

### Example 2
```powershell
PS C:\> Get-PartnerInvoice
```

Gets a list of invoices available to the partner.

## PARAMETERS

### -InvoiceId
The identifier for the invoice.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices.PSInvoice

## NOTES

## RELATED LINKS
