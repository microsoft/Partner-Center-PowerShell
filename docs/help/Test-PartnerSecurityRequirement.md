---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Test-PartnerSecurityRequirement.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Test-PartnerSecurityRequirement
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Test-PartnerSecurityRequirement.md
schema: 2.0.0
---

# Test-PartnerSecurityRequirement

## SYNOPSIS
Tests the account, used during authentication, if multi-factor authentication was enforced.

## SYNTAX

```powershell
Test-PartnerSecurityRequirement [-Environment <EnvironmentName>] [-UseDeviceAuthentication]
 [<CommonParameters>]
```

## DESCRIPTION
Tests the account, used during authentication, if multi-factor authentication was enforced. This test is done by checking for the MFA value in the AMR claim.

## EXAMPLES

### Example 1
```powershell
PS C:\> Test-PartnerSecurityRequirement
```

Tests the account, used during authentication, if multi-factor authentication was enforced. This test is done by checking for the MFA value in the AMR claim.

## PARAMETERS

### -Environment
The environment use for authentication.

```yaml
Type: EnvironmentName
Parameter Sets: (All)
Aliases: EnvironmentName
Accepted values: AzureCloud, AzureChinaCloud, AzureGermanCloud, AzurePPE, AzureUSGovernment

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseDeviceAuthentication
Use device code authentication instead of a browser control.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: DeviceCode, DeviceAuth, Device

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

### System.Object
## NOTES

## RELATED LINKS
