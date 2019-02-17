---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerOrder.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerOrder
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerOrder.md
schema: 2.0.0
---

# Get-PartnerCustomerOrder

## SYNOPSIS
Gets either a specific order or a list of order for the specified customer.

## SYNTAX

### ByBillingCycle
```
Get-PartnerCustomerOrder -BillingCycle <BillingCycleType> -CustomerId <String> [<CommonParameters>]
```

### ByCustomerId
```
Get-PartnerCustomerOrder -CustomerId <String> [<CommonParameters>]
```

### ByOrderId
```
Get-PartnerCustomerOrder -CustomerId <String> -OrderId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets either a specific order or a list of order for the specified customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerOrder -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -BillingCycleType Monthly
```

Gets the list of orders with a billing cycle type of monthly for the specified customer.

### Example 1
```powershell
PS C:\> Get-PartnerCustomerOrder -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08
```

Gets the list of orders for the specified customer.

## PARAMETERS

### -BillingCycle
Indicates the type of billing cycle.

```yaml
Type: BillingCycleType
Parameter Sets: ByBillingCycle
Aliases:
Accepted values: Annual, Monthly, None, OneTime, Unknown

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerId
Identifier for the customer.

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

### -OrderId
Identifier for the order.

```yaml
Type: String
Parameter Sets: ByOrderId
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrder

## NOTES

## RELATED LINKS
