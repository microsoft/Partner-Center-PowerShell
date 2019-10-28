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
Gets information for the available products.

## SYNTAX

### ByTargetView (Default)
```powershell
Get-PartnerProduct -Catalog <String> [-CountryCode <String>] [-Segment <String>] [<CommonParameters>]
```

### ByProductId
```powershell
Get-PartnerProduct [-CountryCode <String>] -ProductId <String> [<CommonParameters>]
```

### ByReservationScope
```powershell
Get-PartnerProduct [-CountryCode <String>] -ProductId <String> -ReservationScope <String> [<CommonParameters>]
```

## DESCRIPTION
Gets information for the available products.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProduct -Catalog 'Azure' -Segment 'commercial'
```

Gets information for the available products.

## PARAMETERS

### -Catalog
The catalog used for filtering the product.

```yaml
Type: String
Parameter Sets: ByTargetView
Aliases:
Accepted values: Azure, AzureReservations, AzureReservationsVM, AzureReservationsSQL, AzureReservationsCosmosDb, OnlineServices, Software, SoftwareSUSELinux, SoftwarePerpetual, SoftwareSubscriptions

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: ByProductId, ByReservationScope
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
Parameter Sets: ByReservationScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Segment
The segment used for filtering.

```yaml
Type: String
Parameter Sets: ByTargetView
Aliases:
Accepted values: commercial, education, government, nonprofit

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Products.PSProduct

## NOTES

## RELATED LINKS
