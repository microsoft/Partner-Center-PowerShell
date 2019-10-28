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
Gets the available SKUs for the specified product.

## SYNTAX

### ByProductId (Default)
```powershell
Get-PartnerProductSku [-CountryCode <String>] -ProductId <String> [-ReservationScope <String>]
 [<CommonParameters>]
```

### BySkuId
```powershell
Get-PartnerProductSku [-CountryCode <String>] -ProductId <String> [-ReservationScope <String>] -SkuId <String>
 [<CommonParameters>]
```

### BySegment
```powershell
Get-PartnerProductSku [-CountryCode <String>] -ProductId <String> [-ReservationScope <String>]
 -Segment <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the available SKUs for the specified product.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProductSku -ProductId 'DZH318Z0BQ5S'
```

Gets the available SKUs for the specified product.

## PARAMETERS

### -CountryCode
The country on which to base the product.

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
The identifier for the product.

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

### -ReservationScope
The reservation scope used for filtering.

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

### -Segment
The segment used for filtering.

```yaml
Type: String
Parameter Sets: BySegment
Aliases:
Accepted values: commercial, education, government, nonprofit

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuId
The identifier for the SKU.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Products.PSSku

## NOTES

## RELATED LINKS
