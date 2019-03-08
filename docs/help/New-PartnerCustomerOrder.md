---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerOrder.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerOrder
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerOrder.md
schema: 2.0.0
---

# New-PartnerCustomerOrder

## SYNOPSIS
Create a new order for the specified services on behalf of the customer.

## SYNTAX

### Subscription (Default)
```powershell
New-PartnerCustomerOrder -CustomerId <String> -LineItems <PSOrderLineItem[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AddOn
```powershell
New-PartnerCustomerOrder -CustomerId <String> -LineItems <PSOrderLineItem[]> -OrderId <String> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a new order for the specified services on behalf of the customer.

## EXAMPLES

### Example 1

```powershell
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrderLineItem
PS C:\>
PS C:\> $lineItem.LineItemNumber = 0
PS C:\> $lineItem.OfferId = '031C9E47-4802-4248-838E-778FB1D2CC05'
PS C:\> $lineItem.Quantity = 1
PS C:\>
PS C:\> New-PartnerCustomerOrder -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems @($lineItem)
```

Creates a new order for the specified services on behalf of the customer.

### Example 2

```powershell
PS C:\> $s = Get-PartnerCustomerSubscription -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -SubscriptionId '10704f2f-3fc6-4e42-8acf-08df4f81c93c'
PS C:\> $addOn = Get-PartnerOfferAddon -OfferId $s.OfferId | Where-Object {$_.Name -eq 'Microsoft MyAnalytics'}
PS C:\>
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrderLineItem
PS C:\>
PS C:\> $lineItem.LineItemNumber = 0
PS C:\> $lineItem.OfferId = $addOn.OfferId
PS C:\> $lineItem.Quantity = 1
PS C:\> $lineItem.FriendlyName = $addOn.Name
PS C:\> $lineItem.ParentSubscriptionId = $s.SubscriptionId
PS C:\>
PS C:\> New-PartnerCustomerOrder -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems @($lineItem) -OrderId $s.OrderId
```

Creates an order to purchase an add-on for the specific subscription on behalf of the customer. This example shows how to purchase the Microsoft MyAnalytics add-on for the specified subscription. In this case the specified subscription is an Office 365 E3 subscription.

## PARAMETERS

### -CustomerId
The identifier of the customer making the purchase.

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

### -LineItems
The order line items.
Each order line item refers to one offer's purchase data.

```yaml
Type: PSOrderLineItem[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderId
The order identifier used when purchasing an add-on.

```yaml
Type: String
Parameter Sets: AddOn
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrder

## NOTES

## RELATED LINKS
