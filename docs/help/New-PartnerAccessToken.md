---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerAccessToken.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerAccessToken.md
schema: 2.0.0
---

# New-PartnerAccessToken

## SYNOPSIS
Generate a new access token that can be used to access Partner Center.

## SYNTAX

### UserCredential (Default)
```
New-PartnerAccessToken -ApplicationId <String> [-Credential <PSCredential>] [-Environment <EnvironmentName>]
 [-TokenCache <TokenCache>] [<CommonParameters>]
```

### ServicePrincipal
```
New-PartnerAccessToken -Credential <PSCredential> [-Environment <EnvironmentName>] -TenantId <String>
 [-TokenCache <TokenCache>] [<CommonParameters>]
```

## DESCRIPTION
The New-PartnerAccessToken command generates a new access token that can be used to access Partner Center.

## EXAMPLES

### Example 1
```powershell
PS C:\> $appId = '<AAD-AppId>'
PS C:\> $appSecret = '<AAD-AppSecret>' | ConvertTo-SecureString -AsPlainText -Force
PS C:\> $credential = New-Object System.Management.Automation.PSCredential $appId $appSecret
PS C:\> New-PartnerAccessToken -Credential $credential -ServicePrincipal -TenantId '<TenantId>'
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
The application identifier used to access Partner Center.

```yaml
Type: String
Parameter Sets: UserCredential
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Credentials that represents the service principal.

```yaml
Type: PSCredential
Parameter Sets: UserCredential
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

### -Environment
Name of the environment to be used during authentication.

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
The Azure AD domain or tenant identifier.

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

### -TokenCache
The token cache to be used when requesting an access token.

```yaml
Type: TokenCache
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

### Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult

## NOTES

## RELATED LINKS
