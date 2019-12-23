---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerTrialConversion.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerTrialConversion
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerTrialConversion.md
schema: 2.0.0
---

# Get-PartnerCustomerTrialConversion

## SYNOPSIS
Gets a list of trial conversions available for the specified subscription.

## SYNTAX

```powershell
Get-PartnerCustomerTrialConversion -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a list of trial conversions available for the specified subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerTrialConversion -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -SubscriptionId 4eaffa18-12f6-441e-b16d-cc9f4a90cfb8
```

Gets a list of trial conversions available for the specified subscription.

## PARAMETERS

### -CustomerId
The identifier for the customer.

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

### -SubscriptionId
The identifier for the subscription.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerTrialConversion.PSCustomerTrialConversion

## NOTES

## RELATED LINKS
