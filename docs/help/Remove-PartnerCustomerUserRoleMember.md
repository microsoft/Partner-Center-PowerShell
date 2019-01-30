---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerCustomerUserRoleMember.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerCustomerUserRoleMember.md
schema: 2.0.0
---

# Remove-PartnerCustomerUserRoleMember

## SYNOPSIS
Removes a customer user from a specified role.

## SYNTAX

```powershell
Remove-PartnerCustomerUserRoleMember -CustomerId <String> [-UserId <String>] [-RoleId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-PartnerCustomerUserRoleMember cmdlets removes a specified role to the target customer user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-PartnerCustomerUserRoleMember -CustomerId c4f6bf3c-60de-432e-a3ec-20bcc5b26ec2 -UserId 17765f05-723c-4be4-89e2-c7d1cdbb0906 -RoleId 62e90394-69f5-4237-9190-012177145e10
```

Removes the specified user with the identifier of 17765f05-723c-4be4-89e2-c7d1cdbb0906 from the role with the identifier of 62e90394-69f5-4237-9190-012177145e10.

## PARAMETERS

### -CustomerId
Identifier for the customer.

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

### -RoleId
Identifier for the role.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
