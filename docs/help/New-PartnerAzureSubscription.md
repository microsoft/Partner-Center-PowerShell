---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerAzureSubscription.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAzureSubscription
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerAzureSubscription.md
schema: 2.0.0
---

# New-PartnerAzureSubscription

## SYNOPSIS
Creates a new Azure subscription for Microsoft Partner Agreement billing account.

## SYNTAX

### ByCustomerName (Default)
```powershell
New-PartnerAzureSubscription -BillingAccountName <String> -CustomerName <String> -DisplayName <String>
 [-ResellerId <String>] [<CommonParameters>]
```

### ByCustomerId
```powershell
New-PartnerAzureSubscription -BillingAccountName <String> -CustomerId <String> -DisplayName <String>
 [-ResellerId <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure subscription for Microsoft Partner Agreement billing account.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerAzureSubscription -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerId 'cb20b9f1-d3e8-4dad-9d4f-5e4c92baed92' -DisplayName 'Microsoft Azure'
```

Creates a new Azure subscription for Microsoft Partner Agreement billing account.

## PARAMETERS

### -BillingAccountName
The name for the billing account.

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

### -CustomerId
The identifier for the customer.

```yaml
Type: String
Parameter Sets: ByCustomerId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerName
The name for the customer.

```yaml
Type: String
Parameter Sets: ByCustomerName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display for the subscription.

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

### -ResellerId
The identifier for the indirect reseller.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.Profiles.Subscription.Models.SubscriptionCreationResult

## NOTES

## RELATED LINKS
