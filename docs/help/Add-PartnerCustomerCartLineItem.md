---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Add-PartnerCustomerCartLineItem.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/add-partnercustomercartlineitem
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Add-PartnerCustomerCartLineItem.md
schema: 2.0.0
---

# Add-PartnerCustomerCartLineItem

## SYNOPSIS
Adds a new line item to the specified cart.

## SYNTAX

```powershell
Add-PartnerCustomerCartLineItem -CartId <String> -CustomerId <String> -LineItem <PSCartLineItem> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Adds a new line item to the specified cart.

## EXAMPLES

### Example 1
```powershell
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCartLineItem
PS C:\>
PS C:\> $lineItem.BillingCycle = 'OneTime'
PS C:\> $lineItem.CatalogItemId = 'DG7GMGF0DWTL:0001:DG7GMGF0DSJB'
PS C:\> $lineItem.FriendlyName = 'Sample RI Purchase'
PS C:\> $lineItem.ProvisioningContext.Add('duration', '1Year')
PS C:\> $lineItem.ProvisioningContext.Add('scope', 'shared')
PS C:\> $lineItem.ProvisioningContext.Add('subscriptionId', 'D526EF3A-35E6-477F-A64C-906F6177FBFA')
PS C:\> $lineItem.Quantity = 10
PS C:\>
PS C:\> Add-PartnerCustomerCartLineItem -CartId '65faf57b-0205-47ee-92b3-08dcf233ea73' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItem $lineItem
```

Adds a line item to purchase a reserved instance to the specified cart.

### Example 2

```powershell
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCartLineItem
PS C:\>
PS C:\> $lineItem.BillingCycle = 'OneTime'
PS C:\> $lineItem.CatalogItemId = 'DZH318Z0BPS6:0001:DZH318Z0BML6'
PS C:\> $lineItem.FriendlyName = 'Microsoft Azure Plan'
PS C:\> $lineItem.Quantity = 1
PS C:\>
PS C:\> Add-PartnerCustomerCartLineItem -CartId '65faf57b-0205-47ee-92b3-08dcf233ea73' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItem $lineItem
```

Adds a line item to purchase the Microsoft Azure Plan to the specified cart.

## PARAMETERS

### -CartId
The identifier for the cart.

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

### -CustomerId
The identifier for the customer.

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

### -LineItem
The line item to be added.

```yaml
Type: PSCartLineItem
Parameter Sets: (All)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCart

## NOTES

## RELATED LINKS
