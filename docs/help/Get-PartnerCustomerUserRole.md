---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUserRole.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerUserRole
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUserRole.md
schema: 2.0.0
---

# Get-PartnerCustomerUserRole

## SYNOPSIS
Gets a list of directory roles for a customer.

## SYNTAX

```powershell
Get-PartnerCustomerUserRole -CustomerId <String> [-UserId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of directory roles for a customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerUserRole -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets a list of directory roles for a customer.

### Example 2
```powershell
PS C:\> Get-PartnerCustomerUserRole -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -UserId '8e873002-9c5e-4cb5-928a-cbc14f51c398'
```

Gets a list of directory roles assigned to the specified user.

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

### -UserId
Identifier for the user.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.DirectoryRoles.PSDirectoryRole

## NOTES

## RELATED LINKS
