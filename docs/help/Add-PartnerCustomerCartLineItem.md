---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Add-PartnerCustomerCartLineItem.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
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
PS C:\> $lineItem = New-PartnerCustomerCartLineItem -BillingCycle 'OneTime' -CatalogItemId 'DG7GMGF0DWTL:0001:DG7GMGF0DSJB' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -FriendlyName 'Sample RI Purchase' -ProvisioningContext ${duration='1Year', scope='shared', subscriptionId='b35d5324-df8e-4306-9023-6edac2d4896c'} -Quantity 10
PS C:\> Add-PartnerCustomerCartLineItem -CartId '65faf57b-0205-47ee-92b3-08dcf233ea73' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItem $lineItem
```

Adds a new line item to the specified cart.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCart

## NOTES

## RELATED LINKS
