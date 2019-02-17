---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionRegistrationStatus.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionRegistrationStatus
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionRegistrationStatus.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionRegistrationStatus

## SYNOPSIS
Gets the subscription registration status.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionRegistrationStatus -CustomerId <String> -SubscriptionId <String>
 [<CommonParameters>]
```

## DESCRIPTION
To purchase an Azure Reserved VM Instance using the Partner Center API, you must have at least one existing CSP Azure subscription. This cmdlet will get the registration status of the specified subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscriptionRegistrationStatus -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -SubscriptionId 9fccd1b5-ffc4-4e63-ba13-4689776c020e
```

Get the registration status for the specified subscription.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions.PSSubscriptionRegistrationStatus

## NOTES

## RELATED LINKS
