---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerInvoiceLineItem.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerInvoiceLineItem
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerInvoiceLineItem.md
schema: 2.0.0
---

# Get-PartnerInvoiceLineItem

## SYNOPSIS
Gets the line items for the specified invoice.

## SYNTAX

```powershell
Get-PartnerInvoiceLineItem -BillingProvider <BillingProvider> [-CurrencyCode <String>] -InvoiceId <String>
 -LineItemType <InvoiceLineItemType> [<CommonParameters>]
```

## DESCRIPTION
Gets the line items for the specified invoice.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerInvoiceLineItem -BillingProvider Azure -InvoiceId 'D070002ISK' -LineItemType 'BillingLineItems'
```

Gets the line items for the specified invoice.

## PARAMETERS

### -BillingProvider
The billing provide for the line items.

```yaml
Type: BillingProvider
Parameter Sets: (All)
Aliases:
Accepted values: Azure, Office, OneTime, Marketplace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CurrencyCode
The currency code for the unbilled line items.

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

### -InvoiceId
The identifier corresponding to the invoice.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices.PSInvoiceLineItem

## NOTES

## RELATED LINKS
