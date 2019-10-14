---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionMeterUsage.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionMeterUsage
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionMeterUsage.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionMeterUsage

## SYNOPSIS
Gets the subscription's meter usage records.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionMeterUsage -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the subscription's meter usage records.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscriptionMeterUsage -CustomerId 'aafb0edb-d0e1-4221-8862-1609fccac9b4' -SubscriptionId 'ed7b62ca-7440-4c4c-8f5d-b898258932d5'
```

Gets the subscription's meter usage records.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Usage.PSMeterUsageRecord

## NOTES

## RELATED LINKS
