---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerUnbilledInvoiceLineItem.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUnbilledInvoiceLineItem
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerUnbilledInvoiceLineItem.md
schema: 2.0.0
---

# Get-PartnerUnbilledInvoiceLineItem

## SYNOPSIS
Gets the unbilled invoice line items.

## SYNTAX

```powershell
Get-PartnerUnbilledInvoiceLineItem -CurrencyCode <String> -LineItemType <InvoiceLineItemType>
 -Period <BillingPeriod> [<CommonParameters>]
```

## DESCRIPTION
Gets the unbilled invoice line items.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerUnbilledInvoiceLineItem -CurrencyCode USD -LineItemType BillingLineItems -Period Current
```

Gets reconciliation line items for the current billing period that have not been billed. The current billing period is defined as the current month.

### Example 2
```powershell
PS C:\> Get-PartnerUnbilledInvoiceLineItem -CurrencyCode USD -LineItemType BillingLineItems -Period Previous
```

Gets reconciliation line items for the previous billing period that have not been billed. The previous billing period is defined as the previous month.

### Example 3
```powershell
PS C:\> Get-PartnerUnbilledInvoiceLineItem -CurrencyCode USD -LineItemType UsageLineItems -Period Current
```

Gets consumption line items for the current billing period that have not been billed. The current billing period is defined as the current month.

### Example 4
```powershell
PS C:\> Get-PartnerUnbilledInvoiceLineItem -CurrencyCode USD -LineItemType UsageLineItems -Period Previous
```

Gets consumption line items for the previous billing period that have not been billed. The previous billing period is defined as the previous month.

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

### -LineItemType
The type of invoice line items.

```yaml
Type: InvoiceLineItemType
Parameter Sets: (All)
Aliases:
Accepted values: BillingLineItems, UsageLineItems

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Period
The billing period for the line items.

```yaml
Type: BillingPeriod
Parameter Sets: (All)
Aliases:
Accepted values: Current, Previous

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices.PSOneTimeInvoiceLineItem

### Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices.PSDailyRatedUsageLineItem

## NOTES

## RELATED LINKS
