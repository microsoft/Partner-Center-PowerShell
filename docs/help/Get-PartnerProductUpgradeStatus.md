---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductUpgradeStatus.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgradeStatus
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerProductUpgradeStatus.md
schema: 2.0.0
---

# Get-PartnerProductUpgradeStatus

## SYNOPSIS
Gets the product upgrade status for the specified customer and product family.

## SYNTAX

```powershell
Get-PartnerProductUpgradeStatus -CustomerId <String> -ProductFamily <String> -UpgradeId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Gets the product upgrade status for the specified customer and product family.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerProductUpgradeStatus -CustomerId '409fb479-1106-41a1-91be-0ae69e880a20' -ProductFamily Azure -UpgradeId '42d075a4-bfe7-43e7-af6d-7c68a57edcb4'
```

Gets the product upgrade status for the specified customer and product family.

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

### -UpgradeId
The identifier of the product upgrade.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.Models.ProductUpgrades.ProductUpgradeStatus

## NOTES

## RELATED LINKS
