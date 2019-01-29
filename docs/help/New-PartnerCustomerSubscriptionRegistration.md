---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerSubscriptionRegistration.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerSubscriptionRegistration.md
schema: 2.0.0
---

# New-PartnerCustomerSubscriptionRegistration

## SYNOPSIS
Registers the specified subscription.

## SYNTAX

```powershell
New-PartnerCustomerSubscriptionRegistration -CustomerId <String> -SubscriptionId <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Registers the specified subscription, so that is eligible to purcahse Azure reservations.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerCustomerSubscriptionRegistration -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -SubscriptionId 'b2f26801-2849-4fb1-8815-ad5fcd81143d'
```

Registers the specified subscription.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### System.String

## NOTES

## RELATED LINKS
