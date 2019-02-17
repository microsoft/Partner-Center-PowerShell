---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerCart.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerCustomerCart
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerCart.md
schema: 2.0.0
---

# Set-PartnerCustomerCart

## SYNOPSIS
Updates an order for a customer in a cart.

## SYNTAX

```powershell
Set-PartnerCustomerCart -CartId <String> -CustomerId <String> -LineItems <PSCartLineItem[]> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates an order for a customer in a cart.

## EXAMPLES

### Example 1
```powershell
PS C:\> # Create the object that will be needed.
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCartLineItem
PS C:\>
PS C:\> # Configure the appropriate properties for the line item.
PS C:\> $lineItem.BillingCycle = 'OneTime'
PS C:\> $lineItem.CatalogItemId = 'DG7GMGF0DWTL:0001:DG7GMGF0DSJB'
PS C:\> $lineItem.FriendlyName = 'My Purchase'
PS C:\> $lineItem.ProvisioningContext =  @{duration='1Year'; scope='shared'; subscriptionId='b35d5324-df8e-4306-9023-6edac2d4896c'}
PS C:\> $lineItem.Quantity 10
PS C:\>
PS C:\> # Update the cart; this operation will replace the existing line items.
PS C:\> Set-PartnerCustomerCart -CartId '65faf57b-0205-47ee-92b3-08dcf233ea73' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems $lineItem
```

Updates an order for a customer in a cart.

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

### -LineItems
The line items for the cart.

```yaml
Type: PSCartLineItem[]
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
