---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerInvoiceStatement.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerInvoiceStatement
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerInvoiceStatement.md
schema: 2.0.0
---

# Get-PartnerInvoiceStatement

## SYNOPSIS
Gets an invoice statement using the invoice identifier.

## SYNTAX

```powershell
Get-PartnerInvoiceStatement -InvoiceId <String> [-OutputPath <String>] [-Overwrite] [<CommonParameters>]
```

## DESCRIPTION
Gets an invoice statement using the invoice identifier and writes it to the specified path.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerInvoiceStatement -InvoiceId G000024135 -OutputPath 'C:\Invoices\'
```

Downloads the invoice statement associated with the invoice with the identifier of G000024135.

## PARAMETERS

### -InvoiceId
The invoice id of the statement to retrieve.

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
A flag indiciating whether or to overwrite the file if it exists.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
