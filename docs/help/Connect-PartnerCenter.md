---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Connect-PartnerCenter.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Connect-PartnerCenter.md
schema: 2.0.0
---

# Connect-PartnerCenter

## SYNOPSIS
Connects to Partner Center with an authenticated account for use with cmdlet requests.

## SYNTAX

### User (Default)
```powershell
Connect-PartnerCenter -ApplicationId <String> [-EnforceMFA] [-Environment <EnvironmentName>]
 [-TenantId <String>] [<CommonParameters>]
```

### AccessToken
```powershell
Connect-PartnerCenter -AccessToken <String> -ApplicationId <String> [-Credential <PSCredential>] [-EnforceMFA]
 [-Environment <EnvironmentName>] [-TenantId <String>] [<CommonParameters>]
```

### ServicePrincipal
```powershell
Connect-PartnerCenter [-ApplicationId <String>] -Credential <PSCredential> [-EnforceMFA]
 [-Environment <EnvironmentName>] -TenantId <String> [<CommonParameters>]
```

## DESCRIPTION
The Connect-PartnerCenter cmdlet connects to Partner Center with an authenticated account for use with cmdlet requests

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-PartnerCenter -ApplicationId '<AppId>'
```

Connects to Partner Center using the specified application identifier during authentication.

### Example 2
```powershell
PS C:\> $credential = Get-Credential
PS C:\> Connect-PartnerCenter -ApplicationId '<AppId>' -Credential $credential -TenantId '<TenantId>'
```

Connects to Partner Center using app only authentication. Not all commands support this type of authentication.

### Example 3
```powershell
PS C:\> Connect-PartnerCenter -AccessToken '<AccessToken>' -ApplicationId '<AppId>' -TenantId '<TenantId>'
```

Connects to Partner Center using an access token.

## PARAMETERS

### -AccessToken
The access token for Partner Center.

```yaml
Type: String
Parameter Sets: AccessToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationId
The identifier of the Azure AD application.

```yaml
Type: String
Parameter Sets: User, AccessToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ServicePrincipal
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Credentials that represents the service principal.

```yaml
Type: PSCredential
Parameter Sets: AccessToken
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: PSCredential
Parameter Sets: ServicePrincipal
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnforceMFA
A flag indicating whether or not multi-factor authentication is enforced. The is only configurable while the Partner Center API is not requiring multi-factor authentication.

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

### -Environment
The environment use for authentication.

```yaml
Type: EnvironmentName
Parameter Sets: (All)
Aliases: EnvironmentName
Accepted values: GlobalCloud, ChinaCloud, GermanCloud, USGovernment

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The identifier of the Azure AD tenant.

```yaml
Type: String
Parameter Sets: User, AccessToken
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ServicePrincipal
Aliases:

Required: True
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

### Microsoft.Store.PartnerCenter.PowerShell.Authentication.PartnerContext

## NOTES

## RELATED LINKS
