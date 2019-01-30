---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerOffer.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerOffer.md
schema: 2.0.0
---

# Get-PartnerOffer

## SYNOPSIS
Gets a specific offer or a list of available offers from Partner Center.

## SYNTAX

```powershell
Get-PartnerOffer [-AddOn] [-Category <String>] [-CountryCode <String>] [-OfferId <String>] [-Trial]
 [<CommonParameters>]
```

## DESCRIPTION

The Get-PartnerOffer cmdlet with retrieve a specific offer or a list of offers by market from Partner Center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerOffer -Country US
```

Gets a list of available offers for the US market.

### Example 2
```powershell
PS C:\> Get-PartnerOffer -Country US -Category SmallBusiness_Key
```

Gets a list of offers that matches the corresponding category for the US market.

### Example 3
```powershell
PS C:\> Get-PartnerOffer -Country US -OfferId '031C9E47-4802-4248-838E-778FB1D2CC05'
```

Gets the offer that matches the corresponding identifier for the US market.

## PARAMETERS

### -AddOn
Scope returned offers to only add-ons.

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

### -Category
Category that corresponds to the offers.

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

### -OfferId
A GUID that corresponds to the offer.

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

### -Trial
Scope returned offers to only trials.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Offers.PSOffer

## NOTES

## RELATED LINKS
