---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerInvoiceTaxReceiptStatement

## SYNOPSIS
Gets the tax receipt statement for the specified invoice.

## SYNTAX

```powershell
Get-PartnerInvoiceTaxReceiptStatement -InvoiceId <String> [-OutputPath <String>] [-Overwrite]
 -TaxReceiptId <String> [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerInvoiceStatement -InvoiceId G000024135 -OutputPath 'C:\Invoices\' -TaxReceiptId 00123
```

Gets the tax receipt statement for the specified invoice.

## PARAMETERS

### -InvoiceId
The identifier of the invoice.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputPath
The output path of the PDF statement file.

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

### -Overwrite
A flag indicating whether or not to overwrite the file if it exists.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaxReceiptId
The identifier of the tax receipt.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

### System.Object
## NOTES

## RELATED LINKS
