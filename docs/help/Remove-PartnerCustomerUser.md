---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerCustomerUser.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Remove-PartnerCustomerUser
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerCustomerUser.md
schema: 2.0.0
---

# Remove-PartnerCustomerUser

## SYNOPSIS
Removes a user from the customer's tenant.

## SYNTAX

### ByUserId (Default)
```powershell
Remove-PartnerCustomerUser [-CustomerId] <String> -UserId <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByUpn
```powershell
Remove-PartnerCustomerUser [-CustomerId] <String> -UserPrincipalName <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-PartnerCustomerUser cmdlet removes the specified user from the customer tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-PartnerCustomerUser -CustomerId db8ea5b4-a69b-45f3-abd3-dca19e87c536 -UserPrincipalName "hugh@wingtiptoys.onmicrosoft.com"
```

Removes the customer user with the User Principal Name of Hugh@wingtiptoys.onmicrosoft.com

### Example 2
```powershell
PS C:\> Remove-PartnerCustomerUser -CustomerId db8ea5b4-a69b-45f3-abd3-dca19e87c536 -UserId
```

Removes the customer user with the User identifier of 6e668259-1f09-479d-bcb8-d9b03e826b8d

## PARAMETERS

### -CustomerId
Identifier for the customer.

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

### -UserId
Identifier for the user.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### System.Boolean

## NOTES

## RELATED LINKS
