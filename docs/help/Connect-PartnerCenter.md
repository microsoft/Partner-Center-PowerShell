---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Connect-PartnerCenter.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Connect-PartnerCenter.md
schema: 2.0.0
---

# Connect-PartnerCenter

## SYNOPSIS
Connects to Partner Center with an authenticated account for use with cmdlet requests.

## SYNTAX

### UserCredential (Default)
```powershell
Connect-PartnerCenter -ApplicationId <String> [-Environment <EnvironmentName>] [<CommonParameters>]
```

### AccessToken
```powershell
Connect-PartnerCenter -AccessToken <String> -ApplicationId <String> [-Environment <EnvironmentName>]
 -TenantId <String> [<CommonParameters>]
```

### ServicePrincipal
```powershell
Connect-PartnerCenter -Credential <PSCredential> [-Environment <EnvironmentName>] [-ServicePrincipal]
 -TenantId <String> [<CommonParameters>]
```

## DESCRIPTION
The Connect-PartnerCenter cmdlet connects to Partner Center with an authenticated account for use with cmdlet requests

## EXAMPLES

### Example 1

```powershell
PS C:\> Connect-PartnerCenter -ApplicationId '<AppId>'
```

Connect to Partner Center using the specified application identifier during authentication.

### Example 2

```powershell
PS C:\> $credential = Get-Credential
PS C:\> Connect-PartnerCenter -ApplicationId '<AppId>' -Credential $credential
```

Connect to Partner Center using the specified application identifier during authentication.

### Example 3

```powershell
PS C:\> $credential = Get-Credential
PS C:\> Connect-PartnerCenter -Credential $credential -ServicePrincipal -TenantId '<AppId>'
```

Connects to Partner Center using app only authentication. When prompted for credential specify the application identifier for the username and the application secret for the password.

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
The application identifier used to access the Partner Center API.

```yaml
Type: String
Parameter Sets: UserCredential, AccessToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
User credentials to be used when connecting to Partner Center.

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
Name of the environment containing the account to log into

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

### -ServicePrincipal
A flag indiicating that a service principal will be used to authenticate.

```yaml
Type: SwitchParameter
Parameter Sets: ServicePrincipal
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
The Azure AD domain or tenant identifier.

```yaml
Type: String
Parameter Sets: AccessToken, ServicePrincipal
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

### Microsoft.Store.PartnerCenter.PowerShell.Profile.PartnerContext

## NOTES

## RELATED LINKS
