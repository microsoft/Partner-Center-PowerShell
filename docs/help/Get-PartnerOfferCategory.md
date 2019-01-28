---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerOfferCategory.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerOfferCategory.md
schema: 2.0.0
---

# Get-PartnerOfferCategory

## SYNOPSIS
Gets a list of offer categories.

## SYNTAX

```powershell
Get-PartnerOfferCategory -CountryCode <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a list of offer categories.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerOfferCategory -CountryCode 'US'
```

Gets a list of offer categories for the specified country.

## PARAMETERS

### -CountryCode
The country ISO2 code.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Offers.PSOfferCategory

## NOTES

## RELATED LINKS
