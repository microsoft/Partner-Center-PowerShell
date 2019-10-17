---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionResourceUsage.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionResourceUsage
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionResourceUsage.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionResourceUsage

## SYNOPSIS
Gets the subscription's resource usage records.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionResourceUsage -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the subscription's resource usage records.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscriptionResourceUsage -CustomerId '87045e4b-ab69-4a8f-875a-af020b383bc6' -SubscriptionId 'd2a89f2d-1aa1-4f09-bc62-cefd8d0a005c'
```

Gets the subscription's resource usage records.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Usage.PSResourceUsageRecord

## NOTES

## RELATED LINKS
