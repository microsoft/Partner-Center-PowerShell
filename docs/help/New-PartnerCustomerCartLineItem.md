---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# New-PartnerCustomerCartLineItem

## SYNOPSIS
Creates a new cart line item object in memory.

## SYNTAX

```
New-PartnerCustomerCartLineItem -BillingCycle <BillingCycleType> -CatalogItemId <String> -CustomerId <String>
 [-CurrencyCode <String>] [-FriendlyName <String>] [-OrderGroup <String>] [-ProvisioningContext <Hashtable>]
 [-Quantity <Int32>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new cart line item object in memory.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerCustomerCartLineItem -BillingCycle 'OneTime' -CatalogItemId 'DG7GMGF0DWTL:0001:DG7GMGF0DSJB' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -FriendlyName 'Sample RI Purchase' -ProvisioningContext ${duration='1Year', scope='shared', subscriptionId='b35d5324-df8e-4306-9023-6edac2d4896c'} -Quantity 10
```

Creates a new cart line item object in memory.

## PARAMETERS

### -BillingCycle
The type of billing cycle set for the current period.

```yaml
Type: BillingCycleType
Parameter Sets: (All)
Aliases:
Accepted values: Annual, Monthly, None, OneTime

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CatalogItemId
The catalog item identifier.

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

### -CurrencyCode
The currency code used when this line item is invoiced.

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

### -FriendlyName
The friendly name for the item defined by the partner to help disambiguate.

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

### -OrderGroup
A group to indicate which items can be placed together.

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

### -ProvisioningContext
A context used for provisioning of offer.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Quantity
The number of licenses or instances.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCartLineItem

## NOTES

## RELATED LINKS
