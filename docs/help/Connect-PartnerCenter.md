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
Connect to Partner Center with an authenticated account for use with partner cmdlet requests.

## SYNTAX

### User (Default)
```powershell
Connect-PartnerCenter [-Environment <EnvironmentName>] [-Tenant <String>] [-UseDeviceAuthentication] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AccessToken
```powershell
Connect-PartnerCenter -AccessToken <String> -ApplicationId <String> [-Environment <EnvironmentName>]
 [-Tenant <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RefreshToken
```powershell
Connect-PartnerCenter -ApplicationId <String> [-CertificateThumbprint <String>] [-Credential <PSCredential>]
 [-Environment <EnvironmentName>] -RefreshToken <String> [-ServicePrincipal] [-Tenant <String>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ServicePrincipalCertificate
```powershell
Connect-PartnerCenter [-CertificateThumbprint <String>] [-Environment <EnvironmentName>] [-Tenant <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ServicePrincipal
```powershell
Connect-PartnerCenter [-Credential <PSCredential>] [-Environment <EnvironmentName>] [-ServicePrincipal]
 [-Tenant <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Connect-PartnerCenter cmdlet connects to Partner Center with an authenticated account for use with partner cmdlet requests. After executing this cmdlet, you can disconnect from an Partner Center account using Disconnect-PartnerCenter.

## EXAMPLES

### Example 1: Use an interactive login to connect to a Partner Center account

```powershell
PS C:\> Connect-PartnerCenter
```

This command connects to a Partner Center account. To run partner cmdlets with this account, you must provide an organizational credentials, that are associated with the Cloud Solution Provider program, at the prompt.

### Example 2: Connect to Partner Center using a service principal account

```powershell
PS C:\> $credential = Get-Credential
PS C:\> Connect-PartnerCenter -Credential $credential -Tenant 'xxxx-xxxx-xxxx-xxxx' -ServicePrincipal
```

The first command gets the service principal credentials (application identifier and service principal secret), and then stores them in the $credential variable. The second command connects to Partner Center using the service principal credentials stored in $credential for the specified Tenant. The ServicePrincipal switch parameter indicates that the account authenticates as a service principal.

### Example 3: Connect to Partner using a refresh token

```powershell
PS C:\> $credential = Get-Credential
PS C:\> $refreshToken = '<refreshToken>'
PS C:\> $token = New-PartnerAccessToken -ApplicationId 'xxxx-xxxx-xxxx-xxxx' -Credential $credential -RefreshToken $refreshToken -Scopes "https://api.partnercenter.microsoft.com/user_impersonation" -ServicePrincipal -Tenant 'xxxx-xxxx-xxxx-xxxx'
PS C:\> Connect-PartnerCenter -AccessToken $token.AccessToken -ApplicationId 'xxxx-xxxx-xxxx-xxxx' -Tenant 'xxxx-xxxx-xxxx-xxxx'
```

The first command gets the service principal credentials (application identifier and service principal secret), and then stores them in the $credential variable. The third command generates a new access token using the specified refresh token. The final command connects to Partner Center using the access token stored in $token.AccessToken for authentication. The ServicePrincipal switch parameter indicates that the refresh token was generated using a confidential client.

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
SPN

```yaml
Type: String
Parameter Sets: AccessToken, RefreshToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateThumbprint
Certificate Hash (Thumbprint)

```yaml
Type: String
Parameter Sets: RefreshToken, ServicePrincipalCertificate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Application identifier and secret for service principal credentials.

```yaml
Type: PSCredential
Parameter Sets: RefreshToken, ServicePrincipal
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
Environment containing the account to log into.

```yaml
Type: EnvironmentName
Parameter Sets: (All)
Aliases:
Accepted values: AzureCloud, AzureChinaCloud, AzureGermanCloud, AzurePPE, AzureUSGovernment

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RefreshToken
Refresh token used to connect to Partner Center.

```yaml
Type: String
Parameter Sets: RefreshToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipal
Indicates that this account authenticates by providing service principal credentials.

```yaml
Type: SwitchParameter
Parameter Sets: RefreshToken, ServicePrincipal
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tenant
The identifier of the Azure AD tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Domain, TenantId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseDeviceAuthentication
Use device code authentication instead of a browser control

```yaml
Type: SwitchParameter
Parameter Sets: User
Aliases: Device, DeviceAuth, DeviceCode

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication.PartnerContext

## NOTES

## RELATED LINKS
