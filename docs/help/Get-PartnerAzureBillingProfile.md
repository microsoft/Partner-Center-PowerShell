---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAzureBillingProfile.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAzureBillingProfile
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAzureBillingProfile.md
schema: 2.0.0
---

# Get-PartnerAzureBillingProfile

## SYNOPSIS
Gets the billing profiles for specified billing account.

## SYNTAX

```powershell
Get-PartnerAzureBillingProfile -BillingAccountName <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the billing profiles for specified billing account.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAzureBillingProfile -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx'
```

Gets the billing profiles for specified billing account.

## PARAMETERS

### -BillingAccountName
The name for the billing account

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

### Microsoft.Azure.Management.Billing.Models.BillingAccount

## NOTES

## RELATED LINKS
