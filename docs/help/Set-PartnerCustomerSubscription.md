---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerSubscription.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerSubscription.md
schema: 2.0.0
---

# Set-PartnerCustomerSubscription

## SYNOPSIS
Updates the specified customer subscription.

## SYNTAX

### Customer
```powershell
Set-PartnerCustomerSubscription [-AutoRenew <Boolean>] [-BillingCycle <BillingCycleType>] -CustomerId <String>
 [-FriendlyName <String>] [-Quantity <Int32>] [-Status <SubscriptionStatus>] -SubscriptionId <String> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CustomerObject
```powershell
Set-PartnerCustomerSubscription [-AutoRenew <Boolean>] -InputObject <PSCustomer>
 [-BillingCycle <BillingCycleType>] [-FriendlyName <String>] [-Quantity <Int32>] [-Status <SubscriptionStatus>]
 -SubscriptionId <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified customer subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-ParnterCustomerSubscription -AutoRenew $false -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -Subscription dace42ca-22df-4b1f-8f9e-992364dd866e
```

Disables the auto renew functionality for the specified subscription.

## PARAMETERS

### -AutoRenew
A flag indiciating whether or not the subscription will auto renew.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingCycle
The billing cycle for the subscription.

```yaml
Type: BillingCycleType
Parameter Sets: (All)
Aliases:
Accepted values: Annual, Monthly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerId
The customer identifier used to scope the request.

```yaml
Type: String
Parameter Sets: Customer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
The friendly name of the subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The customer object used to scope the request.

```yaml
Type: PSCustomer
Parameter Sets: CustomerObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Quantity
The quantity of the subscription.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The status of the subscription.

```yaml
Type: SubscriptionStatus
Parameter Sets: (All)
Aliases:
Accepted values: Active, Suspended

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier used to scope the request.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions.PSSubscription

## NOTES

## RELATED LINKS
