---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProduct.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProduct
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProduct.md
schema: 2.0.0
---

# Get-PartnerProduct

## SYNOPSIS
Gets a list or a single product.

## SYNTAX

### ByCatalog (Default)
```
Get-PartnerProduct [-CountryCode <String>] -Catalog <String> [-Segment <String>] [<CommonParameters>]
```

### ByProductId
```
Get-PartnerProduct [-CountryCode <String>] -ProductId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a list or a single product.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProduct -Catalog 'Azure' -Segment 'commercial'
```

Gets a list of products scoped to the Azure target view and commercial segment.

## PARAMETERS

### -Catalog
A string that the product catalog.

```yaml
Type: String
Parameter Sets: ByCatalog
Aliases:
Accepted values: Azure, OnlineServices, Software

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
Parameter Sets: ByProductId
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
Parameter Sets: ByCatalog
Aliases:
Accepted values: commercial, education, government, nonprofit

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Products.PSProduct

## NOTES

## RELATED LINKS
