---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAzureBillingPolicy.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAzureBillingPolicy
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAzureBillingPolicy.md
schema: 2.0.0
---

# Get-PartnerAzureBillingPolicy

## SYNOPSIS
Gets the billing policy for the specified customer.

## SYNTAX

```powershell
Get-PartnerAzureBillingPolicy -BillingAccountName <String> -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the billing policy for the specified customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAzureBillingPolicy -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerId '7b93c1be-57f6-4d8c-9270-e9b97c071557'
```

Gets the billing policy for the specified customer.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.Billing.Models.CustomerPolicy

## NOTES

## RELATED LINKS
