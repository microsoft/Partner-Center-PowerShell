---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerProductUpgrade.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerProductUpgrade
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerProductUpgrade.md
schema: 2.0.0
---

# New-PartnerProductUpgrade

## SYNOPSIS
Creates a product upgrade request for the specified customer.

## SYNTAX

```powershell
New-PartnerProductUpgrade -CustomerId <String> -ProductFamily <String> [<CommonParameters>]
```

## DESCRIPTION
Creates a product upgrade request for the specified customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerProductUpgrade -CustomerId '2d92ed1b-338d-4448-9d5e-56bab44b2a97' -ProductFamily Azure
```

Creates a product upgrade request for the specified customer.

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

### Microsoft.Store.PartnerCenter.Models.ProductUpgrades.ProductUpgradeRequest

## NOTES

## RELATED LINKS
