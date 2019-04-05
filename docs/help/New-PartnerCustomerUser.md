---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerUser.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerUser
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerUser.md
schema: 2.0.0
---

# New-PartnerCustomerUser

## SYNOPSIS
Creates a new user in the specified customer Azure Active Directory tenant.

## SYNTAX

```powershell
New-PartnerCustomerUser -CustomerId <String> [-FirstName <String>] [-LastName <String>] -DisplayName <String>
 -UserPrincipalName <String> -Password <SecureString> [-ForceChangePassword] [-UsageLocation <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

The New-PartnerCustomerUser cmdlet creates a new user in the tenant Azure Active Directory.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-PartnerCustomerUser -CustomerId 45916f92-e9c3-4ed2-b8c2-d87aa129905f -UsageLocation US -UserPrincipalName 'joe@contoso.onmicrosoft.com' -FirstName 'Joe' -LastName 'Smith' -DisplayName 'Joe Smith' -ForceChangePassword -Password $PasswordSecure
```

Creates a new user account.

## PARAMETERS

### -CustomerId
The customer identifier.

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

### -DisplayName
The display name for the new customer user.

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

### -FirstName
The first name for the new customer user.

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

### -ForceChangePassword
Forces user to change password during next login.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastName
The last name for the new customer user.

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

### -Password
The password for the new custom user as a secure string

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsageLocation
The location where the customer user will use software and services. Service availability varies by region.

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

### -UserPrincipalName
The user principal name (UPN) for the new customer user, including the onmicrosoft.com domain name.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerUsers.PSCustomerUser

## NOTES

## RELATED LINKS
