---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerQualification.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerQualification
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerQualification.md
schema: 2.0.0
---

# Get-PartnerCustomerQualification

## SYNOPSIS
Get the qualification assigned to the customer.

## SYNTAX

```powershell
Get-PartnerCustomerQualification -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
Get the qualification assigned to the customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerQualification -CustomerId 'c4f6bf3c-60de-432e-a3ec-20bcc5b26ec2'
```

Get the qualification assigned to the customer.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.Models.Customers.CustomerQualification

## NOTES

## RELATED LINKS
