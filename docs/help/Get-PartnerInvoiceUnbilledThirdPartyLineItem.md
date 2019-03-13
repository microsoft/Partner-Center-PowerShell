---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerInvoiceUnbilledThirdPartyLineItem.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerInvoiceUnbilledThirdPartyLineItem
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerInvoiceUnbilledThirdPartyLineItem.md
schema: 2.0.0
---

# Get-PartnerInvoiceUnbilledThirdPartyLineItem

## SYNOPSIS
Gets a collection of unbilled third-party consumption line item details.

## SYNTAX

```powershell
Get-PartnerInvoiceUnbilledThirdPartyLineItem -CurrencyCode <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a collection of unbilled third-party consumption line item details.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerInvoiceUnbilledThirdPartyLineItem -CurrencyCode USD
```

Gets a collection of unbilled third-party consumption line item details.

## PARAMETERS

### -CurrencyCode
The currency code for the unbilled line items.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices.PSDailyRatedUsageReconLineItem

## NOTES

## RELATED LINKS
