---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUsageSummary.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUsageSummary.md
schema: 2.0.0
---

# Get-PartnerCustomerUsageSummary

## SYNOPSIS
Gets the customer's usage of a specific Azure service or resource during the current billing period.

## SYNTAX

```powershell
Get-PartnerCustomerUsageSummary -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the customer's usage of a specific Azure service or resource during the current billing period.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerUsageSummary -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets the customer's usage of a specific Azure service or resource during the current billing period.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Usage.PSCustomerUsageSummary

## NOTES

## RELATED LINKS
