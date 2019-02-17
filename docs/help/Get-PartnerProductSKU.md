---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductSku.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductSku
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductSku.md
schema: 2.0.0
---

# Get-PartnerProductSku

## SYNOPSIS
Gets the list of SKUs for a product.

## SYNTAX

### ByProductId (Default)
```
Get-PartnerProductSku [-CountryCode <String>] -ProductId <String> [<CommonParameters>]
```

### BySkuId
```
Get-PartnerProductSku [-CountryCode <String>] -ProductId <String> -SkuId <String> [<CommonParameters>]
```

### BySegment
```
Get-PartnerProductSku [-CountryCode <String>] -ProductId <String> [-Segment <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of SKUs for a specified product.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProductSku -ProductId 'DZH318Z0BQ5S'
```

Gets the available SKUs for the product with the identifier of DZH318Z0BQ5S.

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

### -Segment
A string that the product segment.

```yaml
Type: String
Parameter Sets: BySegment
Aliases:
Accepted values: commercial, education, government, nonprofit

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuId
A string that identifies the sku.

```yaml
Type: String
Parameter Sets: BySkuId
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Products.PSSku

## NOTES

## RELATED LINKS
