---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionSupportContact.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionSupportContact
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionSupportContact.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionSupportContact

## SYNOPSIS
Gets the support contact for the specified subscription.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionSupportContact -CustomerId <String> -SubscriptionId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Gets the support contact for the specified subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscriptionSupportContact -CustomerId 'f9893115-bda6-483a-89b1-a28e1aec23cb' -SubscriptionId '8b0b708a-07c7-48aa-bc51-adaa7b831a34'
```

Gets the support contact for the specified subscription.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions.PSSupportContact

## NOTES

## RELATED LINKS
