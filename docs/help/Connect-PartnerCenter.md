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

```
Connect-PartnerCenter -ApplicationId <String> [-Credential <PSCredential>] [-Environment <EnvironmentName>]
 [<CommonParameters>]
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
PS C:\> $cred = Get-Credential
PS C:\> Connect-PartnerCenter -ApplicationId c4d99f39-a917-4d70-8fdb-0ad839ac0524 -Credential $cred
```

Connect to Partner Center using the specified application identifier during authentication.

## PARAMETERS

### -ApplicationId
The application identifier used to access the Partner Center API.

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

### -Credential
User credentials to be used when connecting to Partner Center.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases:

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Authentication.PartnerContext

## NOTES

## RELATED LINKS
