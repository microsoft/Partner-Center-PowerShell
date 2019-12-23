---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerCart.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerCart
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerCart.md
schema: 2.0.0
---

# New-PartnerCustomerCart

## SYNOPSIS
Creates a cart for a customer.

## SYNTAX

```powershell
New-PartnerCustomerCart -CustomerId <String> -LineItems <PSCartLineItem[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a cart for a customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> # Get the product information for the Azure Plan
PS C:\> $product = Get-PartnerProduct -ProductId 'DZH318Z0BPS6'
PS C:\> # Get the SKU information for the Azure Plan
PS C:\> $sku = Get-PartnerProductSku -ProductId $product.ProductId
PS C:\> # Get the availability information required for purchasing an Azure Plan
PS C:\> $availability = Get-PartnerProductAvailability -ProductId $product.ProductId -SkuId $sku.SkuId
PS C:\>
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCartLineItem
PS C:\>
PS C:\> $lineItem.BillingCycle = 'OneTime'
PS C:\> $lineItem.CatalogItemId = $availability.CatalogItemId
PS C:\> $lineItem.Quantity = 1
PS C:\>
PS C:\> New-PartnerCustomerCart -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems $lineItem
```

Creates a cart for the specified with a line item to purchase an Azure Plan

### Example 2
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
PS C:\> New-PartnerCustomerCart -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems $lineItem
```

Creates an cart for a customer.

## PARAMETERS

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
A list of cart line items.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCart

## NOTES

## RELATED LINKS
