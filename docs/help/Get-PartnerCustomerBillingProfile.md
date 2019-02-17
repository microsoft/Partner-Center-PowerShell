---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerBillingProfile.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerBillingProfile
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerBillingProfile.md
schema: 2.0.0
---

# Get-PartnerCustomerBillingProfile

## SYNOPSIS
Gets the customer's billing profile.

## SYNTAX

```powershell
Get-PartnerCustomerBillingProfile -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-PartnerCustomerBillingProfile** cmdlet gets the specified customer's billing profile.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerBillingProfile -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

This command gets the billing profile for the specified customer.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomerBillingProfile

## NOTES

## RELATED LINKS
