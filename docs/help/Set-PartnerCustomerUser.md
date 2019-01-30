---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerUser.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerUser.md
schema: 2.0.0
---

# Set-PartnerCustomerUser

## SYNOPSIS
Updates the specified customer user account.

## SYNTAX

### UserId (Default)
```powershell
Set-PartnerCustomerUser [-DisplayName <String>] [-ForceChangePasswordNextLogin] [-CustomerId] <String>
 [-FirstName <String>] [-LastName <String>] [-Password <SecureString>] [-UsageLocation <String>]
 -UserId <String> [-UserPrincipalName <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UserObject
```
Set-PartnerCustomerUser [-DisplayName <String>] [-ForceChangePasswordNextLogin] [-CustomerId] <String>
 -InputObject <PSCustomerUser> [-FirstName <String>] [-LastName <String>] [-Password <SecureString>]
 [-UsageLocation <String>] [-UserPrincipalName <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-PartnerCustomerUser cmdlet modifies a customer user account.

## EXAMPLES

### Example 1

```powershell
PS C:\> Set-PartnerCustomerUser -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -UserId a9ef48bb-8758-4590-a312-d4a47bfaded4 -LastName 'Sullivan'
```

Modify the user's last name

### Example 2

```powershell
$password = '<Password>'
PS C:\>$passwordSecure = $password | ConvertTo-SecureString -AsPlainText -Force
PS C:\>Set-PartnerCustomerUser -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -UserId a9ef48bb-8758-4590-a312-d4a47bfaded4 -Password $passwordSecure -ForceChangePassword $true
```

Set the password for the user account and require the user to change the password during the next sign on.

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

### -DisplayName
User's display name.

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

### -FirstName
User's first name.

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

### -ForceChangePasswordNextLogin
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

### -InputObject
The customer user object to be modified.

```yaml
Type: PSCustomerUser
Parameter Sets: UserObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LastName
User's last name.

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
User's new password.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsageLocation
The usage location, the location where user intends to use the license.

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
Parameter Sets: UserId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPrincipalName
User principal name.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerUsers.PSCustomerUser

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerUsers.PSCustomerUser

## NOTES

## RELATED LINKS
