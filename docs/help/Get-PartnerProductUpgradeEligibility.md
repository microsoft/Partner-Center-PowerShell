---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductUpgradeEligibility.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgradeEligibility
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductUpgradeEligibility.md
schema: 2.0.0
---

# Get-PartnerProductUpgradeEligibility

## SYNOPSIS
Gets the product upgrade eligibility for the specified customer and product family.

## SYNTAX

```powershell
Get-PartnerProductUpgradeEligibility -CustomerId <String> -ProductFamily <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the product upgrade eligibility for the specified customer and product family.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProductUpgradeEligibility -CustomerId 'f6321248-b08d-468d-a895-34ecd57714d0' -ProductFamily Azure
```

Gets the product upgrade eligibility for the specified customer and product family.

## PARAMETERS

### -CustomerId
The identifier of the customer.

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

### -ProductFamily
The family for the product.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Azure

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

### Microsoft.Store.PartnerCenter.Models.ProductUpgrades.ProductUpgradeEligibility

## NOTES

## RELATED LINKS
