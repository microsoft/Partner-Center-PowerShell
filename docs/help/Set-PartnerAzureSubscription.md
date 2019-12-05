---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerAzureSubscription.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerAzureSubscription
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerAzureSubscription.md
schema: 2.0.0
---

# Set-PartnerAzureSubscription

## SYNOPSIS
Updates an Azure subscription that is part of an Azure Plan.

## SYNTAX

```powershell
Set-PartnerAzureSubscription -CustomerId <String> -SubscriptionId <String> -SubscriptionName <String>
 [<CommonParameters>]
```

## DESCRIPTION
Updates an Azure subscription that is part of an Azure Plan.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-PartnerAzureSubscription -SubscriptionId 'fcfa52d0-c092-42e1-af3f-eb6d63197513' -SubscriptionName 'Microsoft Azure'
```

Updates the display name for the specified Azure subscription.

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

### -SubscriptionName
The display name for the subscription.

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

### System.String

## NOTES

## RELATED LINKS
