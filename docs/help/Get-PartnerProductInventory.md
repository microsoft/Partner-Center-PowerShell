---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerProductInventory

## SYNOPSIS
Checks the inventory for the specified product.

## SYNTAX

```
Get-PartnerProductInventory [-CountryCode <String>] -ProductId <String> [-SkuId <String>]
 [-Variables <Hashtable>] [<CommonParameters>]
```

## DESCRIPTION
Checks the inventory for the specified product.

## EXAMPLES

### Example 1
```powershell
PS C:\> $variables = @{ customerId='46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'; azureSubscriptionId='f5edca90-8799-44bd-ac59-64bd93285ed1'; armRegionName='uswest' }
PS C:\> Get-PartnerProductInventory -ProductId 'DZH318Z0BQ3P' -Variables $variables
```

Checks the inventory for the specified product.

## PARAMETERS

### -CountryCode
The country ISO2 code.

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

### -ProductId
A string that identifies the product.

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

### -SkuId
A string that identifies the sku.

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

### -Variables
A hashtable of inventory variables for the product.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Products.PSInventoryItem

## NOTES

## RELATED LINKS
