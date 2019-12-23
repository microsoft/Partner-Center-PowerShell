---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Enable-PartnerAzureSubscription.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Enable-PartnerAzureSubscription
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Enable-PartnerAzureSubscription.md
schema: 2.0.0
---

# Enable-PartnerAzureSubscription

## SYNOPSIS
Enables an Azure subscription that is part of an Azure Plan.

## SYNTAX

```powershell
Enable-PartnerAzureSubscription -CustomerId <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Enables an Azure subscription that is part of an Azure Plan.

## EXAMPLES

### Example 1
```powershell
PS C:\> Enable-PartnerAzureSubscription -CustomerId 'bc79422f-ba9c-46ce-99bf-d747d4721466' -SubscriptionId '3bf8bf31-8410-4dd6-87ba-eef5fd56e32b'
```

Enables an Azure subscription that is part of an Azure Plan.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
