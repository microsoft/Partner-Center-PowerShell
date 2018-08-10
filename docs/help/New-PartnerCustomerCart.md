---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# New-PartnerCustomerCart

## SYNOPSIS
Creates an order for a customer.

## SYNTAX

```
New-PartnerCustomerCart -CustomerId <String> -LineItems <CartLineItem[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates an order for a customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> $lineItems = @()
PS C:\> $lineItems += New-PartnerCustomerCartLineItem -BillingCycle 'OneTime' -CatalogItemId 'DG7GMGF0DWTL:0001:DG7GMGF0DSJB' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -FriendlyName 'Sample RI Purchase' -ProvisioningContext @{duration='1Year'; scope='shared'; subscriptionId='b35d5324-df8e-4306-9023-6edac2d4896c'} -Quantity 10
PS C:\> New-PartnerCustomerCart -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems $lineItems
```

Creates an order for a customer.

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
Type: CartLineItem[]
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
