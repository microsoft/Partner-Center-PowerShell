---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerAzurePlanEntitlement.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerAzurePlanEntitlement
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerAzurePlanEntitlement.md
schema: 2.0.0
---

# Get-PartnerCustomerAzurePlanEntitlement

## SYNOPSIS
Gets an Azure Plan's subscription entitlements.

## SYNTAX

```powershell
Get-PartnerCustomerAzurePlanEntitlement -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets an Azure Plan's subscription entitlements.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerAzurePlanEntitlement -CustomerId '78ca6954-7016-4248-be6d-7ce4315a9431' -SubscriptionId '3c94c76e-ab23-49f1-b1a7-6959599f48cd'
```

Gets an Azure Plan's subscription entitlements.

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

### Microsoft.Store.PartnerCenter.Models.Subscriptions.AzureEntitlement

## NOTES

## RELATED LINKS
