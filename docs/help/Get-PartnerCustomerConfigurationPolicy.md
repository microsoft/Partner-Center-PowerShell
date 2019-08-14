---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerConfigurationPolicy.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerConfigurationPolicy
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerConfigurationPolicy.md
schema: 2.0.0
---

# Get-PartnerCustomerConfigurationPolicy

## SYNOPSIS
Gets a list of all of a customer's policies.

## SYNTAX

```powershell
Get-PartnerCustomerConfigurationPolicy [-CustomerId] <String> [-PolicyId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of all of a customer's policies.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerConfigurationPolicy -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets a list of all of a customer's policies.

## PARAMETERS

### -CustomerId
Identifier for the customer.

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

### -PolicyId
Identifier for the configuration policy.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.PSConfigurationPolicy

## NOTES

## RELATED LINKS
