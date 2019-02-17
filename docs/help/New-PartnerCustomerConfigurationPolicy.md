---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerConfigurationPolicy.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerConfigurationPolicy
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerConfigurationPolicy.md
schema: 2.0.0
---

# New-PartnerCustomerConfigurationPolicy

## SYNOPSIS

Creates a new configuration policy for the specified customer.

## SYNTAX

```powershell
New-PartnerCustomerConfigurationPolicy [-CustomerId] <String> [-Name] <String> [-Description <String>]
 [-RemoveOemPreinstalls <Boolean>] [-OobeUserNotLocalAdmin <Boolean>] [-SkipExpressSettings <Boolean>]
 [-SkipEula <Boolean>] [-SkipOemRegistration <Boolean>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

The New-PartnerCustomerConfigurationPolicy cmdlet creates a new configuration policy.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-PartnerCustomerConfigurationPolicy -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -Name "New Config Policy" -Description "Test Policy" -SkipEula $true -OobeUserNotLocalAdmin $true
```

Create a new configuration policy for a customer with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08. The policy is named "New Config Policy" and has a description of "Test Policy. Both the SkipEula and OobeUserNotLocalAdmin policies have been set.

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

Description for the new policy.

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

Policy name for the new policy.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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
