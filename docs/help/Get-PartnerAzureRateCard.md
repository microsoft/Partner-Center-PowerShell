---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAzureRateCard.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAzureRateCard.md
schema: 2.0.0
---

# Get-PartnerAzureRateCard

## SYNOPSIS
Gets real-time prices for an Azure offer.

## SYNTAX

```powershell
Get-PartnerAzureRateCard [-Currency <String>] [-Region <String>] [-SharedServices] [<CommonParameters>]
```

## DESCRIPTION
Gets real-time prices for an Azure offer. Azure pricing is quite dynamic and changes frequently.

## EXAMPLES

### Example 1
```powershell
PS C:\> $rateCard = Get-PartnerAzureRateCard
PS C:\> $rateCard.Meters
```

Gets real-time prices for an Azure offer.

### Example 2
```powershell
PS C:\> $rateCard = Get-PartnerAzureRateCard -SharedServices
PS C:\> $rateCard.Meters
```

Gets real-time prices for an Azure offer available through Azure Partner Shared Services (APSS).

## PARAMETERS

### -Currency
An optional three letter ISO code for the currency in which the resource rates will be provided.

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

### -Region
An optional two-letter ISO country/region code that indicates the market where the offer is purchased.

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

### -SharedServices
Flag indicating whether or not to retrieve the Azure Rate Card for Azure Partner Shared Services (APSS).

```yaml
Type: SwitchParameter
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.RateCards.PSAzureRateCard

## NOTES

## RELATED LINKS
