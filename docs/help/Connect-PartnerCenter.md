---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Connect-PartnerCenter

## SYNOPSIS
Connect to Partner Center with an authenticated account for use with cmdlet requests.

## SYNTAX

### UserCredential (Default)
```
Connect-PartnerCenter -ApplicationId <String> [-Credential <PSCredential>] [-Environment <EnvironmentName>]
 [<CommonParameters>]
```

### ServicePrincipal
```
Connect-PartnerCenter -Credential <PSCredential> [-Environment <EnvironmentName>] [-ServicePrincipal]
 -TenantId <String> [<CommonParameters>]
```

## DESCRIPTION
The Connect-PartnerCenter cmdlet connects to Partner Center with an authenticated account for use with cmdlet requests

## EXAMPLES

### Example 1

```powershell
PS C:\> Connect-PartnerCenter -ApplicationId c4d99f39-a917-4d70-8fdb-0ad839ac0524
```

Connect to Partner Center using the specified application identifier during authentication.

### Example 2

```powershell
PS C:\> $credential = Get-Credential
PS C:\> Connect-PartnerCenter -ApplicationId c4d99f39-a917-4d70-8fdb-0ad839ac0524 -Credential $credential
```

Connect to Partner Center using the specified application identifier during authentication.

### Example 3

```powershell
PS C:\> $credential = Get-Credential
PS C:\> Connect-PartnerCenter -Credential $credential -ServicePrincipal -TenantId 5747dbbe-9cad-45c0-bc02-47d7fa3cffcc
```

Connects to Partner Center using app only authentication. When prompted for credential specify the application identifier for the username and the application secret for the password.

## PARAMETERS

### -ApplicationId
The application identifier used to access the Partner Center API.

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
User credentials to be used when connecting to Partner Center.

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

### Microsoft.Store.PartnerCenter.PowerShell.Profile.PartnerContext

## NOTES

## RELATED LINKS
