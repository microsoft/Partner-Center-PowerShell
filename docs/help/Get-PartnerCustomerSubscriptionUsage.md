---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionUsage.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionUsage.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionUsage

## SYNOPSIS
Gets a collection resource that contains a list of services within a customer's subscription and their associated rated usage information.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionUsage -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a collection resource that contains a list of services within a customer's subscription and their associated rated usage information.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscriptionUsage -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -SubscriptionId '9ed730f0-882a-4c15-b4bc-7bb84da69835'
```

Gets a collection resource that contains a list of services within a customer's subscription and their associated rated usage information.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Usage.PSAzureResourceMonthlyUsageRecord

## NOTES

## RELATED LINKS
