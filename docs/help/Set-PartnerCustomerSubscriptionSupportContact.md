---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Set-PartnerCustomerSubscriptionSupportContact

## SYNOPSIS
Update a subscription's support contact to one of the partner's value added resellers.

## SYNTAX

```
Set-PartnerCustomerSubscriptionSupportContact -CustomerId <String> -Name <String> -SubscriptionId <String>
 -SupportMpnId <String> -SupportTenantId <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a subscription's support contact to one of the partner's value added resellers.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-PartnerCustomerSubscriptionSupportContact -CustomerId 'e7e428c6-30b3-4301-b0d4-bb397d7d923d' -Name 'Value Add Reseller' -SubscriptionId '87e74b43-243f-4f0c-bbd8-b602f33b4ab1' -SupportMpnId '9999999' -SupportTenantId 'f6671752-4eec-4fec-a6ff-d05b35b8af07'
```

Update a subscription's support contact to one of the partner's value added resellers.

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

### -Name
The name of the support contact.

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

### -SupportMpnId
The MPN identifier of the support contact.

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

### -SupportTenantId
The tenant identifier of the support contact.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions.PSSupportContact

## NOTES

## RELATED LINKS
