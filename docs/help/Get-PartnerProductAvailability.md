---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductAvailability.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductAvailability.md
schema: 2.0.0
---

# Get-PartnerProductAvailability

## SYNOPSIS
Gets the availability for a specified product.

## SYNTAX

### BySku (Default)
```powershell
Get-PartnerProductAvailability -ProductId <String> -SkuId <String> [-CountryCode <String>] [-Segment <String>]
 [<CommonParameters>]
```

### ByAvailabilityId
```powershell
Get-PartnerProductAvailability -ProductId <String> -SkuId <String> [-CountryCode <String>]
 -AvailabilityId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the availability for a specified product.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProductAvailability -Product DZH318Z0BQ3Q -SkuId 0001
```

Gets the availability for a specified product.

## PARAMETERS

### -AvailabilityId
A string that identifies the availability.

```yaml
Type: String
Parameter Sets: ByAvailabilityId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
A string that identifies the product segment.

```yaml
Type: String
Parameter Sets: BySku
Aliases:
Accepted values: commercial, education, government, nonprofit

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuId
A string that identifies the product Sku.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Products.PSProductAvailability

## NOTES

## RELATED LINKS
