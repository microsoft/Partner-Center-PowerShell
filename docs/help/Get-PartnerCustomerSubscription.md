---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscription.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscription
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscription.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscription

## SYNOPSIS
Gets a list or a single customer subscription.

## SYNTAX

### ByCustomer (Default)
```powershell
Get-PartnerCustomerSubscription -CustomerId <String> [-OrderId <String>] [-MpnId <String>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ByCustomerObject
```powershell
Get-PartnerCustomerSubscription -InputObject <PSCustomer> [-OrderId <String>] [-MpnId <String>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ByOrder
```powershell
Get-PartnerCustomerSubscription -CustomerId <String> -OrderId <String> [<CommonParameters>]
```

### ByPartner
```powershell
Get-PartnerCustomerSubscription -CustomerId <String> -MpnId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a list or a single customer subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerSubscription -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08
```

Gets a list of subscriptions for the specified customer.

### Example 2
```powershell
PS C:\> Get-PartnerCustomerSubscription -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -SubscriptionId a2138cdf-769e-45d3-b957-ae9864b82bf6
```

Gets the specified customer subscription.

## PARAMETERS

### -CustomerId
The customer identifier used to scope the request.

```yaml
Type: String
Parameter Sets: ByCustomer, ByOrder, ByPartner
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The customer object used to scope the request.

```yaml
Type: PSCustomer
Parameter Sets: ByCustomerObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MpnId
The Microsoft Parnter Network identifier that identifies the partner.

```yaml
Type: String
Parameter Sets: ByCustomer, ByCustomerObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByPartner
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderId
The identifier corresponding to the order.

```yaml
Type: String
Parameter Sets: ByCustomer, ByCustomerObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByOrder
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier used to scope the request.

```yaml
Type: String
Parameter Sets: ByCustomer, ByCustomerObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions.PSSubscription

## NOTES

## RELATED LINKS
