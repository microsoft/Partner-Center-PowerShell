---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerAzureBillingPolicy.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerAzureBillingPolicy
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerAzureBillingPolicy.md
schema: 2.0.0
---

# Set-PartnerAzureBillingPolicy

## SYNOPSIS
Updates the billing policy for the specified customer.

## SYNTAX

```powershell
Set-PartnerAzureBillingPolicy -BillingAccountName <String> -CustomerId <String> [-ViewCharges]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the billing policy for the specified customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-PartnerAzureBillingPolicy -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerId '7b93c1be-57f6-4d8c-9270-e9b97c071557' -ViewCharges:$true
```

Enables the view charges feature which allows the customer to see retail pricing for Azure services.

### Example 2
```powershell
PS C:\> Set-PartnerAzureBillingPolicy -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerId '7b93c1be-57f6-4d8c-9270-e9b97c071557' -ViewCharges:$false
```

Disables the view charges feature which allows the customer to see retail pricing for Azure services.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ViewCharges
A flag that indicates whether or not the customer can view charges for Azure services.

```yaml
Type: SwitchParameter
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

### Microsoft.Azure.Management.Billing.Models.CustomerPolicy

## NOTES

## RELATED LINKS
