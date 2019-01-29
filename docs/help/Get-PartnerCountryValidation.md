---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCountryValidation.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCountryValidation.md
schema: 2.0.0
---

# Get-PartnerCountryValidation

## SYNOPSIS
Gets the rules for validating an address for a specific country.

## SYNTAX

```powershell
Get-PartnerCountryValidation -CountryCode <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the rules for validating an address for a specific country.

## EXAMPLES

### Example 1

```powershell
PS C:\> Get-PartnerCountryValidation -CountryCode US
```

Gets the rules for validating an address for the United States.

## PARAMETERS

### -CountryCode
The country code code in ISO2 format.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.CountryValidationRules.PSCountryValidationRules

## NOTES

## RELATED LINKS
