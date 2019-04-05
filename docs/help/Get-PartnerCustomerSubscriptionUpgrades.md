---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionUpgrades.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionUpgrades
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionUpgrades.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionUpgrades

## SYNOPSIS
Gets the available upgrade offers for the specified subscription.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionUpgrades -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the available upgrade offers for the specified subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscriptionUpgrades -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -SubscriptionId 'b2f26801-2849-4fb1-8815-ad5fcd81143d'
```

Gets the available upgrade offers for the specified subscription.

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

### -SubscriptionId
The identifier of the subscription.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerSubscriptionUpgrades.PSCustomerSubscriptionUpgrades

## NOTES

## RELATED LINKS
