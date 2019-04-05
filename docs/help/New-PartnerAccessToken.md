---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerAccessToken.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerAccessToken.md
schema: 2.0.0
---

# New-PartnerAccessToken

## SYNOPSIS
Acquires an access token from the authority.

## SYNTAX

### User (Default)
```powershell
New-PartnerAccessToken -ApplicationId <String> [-Consent] [-Environment <EnvironmentName>]
 [-RefreshToken <String>] [-Resource <String>] [-TenantId <String>] [<CommonParameters>]
```

### ServicePrincipal
```powershell
New-PartnerAccessToken [-ApplicationId <String>] [-Consent] -Credential <PSCredential>
 [-Environment <EnvironmentName>] [-RefreshToken <String>] [-Resource <String>] -TenantId <String>
 [<CommonParameters>]
```

## DESCRIPTION
The New-PartnerAccessToken can be used to request new access tokens.

## EXAMPLES

### Example 1
```powershell
PS C:\> $appId = '<AAD-AppId>'
PS C:\> $appSecret = '<AAD-AppSecret>' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> $credential = New-Object System.Management.Automation.PSCredential $appId, $appSecret
PS C:\> New-PartnerAccessToken -Credential $credential -TenantId '<TenantId>'
```

Generates a new access token using a service principal for authentication.

### Example 2
```powershell
PS C:\> $credential = Get-Credential
PS C:\> New-PartnerAccessToken -ApplicationId '<AAD-AppId>' -Credential $credential -TenantId '<TenantId>'
```

Generate a new access token using user credentials for authentication.

## PARAMETERS

### -ApplicationId
The identifier for the Azure AD application.

```yaml
Type: String
Parameter Sets: User
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

### -Consent
A flag that indicates that the intention is to perform the partner consent process.

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

### -Credential
Credentials that represents the service principal.

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

### -Environment
Name of the environment to be used during authentication.

```yaml
Type: EnvironmentName
Parameter Sets: (All)
Aliases: EnvironmentName
Accepted values: GlobalCloud, ChinaCloud, GermanCloud, PPE, USGovernment

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RefreshToken
The refresh token to use in the refresh flow.

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

### -Resource
The identifier of the target resource that is the recipient of the requested token.

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

### -TenantId
The identifier of the Azure AD tenant.

```yaml
Type: String
Parameter Sets: User
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.Models.Authentication.AuthenticationResult

## NOTES

## RELATED LINKS
