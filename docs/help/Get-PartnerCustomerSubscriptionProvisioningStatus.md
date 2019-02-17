---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionProvisioningStatus.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionProvisioningStatus
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionProvisioningStatus.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionProvisioningStatus

## SYNOPSIS
Gets the provisioning status for the specified subscription.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionProvisioningStatus -CustomerId <String> -SubscriptionId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Gets the provisioning status for the specified subscription.

## EXAMPLES

### Example 1

```powershell
PS C:\> Get-PartnerCustomerSubscriptionProvisioningStatus -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -SubscriptionId 9fccd1b5-ffc4-4e63-ba13-4689776c020e
```

Gets the provisioning status for the specified subscription.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions.PSSubscriptionProvisioningStatus

## NOTES

## RELATED LINKS
