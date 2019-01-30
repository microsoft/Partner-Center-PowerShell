---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerConfigurationPolicy.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerConfigurationPolicy.md
schema: 2.0.0
---

# Set-PartnerCustomerConfigurationPolicy

## SYNOPSIS

Updates an existing configuration policy with the specified options.

## SYNTAX

```powershell
Set-PartnerCustomerConfigurationPolicy [-CustomerId] <String> -PolicyId <String> [-Name <String>]
 [-Description <String>] [-RemoveOemPreinstalls <Boolean>] [-OobeUserNotLocalAdmin <Boolean>]
 [-SkipExpressSettings <Boolean>] [-SkipEula <Boolean>] [-SkipOemRegistration <Boolean>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION

The Set-PartnerCustomerConfigurationPolicy cmdlet will update an existing configuration.

## EXAMPLES

### Example 1

```powershell
PS C:\> Set-PartnerCustomerConfigurationPolicy -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -PolicyId 2975afbf-4859-4d56-9f8d-e86996db92dd -Name "Updated Policy Name"
```

Updates the existing configuration policy with the identifier of 2975afbf-4859-4d56-9f8d-e86996db92dd with a new name of "Updated Policy Name" 

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

### -Description

Description for the policy.

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

### -Name

Policy name for the policy.

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

### -OobeUserNotLocalAdmin

Enables or disables the Disable local admin account in setup policy.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyId

Identifier for the policy.

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

### -RemoveOemPreinstalls
Enables or disables the Remove OEM preinstalls policy.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipEula
Enables or disables the Skip end user license agreement (EULA) policy.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipExpressSettings
Enables or disables the Automatically skip pages in setup policy.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipOemRegistration
Enables or disables the Skip OEM registration policy.

```yaml
Type: Boolean
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

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.PSConfigurationPolicy

## NOTES

## RELATED LINKS
