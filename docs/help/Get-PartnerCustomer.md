---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerCustomer

## SYNOPSIS
Gets a specific customer or a list of available customers.

## SYNTAX

```
Get-PartnerCustomer [[-CustomerId] <String>] [<CommonParameters>]
```

## DESCRIPTION
The Get-PartnerCustomer cmdlet gets a specific customer or a list of customers from Partner Center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomer
```

Gets a list of all available customers from Partner Center.

### Example 2
```powershell
PS C:\> Get-PartnerCustomer -CustomerId '2ca7de6c-c05c-46b5-b689-32e53573a97a'
```

Gets the customer with the identifier of 2ca7de6c-c05c-46b5-b689-32e53573a97a from Partner Center.

## PARAMETERS

### -CustomerId
The identifier for the customer.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## NOTES

## RELATED LINKS
