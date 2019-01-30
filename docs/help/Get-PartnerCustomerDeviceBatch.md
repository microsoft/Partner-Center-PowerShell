---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerDeviceBatch.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerDeviceBatch.md
schema: 2.0.0
---

# Get-PartnerCustomerDeviceBatch

## SYNOPSIS
Gets a list of device batches for the specified customer identifier.

## SYNTAX

```powershell
Get-PartnerCustomerDeviceBatch [-CustomerId] <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a list of device batches for the specified customer identifier.

## EXAMPLES

### Example 1

```powershell
PS C:\> Get-PartnerCustomerDeviceBatch -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets a list of device batches for the specified customer identifier.

## PARAMETERS

### -CustomerId
The identifier for the customer.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment.PSDeviceBatch

## NOTES

## RELATED LINKS
