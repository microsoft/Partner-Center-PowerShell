---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerOfferAddon.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerOfferAddon
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerOfferAddon.md
schema: 2.0.0
---

# Get-PartnerOfferAddon

## SYNOPSIS
Gets the add-ons for an offer by identifier.

## SYNTAX

```powershell
Get-PartnerOfferAddon [-CountryCode <String>] [-OfferId] <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the add-ons for an offer by country and offer identifier.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerOfferAddon -OfferId 031C9E47-4802-4248-838E-778FB1D2CC05
```

Gets the add-ons for the the specified offer. If the country code is not specified it will default to the country code associated with the partner's legal business profile.

## PARAMETERS

### -CountryCode
The country code in ISO2 format.

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

Required: True
Position: 0
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
