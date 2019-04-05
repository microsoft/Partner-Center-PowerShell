---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUser.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerUser
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUser.md
schema: 2.0.0
---

# Get-PartnerCustomerUser

## SYNOPSIS
Gets a list of all customer users or a specified user for the tenant.

## SYNTAX

### ByCustomerId (Default)
```powershell
Get-PartnerCustomerUser [-CustomerId] <String> [-ReturnDeletedUsers] [<CommonParameters>]
```

### ByUserId
```powershell
Get-PartnerCustomerUser [-CustomerId] <String> -UserId <String> [<CommonParameters>]
```

### ByUpn
```powershell
Get-PartnerCustomerUser [-CustomerId] <String> -UserPrincipalName <String> [<CommonParameters>]
```

## DESCRIPTION
The Get-PartnerCustomerUser cmdlet returns either a list of customer users based on the specified customer identifier, or it returns a specific user based on the specified user identifier or user principal name.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerUser -CustomerId 45916f92-e9c3-4ed2-b8c2-d87aa129905f
```

Gets a list of all active users for the specified customer identifier.

### Example 2
```powershell
PS C:\> Get-PartnerCustomerUser -CustomerId 45916f92-e9c3-4ed2-b8c2-d87aa129905f -UserId e2e56b09-aac5-4685-947d-29e735ee7ed7
```

Gets information for the specified user.

### Example 3
```powershell
PS C:\> Get-PartnerCustomerUser -CustomerId 45916f92-e9c3-4ed2-b8c2-d87aa129905f -ReturnDeletedUsers
```

Gets a list of all deleted users for the specific customer.

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

### -ReturnDeletedUsers
Specifies whether to show deleted users.

```yaml
Type: SwitchParameter
Parameter Sets: ByCustomerId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The identifier for the user.

```yaml
Type: String
Parameter Sets: ByUserId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPrincipalName
Identifier for the customer.

```yaml
Type: String
Parameter Sets: ByUpn
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerUsers.PSCustomerUser

## NOTES

## RELATED LINKS
