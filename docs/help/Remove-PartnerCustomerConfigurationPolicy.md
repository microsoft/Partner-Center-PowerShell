---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerCustomerConfigurationPolicy.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Remove-PartnerCustomerConfigurationPolicy
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerCustomerConfigurationPolicy.md
schema: 2.0.0
---

# Remove-PartnerCustomerConfigurationPolicy

## SYNOPSIS

Removes the specified configuration policy.

## SYNTAX

```powershell
Remove-PartnerCustomerConfigurationPolicy [-CustomerId] <String> -PolicyId <String> [<CommonParameters>]
```

## DESCRIPTION

The Remove-PartnerCustomerConfigurationPolicy removes the specified configuration policy.

## EXAMPLES

### Example 1

```powershell
PS C:\> Remove-PartnerCustomerConfigurationPolicy -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -PolicyId 2975afbf-4859-4d56-9f8d-e86996db92dd
```

Remove the configuration policy with the identifier of 2975afbf-4859-4d56-9f8d-e86996db92dd from the customer with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08.

## PARAMETERS

### -CustomerId

The identifier for the customer.

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

The identifier for the configuration policy.

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

### System.Boolean

## NOTES

## RELATED LINKS
