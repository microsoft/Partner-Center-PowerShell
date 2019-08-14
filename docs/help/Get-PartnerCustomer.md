---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomer.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomer
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomer.md
schema: 2.0.0
---

# Get-PartnerCustomer

## SYNOPSIS
Gets a specific customer or a list of available customers.

## SYNTAX

### ById (Default)
```powershell
Get-PartnerCustomer [[-CustomerId] <String>] [<CommonParameters>]
```

### ByDomain
```powershell
Get-PartnerCustomer -Domain <String> [<CommonParameters>]
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
Parameter Sets: ById
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Domain
The domain assigned to the Azure AD tenant of the customer.

```yaml
Type: String
Parameter Sets: ByDomain
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## NOTES

## RELATED LINKS
